import { Component, Injector, OnInit } from '@angular/core';
import { CreatePatientDialogComponent } from '@app/patients/create-patient/create-patient-dialog/create-patient-dialog.component';
import { EditPatientDialogComponent } from '@app/patients/edit-patient/edit-patient-dialog/edit-patient-dialog.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import {
  PatientDto, PatientDtoPagedResultDto, PatientServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

class PagedPatientsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css'],
  providers: [PatientServiceProxy],
  animations: [appModuleAnimation()]
})
export class PatientsComponent extends PagedListingComponentBase<PatientDto> {
  patients: PatientDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _patientService: PatientServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
   }

   list(
    request: PagedPatientsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._patientService
      .getAll(
        request.keyword,
        request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: PatientDtoPagedResultDto) => {
        this.patients = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(patient: PatientDto): void {
    abp.message.confirm(
      this.l('TenantDeleteWarningMessage', patient.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._patientService
            .delete(patient.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createPatient(): void {
    this.showCreateOrEditPatientDialog();
  }

  editPatient(tenant: PatientDto): void {
    this.showCreateOrEditPatientDialog(tenant.id);
  }

  showCreateOrEditPatientDialog(id?: number): void {
    let createOrEditTenantDialog: BsModalRef;
    if (!id) {
      createOrEditTenantDialog = this._modalService.show(
        CreatePatientDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditTenantDialog = this._modalService.show(
        EditPatientDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditTenantDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}

import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { DoctorDto, DoctorDtoPagedResultDto, DoctorServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateDoctorComponent } from '../create-doctor/create-doctor.component';
import { EditDoctorComponent } from '../edit-doctor/edit-doctor.component';

class PagedDoctorsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-list-doctor',
  templateUrl: './list-doctor.component.html',
  styleUrls: ['./list-doctor.component.css'],
  providers: [DoctorServiceProxy],
  animations: [appModuleAnimation()]
})
export class ListDoctorComponent extends PagedListingComponentBase<DoctorDto> {
  doctors: DoctorDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _doctorService: DoctorServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
   }
  
   list(
    request: PagedDoctorsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._doctorService
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
      .subscribe((result: DoctorDtoPagedResultDto) => {
        this.doctors = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(doctor: DoctorDto): void {
    abp.message.confirm(
      this.l('TenantDeleteWarningMessage', doctor.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._doctorService
            .delete(doctor.id)
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

  createDoctor(): void {
    this.showCreateOrEditDoctorDialog();
  }

  editDoctor(tenant: DoctorDto): void {
    this.showCreateOrEditDoctorDialog(tenant.id);
  }

  showCreateOrEditDoctorDialog(id?: number): void {
    let createOrEditDoctorDialog: BsModalRef;
    if (!id) {
      createOrEditDoctorDialog = this._modalService.show(
        CreateDoctorComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditDoctorDialog = this._modalService.show(
        EditDoctorComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditDoctorDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}

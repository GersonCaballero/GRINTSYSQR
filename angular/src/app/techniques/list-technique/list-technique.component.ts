import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { TechniqueDto, TechniqueDtoPagedResultDto, TechniquesServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateTechniqueComponent } from '../create-technique/create-technique.component';
import { EditTechniqueComponent } from '../edit-technique/edit-technique.component';

class PagedTechniqueRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-list-technique',
  templateUrl: './list-technique.component.html',
  styleUrls: ['./list-technique.component.css'],
  providers: [TechniquesServiceProxy],
  animations: [appModuleAnimation()]
})
export class ListTechniqueComponent extends PagedListingComponentBase<TechniqueDto> {

  techniques: TechniqueDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _techniqueService: TechniquesServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
   }

   list(
    request: PagedTechniqueRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._techniqueService
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
      .subscribe((result: TechniqueDtoPagedResultDto) => {
        this.techniques = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(technique: TechniqueDto): void {
    abp.message.confirm(
      this.l('TenantDeleteWarningMessage', technique.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._techniqueService
            .delete(technique.id)
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

  createTechnique(): void {
    this.showCreateOrEditTechniqueDialog();
  }

  editTechnique(technique: TechniqueDto): void {
    this.showCreateOrEditTechniqueDialog(technique.id);
  }

  showCreateOrEditTechniqueDialog(id?: number): void {
    let createOrEditTechniqueDialog: BsModalRef;
    if (!id) {
      createOrEditTechniqueDialog = this._modalService.show(
        CreateTechniqueComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditTechniqueDialog = this._modalService.show(
        EditTechniqueComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditTechniqueDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}

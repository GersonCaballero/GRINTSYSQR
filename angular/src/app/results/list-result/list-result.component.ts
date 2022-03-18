import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { ResultDto, ResultDtoPagedResultDto, ResultServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateResultComponent } from '../create-result/create-result.component';
import { EditResultComponent } from '../edit-result/edit-result.component';

class PagedResultRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-list-result',
  templateUrl: './list-result.component.html',
  styleUrls: ['./list-result.component.css'],
  providers: [ResultServiceProxy],
  animations: [appModuleAnimation()]
})
export class ListResultComponent extends PagedListingComponentBase<ResultDto> {

  results: ResultDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _resultService: ResultServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
   }

   list(
    request: PagedResultRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._resultService
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
      .subscribe((result: ResultDtoPagedResultDto) => {
        this.results = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(result_delete: ResultDto): void {
    abp.message.confirm(
      this.l('TenantDeleteWarningMessage', result_delete.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._resultService
            .delete(result_delete.id)
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

  createResult(): void {
    this.showCreateOrEditResultDialog();
  }

  editResult(result: ResultDto): void {
    this.showCreateOrEditResultDialog(result.id);
  }

  showCreateOrEditResultDialog(id?: number): void {
    let createOrEditResultDialog: BsModalRef;
    if (!id) {
      createOrEditResultDialog = this._modalService.show(
        CreateResultComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditResultDialog = this._modalService.show(
        EditResultComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditResultDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}

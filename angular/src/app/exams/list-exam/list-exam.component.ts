import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { ExamDto, ExamDtoPagedResultDto, ExamServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateExamComponent } from '../create-exam/create-exam.component';
import { EditExamComponent } from '../edit-exam/edit-exam.component';

class PagedExamRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-list-exam',
  templateUrl: './list-exam.component.html',
  styleUrls: ['./list-exam.component.css'],
  providers: [ExamServiceProxy],
  animations: [appModuleAnimation()]
})
export class ListExamComponent extends PagedListingComponentBase<ExamDto> {

  exams: ExamDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _examService: ExamServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
   }

   list(
    request: PagedExamRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._examService
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
      .subscribe((result: ExamDtoPagedResultDto) => {
        this.exams = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(exam: ExamDto): void {
    abp.message.confirm(
      this.l('TenantDeleteWarningMessage', exam.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._examService
            .delete(exam.id)
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

  createExam(): void {
    this.showCreateOrEditExamDialog();
  }

  editExam(exam: ExamDto): void {
    this.showCreateOrEditExamDialog(exam.id);
  }

  showCreateOrEditExamDialog(id?: number): void {
    let createOrEditResultDialog: BsModalRef;
    if (!id) {
      createOrEditResultDialog = this._modalService.show(
        CreateExamComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditResultDialog = this._modalService.show(
        EditExamComponent,
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

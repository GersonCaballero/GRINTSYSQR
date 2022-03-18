import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ResultDto, ResultServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-result',
  templateUrl: './edit-result.component.html',
  styleUrls: ['./edit-result.component.css'],
  providers: [ResultServiceProxy]
})
export class EditResultComponent extends AppComponentBase implements OnInit {

  saving = false;
  result: ResultDto = new ResultDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _resultService: ResultServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._resultService.get(this.id).subscribe((result: ResultDto) => {
      this.result = result;
    });
  }

  save(): void {
    this.saving = true;

    this._resultService.update(this.result).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }

}

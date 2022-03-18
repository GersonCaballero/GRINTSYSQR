import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ResultDto, ResultServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-result',
  templateUrl: './create-result.component.html',
  styleUrls: ['./create-result.component.css'],
  providers: [ResultServiceProxy]
})
export class CreateResultComponent extends AppComponentBase implements OnInit {

  saving = false;
  result: ResultDto = new ResultDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _resultService: ResultServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._resultService.create(this.result).subscribe(
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

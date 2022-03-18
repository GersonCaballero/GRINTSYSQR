import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DoctorDto, DoctorServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-doctor',
  templateUrl: './create-doctor.component.html',
  styleUrls: ['./create-doctor.component.css'],
  providers: [DoctorServiceProxy]
})
export class CreateDoctorComponent extends AppComponentBase implements OnInit {

  saving = false;
  doctor: DoctorDto = new DoctorDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _doctorService: DoctorServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._doctorService.create(this.doctor).subscribe(
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

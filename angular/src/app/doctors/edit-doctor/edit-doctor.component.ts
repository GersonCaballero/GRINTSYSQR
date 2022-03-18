import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DoctorDto, DoctorServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-doctor',
  templateUrl: './edit-doctor.component.html',
  styleUrls: ['./edit-doctor.component.css'],
  providers: [DoctorServiceProxy]
})
export class EditDoctorComponent extends AppComponentBase implements OnInit {

  saving = false;
  doctor: DoctorDto = new DoctorDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _doctorService: DoctorServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._doctorService.get(this.id).subscribe((result: DoctorDto) => {
      this.doctor = result;
    });
  }

  save(): void {
    this.saving = true;

    this._doctorService.update(this.doctor).subscribe(
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

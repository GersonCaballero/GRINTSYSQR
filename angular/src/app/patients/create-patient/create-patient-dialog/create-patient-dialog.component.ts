import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PatientDto, PatientServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-patient-dialog',
  templateUrl: './create-patient-dialog.component.html',
  styleUrls: ['./create-patient-dialog.component.css'],
  providers: [PatientServiceProxy]
})
export class CreatePatientDialogComponent extends AppComponentBase
  implements OnInit {

  saving = false;
  patient: PatientDto = new PatientDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _patientService: PatientServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._patientService.create(this.patient).subscribe(
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

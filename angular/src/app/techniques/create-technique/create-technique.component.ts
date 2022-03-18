import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { TechniqueDto, TechniquesServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-technique',
  templateUrl: './create-technique.component.html',
  styleUrls: ['./create-technique.component.css'],
  providers: [TechniquesServiceProxy]
})
export class CreateTechniqueComponent extends AppComponentBase implements OnInit {

  saving = false;
  technique: TechniqueDto = new TechniqueDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _techniqueService: TechniquesServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._techniqueService.create(this.technique).subscribe(
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

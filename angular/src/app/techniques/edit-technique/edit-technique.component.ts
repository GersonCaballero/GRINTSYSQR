import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { TechniqueDto, TechniquesServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-technique',
  templateUrl: './edit-technique.component.html',
  styleUrls: ['./edit-technique.component.css'],
  providers: [TechniquesServiceProxy]
})
export class EditTechniqueComponent extends AppComponentBase implements OnInit {

  saving = false;
  technique: TechniqueDto = new TechniqueDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _techniqueService: TechniquesServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._techniqueService.get(this.id).subscribe((result: TechniqueDto) => {
      this.technique = result;
    });
  }

  save(): void {
    this.saving = true;

    this._techniqueService.update(this.technique).subscribe(
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

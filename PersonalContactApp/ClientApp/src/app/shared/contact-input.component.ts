import { Component, EventEmitter, Input, OnChanges, Output } from "@angular/core";
import { IContact } from "../contacts/contact";

@Component({
  selector: 'cm-contact-input',
  templateUrl: './contact-input.component.html',
  styleUrls: ['./contact-input.component.css']
})
export class ContactInputComponent {
  @Input() inputContact: IContact = {} as IContact;
  @Output() contactSave: EventEmitter<IContact> =
    new EventEmitter<IContact>();

  private _contact: IContact = this.inputContact;
  get contact(): IContact {
    return this._contact;
  }
  set contact(value: IContact) {
    this._contact = value;
  }

  ngOnInit(): void {
    this._contact = this.inputContact;
  }

  confirm(): void {
    this.contactSave.emit(this._contact);
  }
}

import { Component, OnInit } from '@angular/core';
import { IContact } from './contact';
import { ContactService } from './contact.service';
import { Subscription } from "rxjs";
import { ConfirmationService } from 'primeng/api';
import { Message } from "primeng/api";
import { MessageService } from 'primeng/api';

@Component({
  selector: 'cm-edit-contacts',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {
  pageTitle: string = 'Edit contact';
  incomeContact: IContact | undefined;
  sub!: Subscription;
  msgs: Message[] = [];

  constructor(private contactService: ContactService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService  ) { }

  private _contact: IContact = {} as IContact;
  get contact(): IContact {
    return this._contact;
  }
  set contact(value: IContact) {
    this._contact = value;
  }

  ngOnInit(): void {
    this._contact = this.contactService.contact;
  }

  onContactSave(contact: IContact) {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to perform this action?',
      accept: () => {
        this.contactService.updateContact(contact);
        this.sub = this.contactService.updateContact(contact).subscribe({
          next: data => {
            this.messageService.add({ severity: 'success', summary: 'Edit contact', detail: 'Succeeded' });
          },
          error: err => {
            this.messageService.add({ severity: 'error', summary: 'Validation Error', detail: err });
          }
        });
      }
    });
  }
}

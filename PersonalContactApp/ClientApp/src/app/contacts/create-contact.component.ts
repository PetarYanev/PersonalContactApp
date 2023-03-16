import { Component, OnInit } from '@angular/core';
import { IContact } from './contact';
import { ContactService } from './contact.service';
import { Subscription } from "rxjs";
import { ConfirmationService } from 'primeng/api';
import { Message } from "primeng/api";
import { MessageService } from 'primeng/api';

@Component({
  selector: 'cm-create-contacts',
  templateUrl: './create-contact.component.html',
  styleUrls: ['./create-contact.component.css']
})
export class CreateContactComponent implements OnInit {
  pageTitle: string = 'Create contact';
  incomeContact: IContact | undefined;
  sub!: Subscription;
  msgs: Message[] = [];

  constructor(private contactService: ContactService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService) { }

  private _contact: IContact = {} as IContact;
  get contact(): IContact {
    return this._contact;
  }
  set contact(value: IContact) {
    this._contact = value;
  }

  ngOnInit(): void {
    
  }

  onContactSave(contact: IContact) {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to perform this action?',
      accept: () => {
        this.contactService.createContact(contact);
        this.sub = this.contactService.createContact(contact).subscribe({
          next: data => {
            this.messageService.add({ severity: 'success', summary: 'Create contact', detail: 'Succeeded' });
          },
          error: err => {
            this.messageService.add({ severity: 'error', summary: 'Validation Error', detail: err });
          }
        });
      }
    });
  }
}

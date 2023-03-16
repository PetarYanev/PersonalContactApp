import { Component, OnDestroy, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";
import { IContact } from "./contact";
import { ContactService } from "./contact.service";

@Component({
  selector: 'cm-contacts',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContacttListComponent implements OnInit, OnDestroy {
  pageTitle: string = 'Contacts List';
  errorMessage: string = '';
  sub!: Subscription;

  contacts: IContact[] = [];

  constructor(private contactService: ContactService, private router: Router) { }

  performFilter(filterBy: string): IContact[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.contacts.filter((contact: IContact) =>
      contact.firstName.toLocaleLowerCase().includes(filterBy));
  }

  ngOnInit(): void {
    this.sub = this.contactService.getContact().subscribe({
      next: data => {
        this.contacts = data.contacts;
      },
      error: err => this.errorMessage = err
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  openProduct(contact: IContact): void {
    this.contactService.contact = contact;
    this.router.navigate(['/contacts', contact.id]);
  }
}

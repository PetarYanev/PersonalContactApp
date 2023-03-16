import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ContacttListComponent } from './contacts/contact-list.component';
import { EditContactComponent } from './contacts/edit-contact.component';
import { CreateContactComponent } from './contacts/create-contact.component';
import { ContactInputComponent } from './shared/contact-input.component';
import { EditContactGuard } from './contacts/edit-contact.guard';

import { TableModule } from 'primeng/table';
import { ChipsModule } from 'primeng/chips';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { MessageService } from 'primeng/api';

@NgModule({
  declarations: [
    AppComponent,
    ContacttListComponent,
    EditContactComponent,
    CreateContactComponent,
    ContactInputComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    TableModule,
    ChipsModule,
    InputTextModule,
    CalendarModule,
    BrowserAnimationsModule,
    ConfirmDialogModule,
    ToastModule,
    MessagesModule,
    MessageModule,
    RouterModule.forRoot([
      {
        path: 'contacts',
        component: ContacttListComponent
      },
      {
        path: 'contacts/:id',
        canActivate: [EditContactGuard],
        component: EditContactComponent
      },
      {
        path: 'create-contact',
        component: CreateContactComponent
      }
    ])
  ],
  providers: [ConfirmationService,
              MessageService ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, tap, throwError } from "rxjs";
import { IContact } from "./contact";
import { IContacts } from "./contacts";
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  constructor(private http: HttpClient) { }

  getContact(): Observable<IContacts> {
    return this.http.get<IContacts>('https://localhost:7196/contacts').pipe(
      catchError(this.handleError)
    );
  }

  updateContact(contact: IContact): Observable<any> {
    return this.http.put('https://localhost:7196/contacts', contact, httpOptions).pipe(
      catchError(this.handleError)
    );
  }

  createContact(contact: IContact): Observable<any> {
    return this.http.post('https://localhost:7196/contacts', contact, httpOptions).pipe(
      catchError(this.handleError)
    );
  }

  contact: IContact = {} as IContact;

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `${Object.values(err.error.errors)[0]}`;
    }
    return throwError(() => errorMessage);
  }
}

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

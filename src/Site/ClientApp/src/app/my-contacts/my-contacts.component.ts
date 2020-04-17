import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserIdService } from "../userId.service";

@Component({
    selector: 'app-my-contacts',
    templateUrl: './my-contacts.component.html'
})
export class MyContactsComponent {
    http: HttpClient = null;
    baseUrl = null;
    userId: number;
    public contacts: Contact[];
    newContact: Contact = { Id : 0, Name:"", Email: "", Address:""};

    constructor(private userIdSvc: UserIdService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
        this.userIdSvc.currentUserId.subscribe(userId => this.getContactsForUserId(userId))
    }

    getContactsForUserId(userId: number) {
        this.http.get<Contact[]>(this.baseUrl + 'api/ContactService/GetContactsForUser/' + userId + '/1/10').subscribe(result => {
            this.contacts = result;
          }, error => console.error(error));
          alert(userId);
          if(userId !== undefined && userId !== 0){
            this.isShowingEditors = true;
          }
    }

    isShowingEditors = false;
   


    public addContact(){
        alert(this.newContact.Email);
    }

    // Contacts grid
    headers = ["", "", "Id", "Email", "Name", "Address"];
}

interface Contact {
    Id: number;
    Email: string;
    Name: string;
    Address: string;
}



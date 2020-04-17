import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserIdService } from "../userId.service";

@Component({
    selector: 'app-login-component',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    userName = '';
    userId = null;
    http: HttpClient = null;
    baseUrl = null;

    constructor(private userIdSvc: UserIdService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
        this.userIdSvc.currentUserId.subscribe(userId => this.userId = userId)
      }

    public login() {
        const userLogin: UserRegistration = { userName: this.userName};
        this.http.post(this.baseUrl + 'api/UserService/Register', userLogin).subscribe(result => {
            this.userId = result;
            this.userIdSvc.changeUserId(this.userId)
        }, error => console.error(error));
    }

}

interface UserRegistration {
    userName: string;
}


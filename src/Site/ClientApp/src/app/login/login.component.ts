import { Component } from '@angular/core';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  

  public login() {
    alert('login');
  }
}

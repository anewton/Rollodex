import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class UserIdService {

  private userIdSource = new BehaviorSubject(0);
  currentUserId = this.userIdSource.asObservable();

  constructor() { }

  changeUserId(userId: number) {
    this.userIdSource.next(userId)
  }

}
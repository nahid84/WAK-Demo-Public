import { Component, Inject } from '@angular/core';
import { UsersService, Users } from 'src/app/users/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent {

  public users: Users[];

  constructor(
    private usersService: UsersService,
    @Inject('BASE_URL') baseUrl: string) {

    usersService.getUserData(baseUrl)
      .subscribe(result => {
        this.users = result;
      })
  }
}



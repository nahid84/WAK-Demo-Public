import { Component, OnInit, Inject } from '@angular/core';
import { UsersService, Users, User } from 'src/app/users/users.service'
import { concat } from 'rxjs';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent {

  public user: User = new User();
  public isSubmitted: boolean = false; 

  constructor(
    private usersService: UsersService,
    @Inject('BASE_URL') private baseUrl: string) { }

  onSubmit() {
    this.usersService.createUser(this.baseUrl, this.user)
      .subscribe(success => {
        console.log(success);
        this.isSubmitted = true;
      }, error => console.log(error));
  }

  onCreateNew() {
    this.user = new User();
    this.isSubmitted = false;
  }
}

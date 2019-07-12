import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UsersComponent } from './users/users.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { CreateUserComponent } from './create-user/create-user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UsersComponent,
    TransactionsComponent,
    CreateUserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: UsersComponent, pathMatch: 'full' },
      { path: 'users', component: UsersComponent },
      { path: 'create-user', component: CreateUserComponent },
      { path: 'transactions/:accountNumber', component: TransactionsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

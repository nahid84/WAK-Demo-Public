import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  
  constructor(private http: HttpClient) { }

  getUserData(baseUrl: string): Observable<Users[]> {
    return this.http.get<Users[]>(baseUrl + 'api/users');
  }

  createUser(baseUrl: string, user: User): Observable<any> {
    return this.http.post<any>(baseUrl + 'api/users', user);
  }
}

export interface Users {
  name: string;
  accountNumber: string;
  address: string;
  email: string;
  phone: string;
}

export class User {
  public firstName: string;
  public lastName: string;
  public address: string;
  public postcode: string;
  public city: string;
  public accountNumber: string
  public phone: string
  public email: string
}

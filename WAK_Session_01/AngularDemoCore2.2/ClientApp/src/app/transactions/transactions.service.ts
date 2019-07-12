import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransactionsService {
  
  constructor(private http: HttpClient) { }

  getTransactionData(baseUrl: string, accountNumber: string): Observable<Transactions[]> {
    return this.http.get<Transactions[]>(baseUrl + 'api/transactions/' + accountNumber);
  }
}

export interface Transactions {
  amount: number;
  operation: string;
}

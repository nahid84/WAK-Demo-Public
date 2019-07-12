import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from "@angular/router"
import { TransactionsService, Transactions } from 'src/app/transactions/transactions.service'

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html'
})
export class TransactionsComponent {

  public transactions: Transactions[];
  private accountNumber: string;

  constructor(
    private route: ActivatedRoute,
    private transactionsService: TransactionsService,
    @Inject('BASE_URL') baseUrl: string) {

    route.params.subscribe(params => {
      this.accountNumber = params['accountNumber'];
    })

    transactionsService.getTransactionData(baseUrl, this.accountNumber)
      .subscribe(result => {
        this.transactions = result;
      })
  }
}

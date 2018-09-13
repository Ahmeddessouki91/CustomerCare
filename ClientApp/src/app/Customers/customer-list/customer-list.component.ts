import { Component, OnInit } from '@angular/core';
import { Customer } from '../../models/Customer';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  private readonly PAGE_SIZE = 10;
  customers: Customer[];
  totalItems: number;
  query: any = {
    pageSize: this.PAGE_SIZE
  };


  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.populateCustomers();
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateCustomers();
  }

  restFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateCustomers();
  }

  private populateCustomers() {
    this.customerService.getCustomers(this.query).subscribe((result: any) => {
      this.customers = result.items;
      this.totalItems = result.totalItems;
    });
  }

  toggleActivation(customer: Customer) {
    customer.Activated = customer.Activated ? false : true;
    this.customerService.update(customer).subscribe(u => {
      this.populateCustomers();
    });
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateCustomers();
  }
}

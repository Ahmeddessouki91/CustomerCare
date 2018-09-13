import { KeyValuePair } from './../../models/Customer';
import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { Customer } from '../../models/Customer';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  customer: Customer = {
    Id: 0,
    Activated: false,
    Address: "",
    GovernerateId: 0,
    Email: "",
    Mobile: "",
    JobId: 0,
    Interactions: 0,
    Name: ""
  };
  jobs: KeyValuePair[] = [];
  update: boolean = false;
  constructor(private customerService: CustomerService, private router: Router, private route: ActivatedRoute) {
    route.params.subscribe(p => {
      this.customer.Id = +p["id"] || 0
    })
  }

  ngOnInit() {
    if (this.customer.Id) {
      this.customerService.getCustomer(this.customer.Id).subscribe((c: Customer) => {
        this.customer = c;
        this.update = true;
      });
    }
  }

  submit() {
    if (this.update)
      this.customerService.update(this.customer).subscribe(c => this.router.navigate(['/customers']));
    else
      this.customerService.createCustomer(this.customer).subscribe(c => this.router.navigate(['/customers']));
  }

}

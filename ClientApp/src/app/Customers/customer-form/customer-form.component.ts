import { AuthService } from './../../services/auth.service';
import { KeyValuePair, Customer } from './../../models/Customer';
import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { SaveCustomer } from '../../models/Customer';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  customer: SaveCustomer = {
    id: 0,
    activated: false,
    address: "",
    governerateId: 0,
    email: "",
    mobile: "",
    jobId: 0,
    interactions: 0,
    name: "",
    countryId: 0,
    userId: 0
  };
  jobs: KeyValuePair[] = [];
  countries: any[] = [];
  governerates: any[] = [];
  update: boolean = false;
  constructor(private customerService: CustomerService, private router: Router, private route: ActivatedRoute, private auth: AuthService) {
    route.params.subscribe(p => {
      this.customer.id = +p["id"] || 0
    })
  }

  ngOnInit() {
    var sources = [
      this.customerService.getCountries(),
      this.customerService.getJobs()
    ];
    if (this.customer.id)
      sources.push(this.customerService.getCustomer(this.customer.id));

    Observable.forkJoin(sources).subscribe((data: any[]) => {
      this.countries = data[0].items;
      this.jobs = data[1].items;

      if (this.customer.id) {
        this.setCustomer(data[2]);
        this.populateGovernerates();
      }
    });
  }


  private setCustomer(c: Customer) {
    this.customer.id = c.id;
    this.customer.name = c.name;
    this.customer.address = c.address;
    this.customer.email = c.email;
    this.customer.jobId = c.job.id;
    this.customer.countryId = c.country.id;
    this.customer.governerateId = c.governerate.id;
    this.customer.mobile = c.mobile;
    this.customer.interactions = c.interactions;
    this.customer.activated = c.activated;
  }
  onCountryChange() {
    this.populateGovernerates();
    delete this.customer.governerateId;
  }

  private populateGovernerates() {
    var selectedCountry = this.countries.find(c => c.id == this.customer.countryId);
    this.governerates = selectedCountry ? selectedCountry.governerates : [];
  }
  submit() {
    if (!this.update) {
      this.customer.userId = this.auth.userInfo.nameid;
      this.customerService.createCustomer(this.customer).subscribe(c => this.router.navigate(['/customers']));
    }
    else
      this.customerService.update(this.customer).subscribe(c => this.router.navigate(['/customers']));
  }

}

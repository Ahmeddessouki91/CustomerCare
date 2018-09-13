import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class CustomerService {

    private readonly customerEndpoint = "/api/Customers";

    constructor(private http: HttpClient) { }

    createCustomer(customer) {
        return this.http.post(this.customerEndpoint, customer);
    }
    getCustomers(filter) {
        return this.http.get(`${this.customerEndpoint}?${this.toQueryString(filter)}`);
    }
    getCustomer(id) {
        return this.http.get(`${this.customerEndpoint}/${id}`);
    }

    update(customer) {
        return this.http.put(`${this.customerEndpoint}/${customer.id}`, customer);
    }

    private toQueryString(obj) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }
        return parts.join('&');
    }

}
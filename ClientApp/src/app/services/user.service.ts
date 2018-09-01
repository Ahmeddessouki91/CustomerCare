import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService {

    private readonly userEndpoint = "/api/Users";

    constructor(private http: HttpClient) { }

    createUser(user) {
        return this.http.post(`/api/account/register`, user);
    }
    getUsers(filter) {
        return this.http.get(`${this.userEndpoint}?${this.toQueryString(filter)}`);
    }
    getUser(id) {
        return this.http.get(`${this.userEndpoint}/${id}`);
    }

    update(user) {
        return this.http.put(`${this.userEndpoint}/${user.id}`, user);
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

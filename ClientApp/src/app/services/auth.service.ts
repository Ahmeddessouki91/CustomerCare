import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from "rxjs/operators";
import { tokenNotExpired, JwtHelper } from "angular2-jwt";
@Injectable()
export class AuthService {

    private readonly baseUrl = "/api/account/";

    constructor(private http: HttpClient) { }

    login(model: any) {
        return this.http.post(this.baseUrl + "login", model).pipe(map((user: any) => {
            if (user && user.token) {
                localStorage.setItem("token", user.token);
                return true;
            }
            return false;
        }));
    }

    logout() {
        localStorage.removeItem('token');
    }

    public getToken(): string {
        return localStorage.getItem('token');
    }
    public isAuthenticated(): boolean {
        const token = this.getToken();
        return tokenNotExpired(null, token);
    }

    get userInfo() {
        const helper = new JwtHelper();
        let token = this.getToken(); 
        let tokenDecoded = helper.decodeToken(token);
        return tokenDecoded;
    }
}

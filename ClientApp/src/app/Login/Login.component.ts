import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      let returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
      this.router.navigate([returnUrl || '/']);
    }
  }
  login() {
    this.authService.login(this.model).subscribe(result => {
      if (result) {
        let returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
        this.router.navigate([returnUrl || '/']);
      }
    });
  }
}

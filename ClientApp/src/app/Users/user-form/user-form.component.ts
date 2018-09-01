import { map } from 'rxjs/operators';
import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { UserService } from '../../services/user.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {
  user: User = {
    id: 0,
    deactive: false,
    email: "",
    isAdmin: false,
    name: "",
    password: ""
  }
  update: boolean = false;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {
    route.params.subscribe(p => {
      this.user.id = +p['id'] || 0;
    });
  }

  ngOnInit() {
    if (this.user.id)
      this.userService.getUser(this.user.id).subscribe((u: User) => {
        this.user = u;
        this.update = true;
      })
  }

  submit() {

    this.userService.createUser(this.user).subscribe(u => {
      this.router.navigate(['/users']);
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {
  private readonly PAGE_SIZE = 10;
  Users: User[];
  totalItems: number;
  query: any = {
    pageSize: this.PAGE_SIZE
  };

  columns = [
    { title: 'Id' },
    { title: 'Name', key: 'name', isSortable: true },
    { title: 'Email', key: 'email', isSortable: true },
    { title: 'Customers' },
    { title: 'Interactions' },
    { title: 'Status' },
    {}
  ];
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.populateUsers();
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateUsers();
  }

  restFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateUsers();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName)
      this.query.isSortAscending = !this.query.isSortAscending;
    else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateUsers();
  }

  private populateUsers() {
    this.userService.getUsers(this.query).subscribe((result: any) => {
      this.Users = result.items;
      this.totalItems = result.totalItems;
    });
  }

  toggleActivation(user: User) {
    user.deactive = user.deactive ? false : true;
    this.userService.update(user).subscribe(u=>{
      this.populateUsers();
    });
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateUsers();
  }
}


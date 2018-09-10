import { AuthGuard } from './services/auth-guard.service';
import { UserFormComponent } from './Users/user-form/user-form.component';
import { UsersListComponent } from './Users/users-list/users-list.component';
import { AuthService } from './services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Login/Login.component';
import { PaginationComponent } from './shared/pagination/pagination.component';
import { UserService } from './services/user.service';
import { ViewUserComponent } from './Users/view-user/view-user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    UsersListComponent,
    PaginationComponent,
    UserFormComponent,
    ViewUserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'users/edit/:id', component: UserFormComponent, canActivate: [AuthGuard] },
      { path: 'users/new', component: UserFormComponent, canActivate: [AuthGuard] },
      { path: 'users/:id', component: ViewUserComponent, canActivate: [AuthGuard] },
      { path: 'users', component: UsersListComponent, canActivate: [AuthGuard] },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [AuthService, UserService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

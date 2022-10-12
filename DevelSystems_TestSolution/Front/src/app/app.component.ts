import { JwtHelperService } from '@auth0/angular-jwt';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private jwtHelper: JwtHelperService, private router: Router) { }

  ngOnInit(): void { }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem('jwt');
    if (token) {
      return !this.jwtHelper.isTokenExpired(token);
    }
    return false;
  }

  goHome= () => {
    this.router.navigateByUrl('/');
  }

  logOut = () => {
    localStorage.removeItem('jwt');
  }

  accessLogin = () => {
    this.router.navigateByUrl('/login');
  }
}

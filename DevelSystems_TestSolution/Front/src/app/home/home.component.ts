import { JwtHelperService } from '@auth0/angular-jwt';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private jwtHelper: JwtHelperService, private router: Router) { }

  ngOnInit(): void {
  }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem('jwt');
    if (token) {
      return !this.jwtHelper.isTokenExpired(token);
    }
    return false;
  }

  logOut = () => {
    localStorage.removeItem('jwt');
  }

  accessLogin = () => {
    this.router.navigateByUrl('/login');
  }

}

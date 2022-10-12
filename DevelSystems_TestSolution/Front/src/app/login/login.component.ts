import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AuthenticatedResponse } from './../_interfaces/auth-res.model';
import { LoginModel } from './../_interfaces/login.model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean = false;
  credentials: LoginModel = { username: '', password: '' };

  constructor(private router: Router, private http: HttpClient, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  login = (form: NgForm) => {
    if (form.valid) {
      this.http.post<AuthenticatedResponse>('https://localhost:7249/api/auth/login', this.credentials, {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      })
        .subscribe({
          next: (response: AuthenticatedResponse) => {
            const token = response.token;
            localStorage.setItem('jwt', token);
            this.invalidLogin = false;
            this.router.navigate(['/']);
          },
          error: (err: HttpErrorResponse) => {
            this.invalidLogin = true;
            this.openDialog("0ms", "0ms");
          }
        })
    }
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(DialogAlerta, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }
}

@Component({
  selector: 'dialog-alert',
  templateUrl: 'dialog-alert.html',
})
export class DialogAlerta {
  constructor(public dialogRef: MatDialogRef<DialogAlerta>) { }
}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { getToken } from '../app.module';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  encuestas: any;

  constructor(private router: Router, private http: HttpClient, public dialog: MatDialog) { }

  ngOnInit(): void {
    const token = localStorage.getItem('jwt');
    console.log(token);
    if (!token) {
      this.openDialog("0ms", "0ms");
      this.router.navigateByUrl('/login');
    }
    //this.http.get("https://localhost:7249/api/encuesta")
    //  .subscribe(res => {
    //    this.encuestas = res
    //  }, err => {
    //    console.log(err);
    //  });
  }

  goHome = () => {
    this.router.navigateByUrl('/');
  }

  logOut = () => {
    localStorage.removeItem('jwt');
    this.router.navigateByUrl('/');
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(AdminDialogAlerta, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }
}

@Component({
  selector: 'admin.component.dialog',
  templateUrl: 'admin.component.dialog.html',
})
export class AdminDialogAlerta {
  constructor(public dialogRef: MatDialogRef<AdminDialogAlerta>) { }
}

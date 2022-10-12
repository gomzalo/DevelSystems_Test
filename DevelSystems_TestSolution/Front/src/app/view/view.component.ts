import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { getToken } from '../app.module';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  encuestas: any;
  
  constructor(private router: Router, private http: HttpClient, public dialog: MatDialog) { }

  ngOnInit(): void {
    const token = localStorage.getItem('jwt');
    if (!token) {
      this.openDialog("0ms", "0ms");
      this.router.navigateByUrl('/login');
    }
    this.http.get("https://localhost:7249/api/encuesta")
      .subscribe(res => {
        this.encuestas = res
      }, err => {
        if (err.status == 401) {
          this.openDialog("0ms", "0ms");
          this.router.navigateByUrl('/login');
        }
        console.log(err);
      });
  }

  goHome = () => {
    this.router.navigateByUrl('/');
  }

  logOut = () => {
    localStorage.removeItem('jwt');
    this.router.navigateByUrl('/');
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(ViewDialogAlerta , {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }

}


@Component({
  selector: 'view.component.dialog',
  templateUrl: 'view.component.dialog.html',
})
export class ViewDialogAlerta {
  constructor(public dialogRef: MatDialogRef<ViewDialogAlerta>) { }
}

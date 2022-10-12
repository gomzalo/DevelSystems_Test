import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AuthenticatedResponse } from './../_interfaces/auth-res.model';
import { LoginModel } from './../_interfaces/login.model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog'
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-encuesta',
  templateUrl: './encuesta.component.html',
  styleUrls: ['./encuesta.component.css']
})
export class EncuestaComponent implements OnInit {
  id: string = '';
  
  constructor(private route: ActivatedRoute, private router: Router, private http: HttpClient, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      if (this.id != '') {
        this.http.get('https://localhost:7249/api/encuesta?id=' + this.id, {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        })
          .subscribe({
            next: (response: any) => {
              console.log(response);
            },
          });
      } else {
        this.openDialog("0ms", "0ms");
        this.router.navigateByUrl('/');
      }
      console.log(this.id);
    });
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(EncuestaDialogAlerta, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }

}

@Component({
  selector: 'encuesta.component.dialog',
  templateUrl: 'encuesta.component.dialog.html',
})
export class EncuestaDialogAlerta {
  constructor(public dialogRef: MatDialogRef<EncuestaDialogAlerta>) { }
}

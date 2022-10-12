import { HttpClient, HttpErrorResponse, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, NgModule, Input, ChangeDetectionStrategy, SimpleChanges, SimpleChange, OnChanges } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticatedResponse } from './../_interfaces/auth-res.model';
import { LoginModel } from './../_interfaces/login.model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog'
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';

interface JsonFormRespuesta {
  id: string;
  idEncuesta?: string;
  idPregunta?: string;
  nombre: string;
}

interface JsonFormPregunta {
  id: string;
  nombre: string;
  titulo: string;
  tipo: string;
  requerido: string;
  idEncuesta?: string;
  respuesta: JsonFormRespuesta[]
}

export interface JsonFormData {
  id: string;
  nombre: string;
  descripcion: string;
  pregunta: JsonFormPregunta[]
}

@Component({
  selector: 'app-encuesta',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './encuesta.component.html',
  styleUrls: ['./encuesta.component.css']
})
export class EncuestaComponent implements OnInit, OnChanges {
  respuestas: any[];
  id: string = '';
  @Input() jsonFormData: JsonFormData;
  public myForm: FormGroup = this.fb.group({});
  constructor(private route: ActivatedRoute, private router: Router, private http: HttpClient, public dialog: MatDialog, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      if (this.id != '') {
        this.http.get('https://localhost:7249/api/encuesta?id=' + this.id, {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        })
          .subscribe((formData: JsonFormData) => {
            this.jsonFormData = formData;
            console.log(this.jsonFormData)
            console.log(this.jsonFormData.pregunta)
          });
      } else {
        this.openDialog("0ms", "0ms");
        this.router.navigateByUrl('/');
      }
      console.log(this.id);
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!changes['jsonFormData'].firstChange) {
      console.log(this.jsonFormData);
    }
  }

  createForm(preguntas: JsonFormPregunta[]) {
    for (const pregunta of preguntas) {
      //this.myForm.addControl(pregunta.nombre, pregunta.requerido);
    }
  }

  enviar = () => {
    console.log(this.jsonFormData);
    //try {
    //  this.http.post('https://localhost:7249/api/addAnswer', {
    //    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    //  })
    //    .subscribe({
    //      next: response => {
    //        this.router.navigate(['/']);
    //      },
    //      error: (err: HttpErrorResponse) => {
    //        this.openDialog("0ms", "0ms");
    //      }
    //    })
    //} catch {
    //  console.log("error");
    //}
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

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { LoginComponent, DialogAlerta } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent, AdminDialogAlerta } from './admin/admin.component';
import { ViewComponent, ViewDialogAlerta } from './view/view.component';
import { EncuestaComponent, EncuestaDialogAlerta } from './encuesta/encuesta.component';

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

export function getToken() {
  return localStorage.getItem('jwt');
}

export function setToken(jwt: any) {
  localStorage.setItem('jwt', jwt);
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    DialogAlerta,
    AdminComponent,
    AdminDialogAlerta,
    ViewComponent,
    ViewDialogAlerta,
    EncuestaComponent,
    EncuestaDialogAlerta
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    // Material imports
    MatInputModule,
    MatButtonModule,
    MatTabsModule,
    MatCardModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatDialogModule,
    MatIconModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
        allowedDomains: ["localhost:7249"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

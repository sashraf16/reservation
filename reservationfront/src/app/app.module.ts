import { BrowserModule } from "@angular/platform-browser";
import { NgModule, Component } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ReservationsComponent } from "./reservations/reservations.component";

import { RouterModule, Routes } from "@angular/router";
import { HomepageComponent } from "./homepage/homepage.component";

import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from '@angular/material/button';

import { HttpClientModule } from '@angular/common/http';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field'; 
import { MatNativeDateModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { MatIconModule } from '@angular/material/icon';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DisplayinfoComponent } from './displayinfo/displayinfo.component';

const approutes: Routes = [
  { path: "reservations", component: ReservationsComponent },
  { path: "homepage", component: HomepageComponent },
  { path: '', redirectTo: "/homepage", pathMatch: 'full' },
  { path: "displayinfo", component: DisplayinfoComponent } 
];

@NgModule({
  declarations: [AppComponent, ReservationsComponent, HomepageComponent, DisplayinfoComponent],
  imports: [
    RouterModule.forRoot(approutes), 
    BrowserModule, 
    AppRoutingModule, 
    MatCardModule, 
    MatButtonModule, 
    HttpClientModule, 
    MatDatepickerModule, 
    MatFormFieldModule, 
    MatNativeDateModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}

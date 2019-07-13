import { BrowserModule } from "@angular/platform-browser";
import { NgModule, Component } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ReservationsComponent } from "./reservations/reservations.component";

import { RouterModule, Routes } from "@angular/router";
import { HomepageComponent } from "./homepage/homepage.component";

import { MatCardModule } from "@angular/material/card";
import {MatButtonModule} from '@angular/material/button';

import { HttpClientModule } from '@angular/common/http';
 
const approutes: Routes = [
  { path: "reservations", component: ReservationsComponent },
  { path: "homepage", component: HomepageComponent },
  { path: '', redirectTo: "/homepage", pathMatch: 'full' }
];

@NgModule({
  declarations: [AppComponent, ReservationsComponent, HomepageComponent],
  imports: [RouterModule.forRoot(approutes), BrowserModule, AppRoutingModule, MatCardModule, MatButtonModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}

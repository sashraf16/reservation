import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ReservationService } from '../reservation.service';
import { MatDatepickerInputEvent } from '@angular/material';
import { dateobj } from 'src/models/dateobj';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  constructor(private _service: ReservationService) { }

  results: any;
  picker: any;
  pickers: any;
  startDate: string;
  endDate: string;

  // selectedCamp: string;

  newDates: dateobj = {};
  

  day: string;
  month: string;
  tempmonth: number;
  year: string;

  ngOnInit() {
    // this.getFreeCamps();
  }

  // updateCamp(value: string) {
  //   console.log(value);
  //   this.selectedCamp = value;
  // }

  getFreeCamps() {
    this._service.retrieveFreeCamps().subscribe(
      data => {this.results = data}
    );
  }

  @Output() campEvent = new EventEmitter<string>();

  sendCamp(value: string) {
    this.campEvent.emit(value)
  }

//2019-07-07
  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    // this.events.push(`${type}: ${event.value}`);
    // console.log(event.value.getMonth().toString() + "to string");
    // console.log(event.value. + "to string2");

    this.day = event.value.getDate().toString();
    this.month = event.value.getMonth().toString();
    this.tempmonth = event.value.getMonth() + 1 ;
    this.year = event.value.getFullYear().toString();

    if (event.value.getDate() < 10)
    {
      this.day = "0"+this.day;
    }

    if (this.tempmonth < 10)
    {
      this.month = "0"+ this.tempmonth;
    }

    this.startDate = this.year+"-"+this.month+"-"+this.day;
  }
  addEvent2(type: string, event: MatDatepickerInputEvent<Date>) {

   this.day = event.value.getDate().toString();
   this.month = event.value.getMonth().toString();
   this.tempmonth = event.value.getMonth() + 1 ;
   this.year = event.value.getFullYear().toString();

   if (event.value.getDate() < 10)
   {
     this.day = "0"+this.day;
   }

   if (this.tempmonth < 10)
   {
     this.month = "0"+ this.tempmonth;
   }

   this.endDate = this.year+"-"+this.month+"-"+this.day;
  }

  updateDates() {
    if (this.startDate != undefined && this.endDate != undefined) {
      this.newDates.startDate = this.startDate;
      this.newDates.endDate = this.endDate;
    }
    else {
      console.log("please select dates");
    }

    this._service.updateWantDates(this.newDates).subscribe(
       data => {console.log(data)}
    );
  }


}

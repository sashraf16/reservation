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
    console.log(event.value.getMonth().toString() + "to string");
    // console.log(event.value. + "to string2");

    this.day = event.value.getDate().toString();
    this.month = event.value.getMonth().toString();
    this.tempmonth = event.value.getMonth() + 1 ;
    this.year = event.value.getFullYear().toString();

    console.log("month:" + this.month);
    console.log("day" + this.day);
    console.log("year" + this.year);

    if (event.value.getDate() < 10)
    {
      this.day = "0"+this.day;
    }

    if (this.tempmonth < 10)
    {
      this.month = "0"+ this.tempmonth;
    }

    this.startDate = this.year+"-"+this.month+"-"+this.day;
    console.log(this.startDate); 
  }
  addEvent2(type: string, event: MatDatepickerInputEvent<Date>) {
   // this.events.push(`${type}: ${event.value}`);
   console.log(event.value.getMonth().toString() + "to string");
   // console.log(event.value. + "to string2");

   this.day = event.value.getDate().toString();
   this.month = event.value.getMonth().toString();
   this.tempmonth = event.value.getMonth() + 1 ;
   this.year = event.value.getFullYear().toString();

   console.log("month:" + this.month);
   console.log("day" + this.day);
   console.log("year" + this.year);

   if (event.value.getDate() < 10)
   {
     this.day = "0"+this.day;
   }

   if (this.tempmonth < 10)
   {
     this.month = "0"+ this.tempmonth;
   }

   this.endDate = this.year+"-"+this.month+"-"+this.day;
   console.log(this.endDate); 
  }

  updateDates() {
    if (this.startDate != undefined && this.endDate != undefined)
    {
      this.newDates.startDate = "hello";
      this.newDates.endDate = "hello2";

      console.log(this.newDates.startDate);
      console.log(this.newDates.endDate);

      this.newDates.startDate = this.startDate;
      this.newDates.endDate = this.endDate;
    }

    else{
      console.log("please select dates");
    }

    console.log(this.newDates.startDate + "start date")
    console.log(this.newDates.endDate + "end date");

    this._service.updateWantDates(this.newDates).subscribe(
       data => {console.log(data)}
    );
  }


}

import { Component, OnInit } from '@angular/core';
import { ReservationService } from '../reservation.service';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  constructor(private _service: ReservationService) { }

  results: any;

  ngOnInit() {
    this.getFreeCamps();
  }

  getFreeCamps() {
    this._service.retrieveFreeCamps().subscribe(
      data => {this.results = data}
    );
  }

}

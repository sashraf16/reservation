import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of } from 'rxjs';
import { dateobj } from 'src/models/dateobj';

@Injectable({
  providedIn: "root"
})
export class ReservationService {
  constructor(private _http: HttpClient) {}

  retrieveFreeCamps() {
    return this._http.get("http://localhost:5000/api/values");
  }

  updateWantDates(dateobj: dateobj) {
    console.log(dateobj);
    return this._http.post("http://localhost:5000/api/values", dateobj);
  }
}

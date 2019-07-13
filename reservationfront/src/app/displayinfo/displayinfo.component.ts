import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-displayinfo',
  templateUrl: './displayinfo.component.html',
  styleUrls: ['./displayinfo.component.css']
})
export class DisplayinfoComponent implements OnInit {

  constructor() { }

  selectedCamp:string;

  receiveCamp($event){
    this.selectedCamp = $event;
  }

  ngOnInit() {
  }

}

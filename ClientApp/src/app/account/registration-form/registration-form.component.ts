import { Component, OnInit } from '@angular/core';
import { stringify } from '@angular/core/src/render3/util';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationFormComponent implements OnInit {


  model: {
    firstName: string,
    lastName: string,
    email: string,
    password: string
  };

  constructor() {
    this.model = { firstName: null, lastName: null, email: null, password: null};
  }

  ngOnInit() {
  }

}

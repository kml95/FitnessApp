import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-body-fat-calculator',
  templateUrl: './body-fat-calculator.component.html',
  styleUrls: ['./body-fat-calculator.component.scss']
})
export class BodyFatCalculatorComponent implements OnInit {

  model: {
    sex: string,
    weight: number,
    waist: number,
  };

  constructor() {
    this.model = { sex: null, weight: null, waist: null };
   }

  ngOnInit() {
  }

  onSubmit() {

  }

}

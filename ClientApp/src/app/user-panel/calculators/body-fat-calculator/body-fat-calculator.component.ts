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

  result = false;
  bodyfat: number;

  constructor() {
    this.model = { sex: null, weight: null, waist: null };
   }

  ngOnInit() {
  }

  onSubmit() {
    const a = 4.15 * this.model.waist;
    const b = a / 2.54;
    const c = 0.082 * this.model.weight * 2.2;
    let d;
    if (this.model.sex === 'male') {
      d = b - c - 98.42;
    } else {
      d = b - c - 76.76;
    }
    const e = this.model.weight * 2.2;
    this.bodyfat = Math.round(d / e * 100);

    this.result = true;
  }

}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bmrcalculator',
  templateUrl: './bmrcalculator.component.html',
  styleUrls: ['./bmrcalculator.component.scss']
})
export class BMRCalculatorComponent implements OnInit {

  model: {
    sex: string,
    weight: number,
    height: number,
    age: number
  };

  constructor() {
    this.model = { sex: null, weight: null, height: null, age: null };
   }

  ngOnInit() {
  }

  onSubmit(tmp) {
    let bmr: number;
    if (this.model.sex === 'male') {
      bmr = 66.47 + (13.75 * this.model.weight) + (5 * this.model.height) - (6.75 * this.model.age);
    } else {
      bmr = 665.09 + (9.56 * this.model.weight) + (1.85 * this.model.height) - (4.67 * this.model.age);
    }

    console.log(Math.round(bmr));
    console.log(tmp);
  }

}

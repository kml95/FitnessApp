import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bmicalculator',
  templateUrl: './bmicalculator.component.html',
  styleUrls: ['./bmicalculator.component.scss']
})
export class BMICalculatorComponent implements OnInit {

  model: {
    sex: string,
    weight: number,
    height: number,
  };

  result = false;
  bmi: number;

  constructor() {
    this.model = { sex: null, weight: null, height: null };
   }

  ngOnInit() {
  }

  onSubmit() {
    this.bmi =  Math.round(this.model.weight / ((this.model.height / 100) * (this.model.height / 100)) * 10) / 10;
    this.result = true;
  }

}

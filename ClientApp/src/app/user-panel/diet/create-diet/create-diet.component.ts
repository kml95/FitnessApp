import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-diet',
  templateUrl: './create-diet.component.html',
  styleUrls: ['./create-diet.component.scss']
})
export class CreateDietComponent implements OnInit {

  dietType: DietType;
  showDietForm = false;
  showMainPage = true;

  model: {
    sex: string,
    weight: number,
    height: number,
    age: number
  };

  constructor(private router: Router) {
    this.model = { sex: 'male', weight: null, height: null, age: null };
   }

  ngOnInit() {
  }

  onSubmit() {
    let bmr: number;
    if (this.model.sex === 'male') {
      bmr = 66.47 + (13.75 * this.model.weight) + (5 * this.model.height) - (6.75 * this.model.age);
    } else {
      bmr = 665.09 + (9.56 * this.model.weight) + (1.85 * this.model.height) - (4.67 * this.model.age);
    }

    let calories: number;
    if (this.dietType === 1) {
      calories = Math.round(bmr + (0.1 * bmr) + (0.3 * bmr) + 600);
    } else if (this.dietType === 2) {
      calories = Math.round(bmr + (0.1 * bmr) + (0.3 * bmr));
    } else {
      calories = Math.round(bmr + (0.1 * bmr) + (0.3 * bmr) + 300);
    }


    this.router.navigate(['/user-panel']);

    console.log(this.dietType);
    console.log(calories);
  }
}

enum DietType {
  Mass = 1,
  Reduction = 2,
  Maintemamce = 3
}


import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NumberValueAccessor } from '@angular/forms/src/directives';
import { DietService } from 'src/app/shared/services/diet.service';

@Component({
  selector: 'app-create-diet',
  templateUrl: './create-diet.component.html',
  styleUrls: ['./create-diet.component.scss']
})
export class CreateDietComponent implements OnInit {

  dietType: DietType;
  dietName: string;
  showDietForm = false;
  showMainPage = true;

  model: {
    sex: string,
    weight: number,
    height: number,
    age: number,
    mealsAmount: number
  };

  constructor(private dietService: DietService, private router: Router) {
    this.model = { sex: null, weight: null, height: null, age: null, mealsAmount: null };
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
    if (this.dietType === DietType.Mass) {
      calories = Math.round(bmr + (0.1 * bmr) + (0.3 * bmr) + 600);
      this.dietName = 'Wzrost masy mięśniowej';
    } else if (this.dietType === DietType.Reduction) {
      calories = Math.round(bmr + (0.1 * bmr) + (0.3 * bmr));
      this.dietName = 'Rzeźba mięśni';
    } else {
      calories = Math.round(bmr + (0.1 * bmr) + (0.3 * bmr) + 300);
      this.dietName = 'Utrzymani wagi';
    }

    this.dietService.create(this.dietName, calories, this.model.mealsAmount)
    .subscribe(() => {
      console.log('Udało się pomyślnie stworzyć');
      this.router.navigate(['/panel-uzytkownika/dieta']);
    });
  }
}

enum DietType {
  Mass = 1,
  Reduction = 2,
  Maintenance = 3
}


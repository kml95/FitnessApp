import { Component, OnInit } from '@angular/core';
import { DietService } from 'src/app/shared/services/diet.service';
import { MealsProducts } from 'src/app/shared/models/meals-products.interface';

@Component({
  selector: 'app-user-diet',
  templateUrl: './user-diet.component.html',
  styleUrls: ['./user-diet.component.scss']
})
export class UserDietComponent implements OnInit {

  mealsProducts: MealsProducts [];

  constructor(private dietService: DietService) { }

  ngOnInit() {
    this.dietService.get().subscribe(mealsProducts => this.mealsProducts = mealsProducts);
  }

}

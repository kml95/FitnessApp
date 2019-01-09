import { Component, OnInit } from '@angular/core';
import { DietService } from 'src/app/shared/services/diet.service';
import { Diet } from 'src/app/shared/models/diet.interface';

@Component({
  selector: 'app-user-diet',
  templateUrl: './user-diet.component.html',
  styleUrls: ['./user-diet.component.scss']
})
export class UserDietComponent implements OnInit {

  diet: Diet;
  model = new Array<Meal>();

  constructor(private dietService: DietService) { }

  ngOnInit() {
    this.dietService.get().subscribe(diet => {
      this.diet = diet;

      for (let index = 0; index < this.diet.meals.length; index++) {
        const proportions = this.diet.meals[index].proportions.split(';').map(item => {
          const tmp = (parseFloat(item) * 100) * (this.diet.calories / 2000);
          return Math.round(tmp);
        });

        const name = this.diet.meals[index].name;
        const type = this.diet.meals[index].type;
        const photo = this.diet.meals[index].photo;
        let tmpProducts = new Array<Product>();

        for (let index2 = 0; index2 < this.diet.meals[index].productsNames.length; index2++) {
          const tmp = new Product(
            this.diet.meals[index].productsNames[index2],
            proportions[index2]
          );
          tmpProducts.push(tmp);
        }
        const tmpMeal = new Meal(name, type, photo, tmpProducts);
        this.model.push(tmpMeal);
        tmpProducts = [];
      }
    });
  }
}

class Meal {
  constructor(
    public name: string,
    public type: string,
    public photo: string,
    public products: Product []) { }
}

class Product {
  constructor(
  public name: string,
  public value: number) { }
}

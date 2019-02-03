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
      let tmpProducts = new Array<Product>();

      switch (diet.mealsAmount) {
        case 3:
          const breakfastProportions = diet.meals[0].proportions.split(';').map(item => {
            const tmp = (parseFloat(item) * 100) * (diet.calories / 2000) * (35 / 30);
            return Math.round(tmp);
          });

          for (let index = 0; index < diet.meals[0].productsNames.length; index++) {
            tmpProducts.push(new Product(diet.meals[0].productsNames[index], breakfastProportions[index]));
          }
          this.model.push(new Meal(diet.meals[0].name, diet.meals[0].type, diet.meals[0].photo, tmpProducts));
          tmpProducts = [];

          const dinnnerProportions = diet.meals[1].proportions.split(';').map(item => {
            const tmp = (parseFloat(item) * 100) * (diet.calories / 2000) * (40 / 35);
            return Math.round(tmp);
          });

          for (let index = 0; index < diet.meals[1].productsNames.length; index++) {
            tmpProducts.push(new Product(diet.meals[1].productsNames[index], dinnnerProportions[index]));
          }
          this.model.push(new Meal(diet.meals[1].name, diet.meals[1].type, diet.meals[1].photo, tmpProducts));
          tmpProducts = [];

          const supperProportions = diet.meals[2].proportions.split(';').map(item => {
            const tmp = (parseFloat(item) * 100) * (diet.calories / 2000) * (25 / 15);
            return Math.round(tmp);
          });

          for (let index = 0; index < diet.meals[2].productsNames.length; index++) {
            tmpProducts.push(new Product(diet.meals[2].productsNames[index], supperProportions[index]));
          }
          this.model.push(new Meal(diet.meals[2].name, diet.meals[2].type, diet.meals[2].photo, tmpProducts));
          break;
        case 4:
          for (let index = 0; index < diet.meals.length; index++) {
            // tslint:disable-next-line:no-shadowed-variable
            let supperProportions;
            let proportions;
            if (index === diet.meals.length - 1) {
              supperProportions = diet.meals[index].proportions.split(';').map(item => {
                const tmp = (parseFloat(item) * 100) * (diet.calories / 2000) * (25 / 15);
                return Math.round(tmp);
              });

              for (let index2 = 0; index2 < diet.meals[index].productsNames.length; index2++) {
                tmpProducts.push(new Product(diet.meals[index].productsNames[index2], supperProportions[index2]));
              }
              this.model.push(new Meal(diet.meals[index].name, diet.meals[index].type, diet.meals[index].photo, tmpProducts));
              break;
            } else {
              proportions = diet.meals[index].proportions.split(';').map(item => {
                const tmp = (parseFloat(item) * 100) * (diet.calories / 2000);
                return Math.round(tmp);
              });
            }

            for (let index2 = 0; index2 < diet.meals[index].productsNames.length; index2++) {
              tmpProducts.push(new Product(diet.meals[index].productsNames[index2], proportions[index2]));
            }
            this.model.push(new Meal(diet.meals[index].name, diet.meals[index].type, diet.meals[index].photo, tmpProducts));
            tmpProducts = [];
          }
          break;
        case 5:
          for (let index = 0; index < diet.meals.length; index++) {
            const proportions = diet.meals[index].proportions.split(';').map(item => {
              const tmp = (parseFloat(item) * 100) * (diet.calories / 2000);
              return Math.round(tmp);
            });

            for (let index2 = 0; index2 < diet.meals[index].productsNames.length; index2++) {
              tmpProducts.push(new Product(diet.meals[index].productsNames[index2], proportions[index2]));
            }
            this.model.push(new Meal(diet.meals[index].name, diet.meals[index].type, diet.meals[index].photo, tmpProducts));
            tmpProducts = [];
          }
          break;
        default:
          console.log('Incorrect numbers of meals. Create a diet failed!');
          break;
      }
    }, (error) => this.diet = null);
  }
}

class Meal {
  constructor(
    public name: string,
    public type: string,
    public photo: string,
    public products: Product[]) { }
}

class Product {
  constructor(
    public name: string,
    public value: number) { }
}

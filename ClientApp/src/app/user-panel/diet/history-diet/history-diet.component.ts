import { Component, OnInit } from '@angular/core';
import { DietService } from 'src/app/shared/services/diet.service';
import { Diet } from 'src/app/shared/models/diet.interface';

@Component({
  selector: 'app-history-diet',
  templateUrl: './history-diet.component.html',
  styleUrls: ['./history-diet.component.scss']
})
export class HistoryDietComponent implements OnInit {
  diet: Diet[];
  model = new Array<Meal>();
  ifDiet: boolean;

  constructor(private dietService: DietService) { this.ifDiet = false; }

  ngOnInit() {
    this.dietService.getLast(5).subscribe(diet => {
      this.diet = diet;
    }, (error) => this.diet = null);
  }

  showDiet(page: number) {
    this.model = [];
    let tmpProducts = new Array<Product>();

    switch (this.diet[page].mealsAmount) {
      case 3:
        const breakfastProportions = this.diet[page].meals[0].proportions.split(';').map(item => {
          const tmp = (parseFloat(item) * 100) * (this.diet[page].calories / 2000) * (35 / 30);
          return Math.round(tmp);
        });

        for (let index = 0; index < this.diet[page].meals[0].productsNames.length; index++) {
          tmpProducts.push(new Product(this.diet[page].meals[0].productsNames[index], breakfastProportions[index]));
        }
        this.model.push(new Meal(
          this.diet[page].meals[0].name,
          this.diet[page].meals[0].type,
          this.diet[page].meals[0].photo,
          tmpProducts));
        tmpProducts = [];

        const dinnnerProportions = this.diet[page].meals[1].proportions.split(';').map(item => {
          const tmp = (parseFloat(item) * 100) * (this.diet[page].calories / 2000) * (40 / 35);
          return Math.round(tmp);
        });

        for (let index = 0; index < this.diet[page].meals[1].productsNames.length; index++) {
          tmpProducts.push(new Product(this.diet[page].meals[1].productsNames[index], dinnnerProportions[index]));
        }
        this.model.push(new Meal(
          this.diet[page].meals[1].name,
          this.diet[page].meals[1].type,
          this.diet[page].meals[1].photo,
          tmpProducts));
        tmpProducts = [];

        const supperProportions = this.diet[page].meals[2].proportions.split(';').map(item => {
          const tmp = (parseFloat(item) * 100) * (this.diet[page].calories / 2000) * (25 / 15);
          return Math.round(tmp);
        });

        for (let index = 0; index < this.diet[page].meals[2].productsNames.length; index++) {
          tmpProducts.push(new Product(this.diet[page].meals[2].productsNames[index], supperProportions[index]));
        }
        this.model.push(new Meal(
          this.diet[page].meals[2].name,
          this.diet[page].meals[2].type,
          this.diet[page].meals[2].photo,
          tmpProducts));
        break;
      case 4:
        for (let index = 0; index < this.diet[page].meals.length; index++) {
          // tslint:disable-next-line:no-shadowed-variable
          let supperProportions;
          let proportions;
          if (index === this.diet[page].meals.length - 1) {
            supperProportions = this.diet[page].meals[index].proportions.split(';').map(item => {
              const tmp = (parseFloat(item) * 100) * (this.diet[page].calories / 2000) * (25 / 15);
              return Math.round(tmp);
            });

            for (let index2 = 0; index2 < this.diet[page].meals[index].productsNames.length; index2++) {
              tmpProducts.push(new Product(this.diet[page].meals[index].productsNames[index2], supperProportions[index2]));
            }
            this.model.push(new Meal(
              this.diet[page].meals[index].name,
              this.diet[page].meals[index].type,
              this.diet[page].meals[index].photo,
              tmpProducts));
            break;
          } else {
            proportions = this.diet[page].meals[index].proportions.split(';').map(item => {
              const tmp = (parseFloat(item) * 100) * (this.diet[page].calories / 2000);
              return Math.round(tmp);
            });
          }

          for (let index2 = 0; index2 < this.diet[page].meals[index].productsNames.length; index2++) {
            tmpProducts.push(new Product(this.diet[page].meals[index].productsNames[index2], proportions[index2]));
          }
          this.model.push(new Meal(
            this.diet[page].meals[index].name,
            this.diet[page].meals[index].type,
            this.diet[page].meals[index].photo,
            tmpProducts));
          tmpProducts = [];
        }
        break;
      case 5:
        for (let index = 0; index < this.diet[page].meals.length; index++) {
          const proportions = this.diet[page].meals[index].proportions.split(';').map(item => {
            const tmp = (parseFloat(item) * 100) * (this.diet[page].calories / 2000);
            return Math.round(tmp);
          });

          for (let index2 = 0; index2 < this.diet[page].meals[index].productsNames.length; index2++) {
            tmpProducts.push(new Product(this.diet[page].meals[index].productsNames[index2], proportions[index2]));
          }
          this.model.push(new Meal(
            this.diet[page].meals[index].name,
            this.diet[page].meals[index].type,
            this.diet[page].meals[index].photo,
            tmpProducts));
          tmpProducts = [];
        }
        break;
      default:
        console.log('Incorrect numbers of meals. Create a diet failed!');
        break;
    }
    this.ifDiet = true;
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

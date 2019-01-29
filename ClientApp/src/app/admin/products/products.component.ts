import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/shared/services/product.service';
import { NgForm } from '@angular/forms';
import { ProductCategory } from 'src/app/shared/models/product.interface';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: Product[];
  count: number;
  pages: number;
  itemsPerPage = 7;
  currentPage = 1;
  index = 1;
  createAlert: boolean;
  editedAlert: boolean;
  editedName: string;

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.count().subscribe(result => {
      this.count = result;
      if (this.count !== 0) {
        this.productService.getRange(0, 7).subscribe(products => {
          this.products = products;
        });
      }
      if (this.count % this.itemsPerPage === 0) {
        this.pages = Math.floor(this.count / this.itemsPerPage);
      } else {
        this.pages = Math.floor(this.count / this.itemsPerPage) + 1;
      }
    });
  }

  getProducts(page: number) {
    this.productService.getRange((page - 1) * this.itemsPerPage, 7).subscribe(products => {
      this.products = products;
    });
    if (!(this.index + 3 === this.pages) && !(this.index - page === 0) && !(this.pages === page)) {
      this.index = page - 1;
    }
    if ((this.index - page === 0) && page !== 1) {
      this.index = page - 1;
    }
    this.currentPage = page;
  }

  createProduct(form: NgForm) {
    this.productService.create(
      form.value.name,
      form.value.calories,
      form.value.carbohydrates,
      form.value.protein,
      form.value.fat,
      form.value.category)
    .subscribe(product => {
      this.createAlert = true;
    });
  }

  resetAddForm(form: NgForm) {
    form.setValue({
      name: '',
      calories: '',
      carbohydrates: '',
      protein: '',
      fat: '',
      category: ''});
  }

  initEditForm(editForm: NgForm, product: Product) {
    this.editedName = product.name;
    editForm.setValue({
       name: product.name,
       calories: product.calories,
       carbohydrates: product.carbohydrates,
       protein: product.protein,
       fat: product.fat,
       category: product.category});
  }

  editProduct(form: NgForm) {
    this.productService.getIdByName(this.editedName).subscribe(id => {
      this.productService.update(
        id,
        new Product(
          form.value.name,
          form.value.calories,
          form.value.carbohydrates,
          form.value.protein,
          form.value.fat,
          form.value.category))
      .subscribe(product => {
        this.editedAlert = true;
        this.productService.getRange((this.currentPage - 1) * this.itemsPerPage, 7).subscribe(products => {
          this.products = products;
        });
      });
    });
  }

  deleteProduct(name: string) {
    this.productService.getIdByName(name).subscribe(id => {
      this.productService.delete(id).subscribe(exercise => {
        this.productService.getRange((this.currentPage - 1) * this.itemsPerPage, 7).subscribe(products => {
          this.products = products;
        });
      });
    });
  }
}

class Product {
  constructor(
    public name: string,
    public calories: number,
    public carbohydrates: number,
    public protein: number,
    public fat: number,
    public category: ProductCategory) { }
}

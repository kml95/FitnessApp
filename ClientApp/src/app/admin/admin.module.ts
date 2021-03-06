import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { MealsComponent } from './meals/meals.component';
import { ExercisesComponent } from './exercises/exercises.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminDetailsComponent } from './admin-details/admin-details.component';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from '../auth.guard';
import { AdminRoutingModule } from './admin-routing.module';
import { ProductService } from '../shared/services/product.service';
import { ExerciseService } from '../shared/services/exercise.service';
import { AdminGuard } from '../admin.guard';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AdminRoutingModule
  ],
  declarations: [
    UsersComponent,
    ProductsComponent,
    MealsComponent,
    ExercisesComponent,
    AdminHomeComponent,
    AdminDetailsComponent
  ],
  providers: [
    ProductService,
    ExerciseService,
    AdminGuard
   ],
})
export class AdminModule { }

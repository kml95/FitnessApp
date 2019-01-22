import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AuthGuard } from '../auth.guard';
import { AdminDetailsComponent } from './admin-details/admin-details.component';
import { ProductsComponent } from './products/products.component';
import { MealsComponent } from './meals/meals.component';
import { UsersComponent } from './users/users.component';
import { ExercisesComponent } from './exercises/exercises.component';
import { AdminGuard } from '../admin.guard';

const routes: Routes = [
  {
    path: '',
    component: AdminHomeComponent,
    canActivate: [AdminGuard],
    children: [
     { path: '', redirectTo: 'o-mnie'},
     { path: 'o-mnie', component: AdminDetailsComponent},
     { path: 'uzytkownicy', component: UsersComponent},
     { path: 'produkty', component: ProductsComponent},
     { path: 'posilki', component: MealsComponent},
     { path: 'cwiczenia', component: ExercisesComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

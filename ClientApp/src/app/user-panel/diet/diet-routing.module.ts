import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateDietComponent } from './create-diet/create-diet.component';

const routes: Routes = [
  {
    path: 'user-panel/dieta',
    component: CreateDietComponent,
    children: []
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DietRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalculatorsComponent } from './calculators.component';
import { BMRCalculatorComponent } from './bmrcalculator/bmrcalculator.component';
import { HomeComponent } from 'src/app/user-panel/calculators/home/home.component';

const routes: Routes = [
  {
    path: 'user-panel/calculators',
    component: CalculatorsComponent,
    children: [
      { path: '', component: HomeComponent},
      { path: 'bmr', component: BMRCalculatorComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CalculatorsRoutingModule { }

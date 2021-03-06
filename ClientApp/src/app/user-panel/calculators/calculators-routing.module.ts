import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BMRCalculatorComponent } from './bmrcalculator/bmrcalculator.component';
import { BMICalculatorComponent } from './bmicalculator/bmicalculator.component';
import { HomeComponent } from 'src/app/user-panel/calculators/home/home.component';
import { BodyFatCalculatorComponent } from './body-fat-calculator/body-fat-calculator.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      { path: '', component: HomeComponent},
      { path: 'bmr', component: BMRCalculatorComponent},
      { path: 'bmi', component: BMICalculatorComponent},
      { path: 'bf', component: BodyFatCalculatorComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CalculatorsRoutingModule { }

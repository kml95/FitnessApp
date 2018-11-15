import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CalculatorsRoutingModule } from './calculators-routing.module';
import { BMRCalculatorComponent } from './bmrcalculator/bmrcalculator.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { BMICalculatorComponent } from './bmicalculator/bmicalculator.component';
import { BodyFatCalculatorComponent } from './body-fat-calculator/body-fat-calculator.component';
import { MainComponent } from './main/main.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CalculatorsRoutingModule
  ],
  declarations: [
    BMRCalculatorComponent,
    HomeComponent,
    MainComponent,
    BMICalculatorComponent,
    BodyFatCalculatorComponent
  ]
})

export class CalculatorsModule {
 }

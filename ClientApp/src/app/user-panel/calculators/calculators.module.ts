import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CalculatorsRoutingModule } from './calculators-routing.module';
import { BMRCalculatorComponent } from './bmrcalculator/bmrcalculator.component';
import { CalculatorsComponent } from './calculators.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CalculatorsRoutingModule
  ],
  declarations: [BMRCalculatorComponent, CalculatorsComponent, HomeComponent]
})
export class CalculatorsModule {
 }

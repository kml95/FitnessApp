import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DietRoutingModule } from './diet-routing.module';
import { CreateDietComponent } from './create-diet/create-diet.component';

@NgModule({
  imports: [
    CommonModule,
    DietRoutingModule
  ],
  declarations: [CreateDietComponent]
})
export class DietModule { }

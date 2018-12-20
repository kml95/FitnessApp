import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DietRoutingModule } from './diet-routing.module';
import { CreateDietComponent } from './create-diet/create-diet.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DietRoutingModule
  ],
  declarations: [CreateDietComponent]
})
export class DietModule { }

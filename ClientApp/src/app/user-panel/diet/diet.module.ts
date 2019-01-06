import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DietRoutingModule } from './diet-routing.module';
import { CreateDietComponent } from './create-diet/create-diet.component';
import { FormsModule } from '@angular/forms';
import { DietService } from 'src/app/shared/services/diet.service';
import { UserDietComponent } from './user-diet/user-diet.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DietRoutingModule
  ],
  declarations: [CreateDietComponent, UserDietComponent],
  providers: [DietService],
})
export class DietModule { }

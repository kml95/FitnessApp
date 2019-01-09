import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrainingRoutingModule } from './training-routing.module';
import { UserTrainingComponent } from './user-training/user-training.component';
import { CreateTrainingComponent } from './create-training/create-training.component';
import { FormsModule } from '@angular/forms';
import { TrainingService } from 'src/app/shared/services/training.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    TrainingRoutingModule
  ],
  declarations: [UserTrainingComponent, CreateTrainingComponent],
  providers: [TrainingService],
})
export class TrainingModule { }

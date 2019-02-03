import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrainingRoutingModule } from './training-routing.module';
import { UserTrainingComponent } from './user-training/user-training.component';
import { CreateTrainingComponent } from './create-training/create-training.component';
import { FormsModule } from '@angular/forms';
import { TrainingService } from 'src/app/shared/services/training.service';
import { HistoryTrainingComponent } from './history-training/history-training.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    TrainingRoutingModule
  ],
  declarations: [UserTrainingComponent, CreateTrainingComponent, HistoryTrainingComponent],
  providers: [TrainingService],
})
export class TrainingModule { }

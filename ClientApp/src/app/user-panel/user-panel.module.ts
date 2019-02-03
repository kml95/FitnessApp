import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { routing } from './user-panel.routing';
import { AuthGuard } from '../auth.guard';
import { UserDetailsComponent } from './user-details/user-details.component';
import { AnalysisComponent } from './analysis/analysis.component';
import { DietService } from '../shared/services/diet.service';
import { TrainingService } from '../shared/services/training.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    routing,
    // CalculatorsModule,
    // DietModule,
  ],
  declarations: [HomeComponent, UserDetailsComponent, AnalysisComponent],
  providers:    [AuthGuard, DietService, TrainingService]
})
export class UserPanelModule { }

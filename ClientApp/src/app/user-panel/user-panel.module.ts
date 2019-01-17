import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { routing } from './user-panel.routing';
import { AuthGuard } from '../auth.guard';
import { CalculatorsModule } from './calculators/calculators.module';
import { DietModule } from './diet/diet.module';
import { UserDetailsComponent } from './user-details/user-details.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    routing,
    // CalculatorsModule,
    // DietModule,
  ],
  declarations: [HomeComponent, UserDetailsComponent],
  providers:    [AuthGuard]
})
export class UserPanelModule { }

import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

import { AuthGuard } from '../auth.guard';
import { DietModule } from './diet/diet.module';
import { TrainingModule } from './training/training.module';
import { UserDetailsComponent } from './user-details/user-details.component';
import { CalculatorsModule } from './calculators/calculators.module';
import { AnalysisComponent } from './analysis/analysis.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
     { path: '', redirectTo: 'o-mnie'},
     { path: 'o-mnie', component: UserDetailsComponent},
     { path: 'dieta', loadChildren: () => DietModule},
     { path: 'trening', loadChildren: () => TrainingModule},
     { path: 'kalkulatory', loadChildren: () => CalculatorsModule},
     { path: 'suplementacja', loadChildren: () => CalculatorsModule},
     { path: 'analiza', component: AnalysisComponent}    ]
  },
]);

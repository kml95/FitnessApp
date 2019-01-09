import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

import { AuthGuard } from '../auth.guard';
import { DietModule } from './diet/diet.module';
import { TrainingModule } from './training/training.module';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
     { path: 'dieta', loadChildren: () => DietModule},
     { path: 'trening', loadChildren: () => TrainingModule},
    ]
  },
]);

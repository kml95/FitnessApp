import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

import { AuthGuard } from '../auth.guard';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'user-panel',
    component: HomeComponent,
    canActivate: [AuthGuard]
  }
  // {
  //   path: 'calculators',
  //   loadChildren: '../user-panel/calculators/calculators.module#CalculatorsModule'
  // }
]);

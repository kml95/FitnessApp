import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

import { AuthGuard } from '../auth.guard';
import { DietModule } from './diet/diet.module';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
    //   // { path: '', component: HomeComponent},
     { path: 'dieta', loadChildren: () => DietModule},
    //  { path: 'dieta', loadChildren: './diet/diet.module#DietModule'}
    //   // { path: 'bmi', component: BMICalculatorComponent},
    //   // { path: 'bf', component: BodyFatCalculatorComponent}
    ]
  },

]);

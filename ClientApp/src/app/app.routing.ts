import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginFormComponent } from './account/login-form/login-form.component';
import { AppComponent } from './app.component';

const appRoutes: Routes = [
  // { path: '', component: AppComponent },
  { path: 'login', component: LoginFormComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent}
  // { path: 'account', loadChildren: 'account/account.module#AccountModule'},
  // { path: 'user-panel', loadChildren: 'user-panel/user-panel.module#UserPanelModule'}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

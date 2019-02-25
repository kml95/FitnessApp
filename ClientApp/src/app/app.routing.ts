import { ModuleWithProviders, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { UserPanelModule } from './user-panel/user-panel.module';
import { AdminModule } from './admin/admin.module';

const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'panel-uzytkownika', loadChildren: () => UserPanelModule},
  { path: 'admin', loadChildren: () => AdminModule}
  // { path: 'account', loadChildren: 'account/account.module#AccountModule'},
  // { path: 'user-panel', loadChildren: './user-panel/user-panel.module#UserPanelModule'}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class Routing { }

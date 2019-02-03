import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateDietComponent } from './create-diet/create-diet.component';
import { UserDietComponent } from './user-diet/user-diet.component';
import { HistoryDietComponent } from './history-diet/history-diet.component';

const routes: Routes = [
  {
    path: '',
    component: UserDietComponent,
  },
  { path: 'stworz', component: CreateDietComponent},
  { path: 'historia', component: HistoryDietComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DietRoutingModule { }

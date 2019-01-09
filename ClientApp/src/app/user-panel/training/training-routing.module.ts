import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserTrainingComponent } from './user-training/user-training.component';
import { CreateTrainingComponent } from './create-training/create-training.component';

const routes: Routes = [
  {
    path: '',
    component: UserTrainingComponent,
  },
  { path: 'stworz', component: CreateTrainingComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrainingRoutingModule { }

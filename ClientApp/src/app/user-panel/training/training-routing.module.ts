import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserTrainingComponent } from './user-training/user-training.component';
import { CreateTrainingComponent } from './create-training/create-training.component';
import { HistoryTrainingComponent } from './history-training/history-training.component';

const routes: Routes = [
  {
    path: '',
    component: UserTrainingComponent,
  },
  { path: 'stworz', component: CreateTrainingComponent},
  { path: 'historia', component: HistoryTrainingComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrainingRoutingModule { }

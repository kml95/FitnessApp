import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { routing } from './user-panel.routing';
import { AuthGuard } from '../auth.guard';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    routing
  ],
  declarations: [HomeComponent],
  providers:    [AuthGuard]
})
export class UserPanelModule { }

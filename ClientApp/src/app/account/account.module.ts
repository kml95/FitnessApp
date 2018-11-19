import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { routing } from './account.routing';
import { UserService } from '../shared/services/user.service';
import { TransparentHeaderComponent } from '../transparent-header/transparent-header.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    routing,
  ],
  declarations: [
    RegistrationFormComponent,
    LoginFormComponent,
    // TransparentHeaderComponent
  ],
  providers: [ UserService ]
})
export class AccountModule { }

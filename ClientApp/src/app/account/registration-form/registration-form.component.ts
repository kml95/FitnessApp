import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationFormComponent implements OnInit {

  ifRegister: boolean;

  model: {
    firstName: string,
    lastName: string,
    email: string,
    password: string
  };

  constructor(private userService: UserService, private router: Router) {
    this.model = { firstName: null, lastName: null, email: null, password: null};
    this.ifRegister = false;
  }

  ngOnInit() {
  }

  registerUser(model: NgForm) {
    this.userService.register(model.value.email, model.value.password, model.value.firstName, model.value.lastName)
    .subscribe(() => this.ifRegister = true);
  }

}

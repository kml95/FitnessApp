import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Diet } from 'src/app/shared/models/diet.interface';
import { Training } from 'src/app/shared/models/training.interface';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-admin-details',
  templateUrl: './admin-details.component.html',
  styleUrls: ['./admin-details.component.scss']
})
export class AdminDetailsComponent implements OnInit {

  user: User;
  editedName: string;
  editedAlert = false;

  constructor(private userService: UserService) { }

  ngOnInit() {
    const userName = localStorage.getItem('userName');
    this.userService.getByUserName(localStorage.getItem('userName')).subscribe(user => {
      this.user = user;
    });
  }

  initEditForm(editForm: NgForm, user: User) {
    this.editedName = user.userName;
    editForm.setValue({
      firstName: user.firstName,
      lastName: user.lastName,
      userName: user.userName,
      email: user.email});
  }

  editUser(form: NgForm) {
    this.userService.getIdByUserName(this.editedName).subscribe(result => {
      this.userService.update(
        result.id,
        new User(
          form.value.firstName,
          form.value.lastName,
          form.value.userName,
          form.value.email))
      .subscribe(user => {
        this.editedAlert = true;
        localStorage.setItem('userName', form.value.userName);
        this.ngOnInit();
      });
    });
  }
}

class User {
  constructor(
    public firstName: string,
    public lastName: string,
    public userName: string,
    public email: string) { }
}

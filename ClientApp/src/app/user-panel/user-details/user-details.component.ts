import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { DietService } from 'src/app/shared/services/diet.service';
import { TrainingService } from 'src/app/shared/services/training.service';
import { Diet } from 'src/app/shared/models/diet.interface';
import { Training } from 'src/app/shared/models/training.interface';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent implements OnInit {

  user: User;
  diet: Diet;
  training: Training;
  allData = false;
  editedName: string;

  constructor(private userService: UserService, private dietService: DietService, private trainingService: TrainingService) { }

  ngOnInit() {
    const userName = localStorage.getItem('userName');
    this.userService.getByUserName(localStorage.getItem('userName')).subscribe(user => {
      this.user = user;
    });
    this.dietService.get().subscribe(diet => {
      this.diet = diet;
    });
    this.trainingService.get().subscribe(training => {
      this.training = training;
      this.allData = true;
    }, error => { this.allData = true; });
  }

  initEditForm(editForm: NgForm, user: User) {
    this.editedName = user.userName;
    editForm.setValue({
      firstName: user.firstName,
      lastName: user.lastName,
      userName: user.userName,
      email: user.email});
  }
}

class User {
  constructor(
    public firstName: string,
    public lastName: string,
    public userName: string,
    public email: string) { }
}

import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  users: User[];
  count: number;
  pages: number;
  itemsPerPage = 7;
  currentPage = 1;
  index = 1;
  createAlert: boolean;
  editedAlert: boolean;
  editedName: string;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.count().subscribe(result => {
      this.count = result;
      if (this.count !== 0) {
        this.userService.getRange(0, 7).subscribe(users => {
          this.users = users;
        });
      }
      if (this.count % this.itemsPerPage === 0) {
        this.pages = Math.floor(this.count / this.itemsPerPage);
      } else {
        this.pages = Math.floor(this.count / this.itemsPerPage) + 1;
      }
    });
  }

  getUsers(page: number) {
    this.userService.getRange((page - 1) * this.itemsPerPage, 7).subscribe(users => {
      this.users = users;
    });
    if (!(this.index + 3 === this.pages) && !(this.index - page === 0) && !(this.pages === page)) {
      this.index = page - 1;
    }
    if ((this.index - page === 0) && page !== 1) {
      this.index = page - 1;
    }
    this.currentPage = page;
  }

  createUser(form: NgForm) {
    this.userService.register(
      form.value.email,
      form.value.password,
      form.value.firstName,
      form.value.lastName)
    .subscribe(user => {
      this.createAlert = true;
      this.userService.getRange((this.currentPage - 1) * this.itemsPerPage, 7).subscribe(users => {
        this.users = users;
      });
    });
  }

  resetAddForm(form: NgForm) {
    form.setValue({ firstName: '', lastName: '', email: '', password: '' });
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
        this.userService.getRange((this.currentPage - 1) * this.itemsPerPage, 7).subscribe(users => {
          this.users = users;
        });
      });
    });
  }

  deleteUser(name: string) {
    this.userService.getIdByUserName(name).subscribe(result => {
      this.userService.delete(result.id).subscribe(exercise => {
        this.userService.getRange((this.currentPage - 1) * this.itemsPerPage, 7).subscribe(users => {
          this.users = users;
        });
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

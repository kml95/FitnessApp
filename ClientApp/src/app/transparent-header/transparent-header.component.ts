import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-transparent-header',
  templateUrl: './transparent-header.component.html',
  styleUrls: ['./transparent-header.component.scss']
})
export class TransparentHeaderComponent implements OnInit, OnDestroy {

  status: boolean;
  isAdmin: boolean;
  subscription: Subscription;
  route: string;

  login = '/login'; register = '/register';


  constructor(private userService: UserService, private location: Location, private router: Router) { }

  logout() {
    this.userService.logout();
  }

  ngOnInit() {
    this.router.events.subscribe((val) => {
      if (this.location.path() !== '') {
        this.route = this.location.path();
      } else {
        this.route = '';
      }
    });
    this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);
    this.userService.adminNav$.subscribe(isAdmin => this.isAdmin = isAdmin);
    console.log(this.isAdmin);
  }


  ngOnDestroy() {
    // prevent memory leak when component is destroyed
    this.subscription.unsubscribe();
  }

}

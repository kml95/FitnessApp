import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';

import { UserRegistration } from '../models/user.registration.interface';
import { ConfigService } from '../utils/config.service';

import { BaseService } from './base.service';

import { Observable, BehaviorSubject } from 'rxjs';

import { catchError, debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';

@Injectable()

export class UserService extends BaseService {

  private baseUrl = '';

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private adminNavSource = new BehaviorSubject<boolean>(false);
  adminNav$ = this.adminNavSource.asObservable();

  private loggedIn = false;
  private isAdmin = false;

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    this.isAdmin = localStorage.getItem('role') === 'Admin';
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.adminNavSource.next(this.isAdmin);
    this.baseUrl = configService.getApiURI();
  }

  register(email: string, password: string, firstName: string, lastName: string): Observable<Response> {
    const body = { email, password, firstName, lastName };
    return this.http.post<Response>(`${this.baseUrl}/accounts/register`, body);
  }

  login(userName, password): Observable<any> {
    return this.http.post<any>(this.baseUrl + '/auth/login', JSON.stringify({ userName, password }), this.httpOptions).pipe(
      map(res => {
        localStorage.setItem('auth_token', res.Auth_token);
        localStorage.setItem('role', res.Role);
        // localStorage.setItem('role', res.Role);
        if (res.Role === 'Admin') {
          this.isAdmin = true;
          this.adminNavSource.next(true);
        }
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      }),
      catchError(this.handleError)
    );
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this.isAdmin = false;
    this.adminNavSource.next(false);
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  isAdminLoggedIn() {
    return this.isAdmin;
  }

}

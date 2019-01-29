import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Exercise, Muscle } from '../models/exercise.interface';
import { Product } from '../models/product.interface';

@Injectable()
export class ExerciseService extends BaseService {

  private baseUrl = '';

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  create(name: string, stage: number, muscle: Muscle): Observable<Exercise> {
    const body = { name, stage, muscle};
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.post<Exercise>(`${this.baseUrl}/exercises/create`, body, {headers});
  }

  get(): Observable<Exercise[]> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Exercise[]>(`${this.baseUrl}/exercises`, {headers});
  }

  getRange(index: number, count: number): Observable<Exercise[]> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Exercise[]>(`${this.baseUrl}/exercises/getRange?skip=${index}&take=${count}`, {headers});
  }

  getIdByName(name: string): Observable<number> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<number>(`${this.baseUrl}/exercises/getIdByName?name=${name}`, {headers});
  }

  count(): Observable<number> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<number>(`${this.baseUrl}/exercises/count`, {headers});
  }

  delete(id: number): Observable<Exercise> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.delete<Exercise>(`${this.baseUrl}/exercises/${id}`, {headers});
  }

  update(id: number, exercise: Exercise): Observable<Response> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.put<Response>(`${this.baseUrl}/exercises/update/${id}`, exercise, {headers});
  }
}

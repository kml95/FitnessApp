import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Diet } from '../models/diet.interface';
import { DietAnalysis } from '../models/dietAnalysis.interface';

@Injectable()
export class DietService extends BaseService {

  private baseUrl = '';

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  create(name: string, calories: number, mealsAmount: number): Observable<number> {
    const body = { name, calories, mealsAmount};
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.post<number>(`${this.baseUrl}/diets/create`, body, {headers});
  }

  get(): Observable<Diet> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Diet>(`${this.baseUrl}/diets`, {headers});
  }

  getAll(): Observable<DietAnalysis[]> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<DietAnalysis[]>(`${this.baseUrl}/diets/getAll`, {headers});
  }

  getLast(count: number): Observable<Diet[]> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Diet[]>(`${this.baseUrl}/diets/getLast`, {headers, params: {'count': `${count}`}});
  }
}

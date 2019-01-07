import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Diet } from '../models/diet.interface';

@Injectable()
export class DietService extends BaseService {

  private baseUrl = '';

//   private httpOptions = {
//     headers: new HttpHeaders({ 'Content-Type': 'application/json' })
//   };

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  create(name: string, calories: number, mealsAmount: number): Observable<Response> {
    const body = { name, calories, mealsAmount};
    return this.http.post<Response>(`${this.baseUrl}/diets/create`, body);
  }



  get(): Observable<Diet> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Diet>(`${this.baseUrl}/diets`, {headers});
  }
}

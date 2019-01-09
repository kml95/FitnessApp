import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Training, TrainingAim } from '../models/training.interface';

@Injectable()
export class TrainingService extends BaseService {

  private baseUrl = '';

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  create(name: string, days: number, aim: TrainingAim): Observable<number> {
    const body = { name, days, aim};
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.post<number>(`${this.baseUrl}/trainings/create`, body, {headers});
  }

  get(): Observable<Training> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Training>(`${this.baseUrl}/trainings`, {headers});
  }
}

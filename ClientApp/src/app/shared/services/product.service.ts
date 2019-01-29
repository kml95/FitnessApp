import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Product, ProductCategory } from '../models/product.interface';

@Injectable()
export class ProductService extends BaseService {

  private baseUrl = '';

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  create(
      name: string,
      calories: number,
      carbohydrates: number,
      protein: number,
      fat: number,
      category: ProductCategory): Observable<number> {
    const body = { name, calories, carbohydrates, protein, fat, category};
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.post<number>(`${this.baseUrl}/products/create`, body, {headers});
  }

  get(): Observable<Product[]> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Product[]>(`${this.baseUrl}/products`, {headers});
  }

  getRange(index: number, count: number): Observable<Product[]> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<Product[]>(`${this.baseUrl}/products/getRange?skip=${index}&take=${count}`, {headers});
  }

  getIdByName(name: string): Observable<number> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<number>(`${this.baseUrl}/products/getIdByName?name=${name}`, {headers});
  }

  count(): Observable<number> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<number>(`${this.baseUrl}/products/count`, {headers});
  }

  delete(id: number): Observable<Product> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.delete<Product>(`${this.baseUrl}/products/${id}`, {headers});
  }

  update(id: number, product: Product): Observable<Response> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.put<Response>(`${this.baseUrl}/products/update/${id}`, product, {headers});
  }
}

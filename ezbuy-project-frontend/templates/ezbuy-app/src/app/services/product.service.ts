import { Injectable } from '@angular/core';
import { IProduct } from '../screens/product/model/IProduct';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private product: IProduct = {
    id: 0,
    name: '',
    description: '',
    category: '',
    price: 0
  };

  setProduct(product: IProduct) {
    this.product = product;
  }

  getProduct() {
    return this.product;
  }

  constructor(private http: HttpClient) { }

  private apiUrl = 'https://localhost:7294/api/Product/';

  save(obj: any): Observable<any> {
    return this.http.post(this.apiUrl, obj);
  }

  edit(obj: any): Observable<any> {
    return this.http.put(this.apiUrl, obj);
  }

  getAll(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  get(id: number): Observable<any> {
    return this.http.get(this.apiUrl + `${id}`);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.apiUrl + `${id}`);
  }

}

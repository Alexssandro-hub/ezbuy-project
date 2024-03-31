import { Injectable } from '@angular/core';
import { IProduct } from '../screens/product/model/IProduct';

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

  constructor() { }

  setProduct(product: IProduct) {
    this.product = product;
  }

  getProduct() {
    return this.product;
  }

}

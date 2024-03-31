import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IProduct } from './model/IProduct';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss'
})
export class ProductComponent implements OnInit {
  products = [
    { id: 1, name: 'Produto 1', description: 'Descrição do produto 1', category: 'Categoria 1', price: 10.99 },
    { id: 2, name: 'Produto 2', description: 'Descrição do produto 2', category: 'Categoria 2', price: 20.99 },
    { id: 3, name: 'Produto 3', description: 'Descrição do produto 3', category: 'Categoria 1', price: 15.99 },
    // Adicione mais produtos conforme necessário
  ];

  constructor(private router: Router, private productService: ProductService){}

  ngOnInit(){

  }

  createOrEditProduct(){
    this.router.navigateByUrl('/product/create-or-edit');
  }

  editProduct(product: any){
    this.productService.setProduct(product);
    this.router.navigateByUrl(`/product/create-or-edit`);
  }

}

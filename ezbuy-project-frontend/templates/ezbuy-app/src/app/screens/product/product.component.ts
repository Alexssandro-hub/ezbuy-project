import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IProduct } from './model/IProduct';
import { ProductService } from '../../services/product.service';
import { response } from 'express';
import { ToastrService } from 'ngx-toastr';
import { Observable, of, switchMap, take } from 'rxjs';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss'
})
export class ProductComponent implements OnInit {
  // products = [
  //   { id: 1, name: 'Produto 1', description: 'Descrição do produto 1', category: 'Categoria 1', price: 10.99 },
  //   { id: 2, name: 'Produto 2', description: 'Descrição do produto 2', category: 'Categoria 2', price: 20.99 },
  //   { id: 3, name: 'Produto 3', description: 'Descrição do produto 3', category: 'Categoria 1', price: 15.99 },
  //   // Adicione mais produtos conforme necessário
  // ];

  products: IProduct[] = [];

  constructor(private router: Router, private productService: ProductService, private toastrService: ToastrService,){}

  ngOnInit(){
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getAll().subscribe((response) => {
      if (response){
        this.products.push(...response);
      }
      else {
        this.toastrService.error('Falha na tentativa de carregar as entidades!', 'Error!');
      }
    })
  }

  createOrEditProduct(){
    this.router.navigateByUrl('/product/create-or-edit');
  }

  editProduct(product: any){
    this.productService.setProduct(product);
    this.router.navigateByUrl(`/product/create-or-edit`);
  }

  delete(product: any){
    if (product != null){
      this.toastrService.warning('Tem certeza que deseja excluir este item?', 'Confirmação', {
        closeButton: true,
        timeOut: 0,
        extendedTimeOut: 0,
        onActivateTick: true,
        disableTimeOut: true,
      }).onTap.pipe(
        switchMap(() => {
          this.productService.delete(product.id).subscribe((response) => {
            if (response){
              this.toastrService.success('Entidade excluída com sucesso!', 'Sucesso!');
              window.location.reload();
            }
            else {
              this.toastrService.error('Falha na tentativa de excluir a entidades!', 'Error!');
            }
          });
          return of(true);
        }),
        take(1)
      ).subscribe();
    }

    return;
  }

}

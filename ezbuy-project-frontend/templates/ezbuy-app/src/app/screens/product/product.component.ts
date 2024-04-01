import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IProduct } from './model/IProduct';
import { ProductService } from '../../services/product.service';
import { response } from 'express';
import { ToastrService } from 'ngx-toastr';
import { Observable, of, switchMap, take } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss'
})
export class ProductComponent implements OnInit {
  products: IProduct[] = [];

  constructor(private router: Router, private productService: ProductService, private toastrService: ToastrService,){

  }

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
      Swal.fire({
        title: 'Tem certeza?',
        text: 'Você quer realmente deletar este item?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim, deletar!',
        cancelButtonText: 'Cancelar'
      }).then((result) => {
        if (result.isConfirmed){
          this.productService.delete(product.id).subscribe((response) => {
            if (response){
              this.toastrService.success('Entidade excluída com sucesso!', 'Sucesso!');
              window.location.reload();
            }
            else {
              this.toastrService.error('Falha na tentativa de excluir a entidades!', 'Error!');
            }
          });
        }
      });

    }

    return;
  }

}

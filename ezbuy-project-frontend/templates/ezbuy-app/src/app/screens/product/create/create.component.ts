import { Component, OnInit } from '@angular/core';
import { IProduct } from '../model/IProduct';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent implements OnInit {

  form: FormGroup = this.buildForm();

  get isEdit(): boolean {
    return this.form.value.id !== 0;
  }

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private toastrService: ToastrService,
    private productService: ProductService
  ){}

  buildForm(): FormGroup {
    return this.formBuilder.group({
      id: [0],
      name: [''],
      description: [''],
      category: [''],
      price: [0]
    });
  }

  ngOnInit(){
    var product = this.productService.getProduct();
    if (product.id !== 0) {
      this.form.patchValue({
        id: product.id,
        name: product.name,
        description: product.description,
        category: product.category,
        price: product.price
      });
    }
  }

  load(){

  }

  save(){
    if (this.isEdit) {
      // update
    } else {
      // create
    }

    this.back();
  }

  delete(){
    //this.toastrService.warning('Produto deletado com sucesso!', 'Deletar Produto');
  }

  back(){
    this.productService.setProduct({
      id: 0,
      name: '',
      description: '',
      category: '',
      price: 0
    });

    this.router.navigateByUrl('/product');
  }
}

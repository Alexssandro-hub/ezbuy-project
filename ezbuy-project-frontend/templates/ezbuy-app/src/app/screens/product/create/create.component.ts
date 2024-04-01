import { Component, OnInit } from '@angular/core';
import { IProduct } from '../model/IProduct';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../../services/product.service';
import { HttpErrorResponse } from '@angular/common/http';
import { LoadingComponent } from '../../../components/loading/loading.component';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, LoadingComponent],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent implements OnInit {

  showLoading = false;

  toggleLoading(): void {
    this.showLoading = !this.showLoading;
  }

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

  save(){
    var product = this.getProduct();

    if (product.id > 0) {
      this.toggleLoading();
      this.productService.edit(product)
      .subscribe((response) => {
        if (response){
          this.toastrService.success('Entidade atualizada com sucesso!', 'Sucesso!');
          this.back();
        }else{
          this.toastrService.error('Falha na tentativa de atualizar entidade!', 'Error!');
        }
      }, (error: HttpErrorResponse) => {
        const validationErrors = error.error.errors;

        for (const fieldName in validationErrors) {
          if (validationErrors.hasOwnProperty(fieldName)) {
            const errorMessage = validationErrors[fieldName][0];
            console.error(`Erro de validação para o campo ${fieldName}: ${errorMessage}`);
            // Por exemplo, você pode exibir uma mensagem de erro ao usuário
            this.toastrService.error(`Erro de validação para o campo ${fieldName}: ${errorMessage}`, 'Erro de validação');
          }
        }
      });
    } else {
      this.toggleLoading();
      this.productService.save(product)
      .subscribe((response) => {
        if (response){
          this.toastrService.success('Entidade cadastrada com sucesso!', 'Sucesso!');
          this.back();
        }else{
          this.toastrService.error('Falha na tentativa de cadastrar entidade!', 'Error!');
        }
      },
      (error: HttpErrorResponse) => {
        const validationErrors = error.error.errors;

        for (const fieldName in validationErrors) {
          if (validationErrors.hasOwnProperty(fieldName)) {
            const errorMessage = validationErrors[fieldName][0];
            console.error(`Erro de validação para o campo ${fieldName}: ${errorMessage}`);
            // Por exemplo, você pode exibir uma mensagem de erro ao usuário
            this.toastrService.error(`Erro de validação para o campo ${fieldName}: ${errorMessage}`, 'Erro de validação');
          }
        }
      });
    }
  }

  getProduct(): any {
    return {
      id: this.form.value.id | 0,
      name: this.form.value.name,
      description: this.form.value.description,
      price: this.form.value.price,
      category: this.form.value.category
    }
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

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Router, RouterOutlet } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    HttpClientModule,
    RouterOutlet,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule,
    MatTooltipModule,
    ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  form: FormGroup = this.buildForm();

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService,
  ) {

  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      username: [''],
      firstName: [''],
      lastName: [''],
      email: [''],
      password: ['']
    });
  }

  register(){
    this.authService.register({
      Login: this.form.value.username,
      FirstName: this.form.value.firstName,
      LastName: this.form.value.lastName,
      Email: this.form.value.email,
      Password: this.form.value.password
    }).subscribe(
      (response) => {
        if (response){
          this.toastrService.success('Cadastro realizado com sucesso!', 'Sucesso!');
          this.router.navigate(['/login']);
        }else {
          this.toastrService.error('Falha na tentativa de cadastro!', 'Error!');
        }
      },
      (error) => {
        this.form.reset();
        this.toastrService.error(error.error, 'Error!');
      }
    );
  }

  // register(){
  //   //this.router.navigate(['/home']);
  // }
}

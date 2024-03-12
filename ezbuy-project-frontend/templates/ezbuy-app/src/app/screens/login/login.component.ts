import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from '../../services/auth.service';
import {MatTooltipModule} from '@angular/material/tooltip';
import { ToastrService } from 'ngx-toastr';
import { error } from 'console';

@Component({
  selector: 'app-login',
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
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [AuthService]
})
export class LoginComponent {
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
      email: [''],
      password: ['']
    });
  }

  onLogin(){
    this.authService.login({
      Email: this.form.value.email,
      Password: this.form.value.password
    }).subscribe(
      (response) => {
        if (response){
          this.toastrService.success('Login realizado com sucesso!', 'Sucesso!');
          this.router.navigate(['/home']);
        }else {
          this.toastrService.error('Falha na tentativa de login!', 'Error!');
        }
      },
      (error) => {
        this.form.reset();
        this.toastrService.error(error.error, 'Error!');
      }
    );
  }

  register(){
    this.router.navigate(['/register']);
  }
}


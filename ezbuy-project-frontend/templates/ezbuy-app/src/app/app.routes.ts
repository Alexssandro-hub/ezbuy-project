import { RegisterComponent } from './screens/register/register.component';
import { Routes } from '@angular/router';
import { HomeComponent } from './screens/home/home.component';
import { LoginComponent } from './screens/login/login.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  {
    path: 'login',
    loadComponent: () =>
      import('./screens/login/login.component').then(m => m.LoginComponent),
    title: 'Login',
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./screens/register/register.component').then(m => m.RegisterComponent),
    title: 'Register',
  },
  {
    path: 'home',
    loadComponent: () => import('./screens/home/home.component').then(m => m.HomeComponent),
    title: 'Home',
  },
  {
    path: 'product',
    loadComponent: () => import('./screens/product/product.component').then(m => m.ProductComponent),
    title: 'Produto',
  },
  {
    path: 'product/create-or-edit',
    loadComponent: () => import('./screens/product/create/create.component').then(m => m.CreateComponent),
    title: 'Criar/Editar Produto',
  },
];


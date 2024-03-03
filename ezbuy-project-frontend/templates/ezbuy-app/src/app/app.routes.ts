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
    path: 'home',
    loadComponent: () => import('./screens/home/home.component').then(m => m.HomeComponent),
    title: 'Home',
  },
];


import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { DragDropModule, moveItemInArray } from '@angular/cdk/drag-drop';
import { filter } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DragDropModule, CommonModule ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ezbuy-app';
  items = ['Item 1', 'Item 2', 'Item 3', 'Item 4'];
  showSidebar: boolean = false;

  constructor(private router: Router){
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event) => {
      event = event as NavigationEnd;
      this.showSidebar = !['/login', '/register'].includes(event.url);
    });
  }

  drop(event: any) {
    moveItemInArray(this.items, event.previousIndex, event.currentIndex);
  }

  goToProduct(){
    this.router.navigateByUrl('/product');
  }

  goToProfile(){
    this.router.navigateByUrl('/profile');
  }
}

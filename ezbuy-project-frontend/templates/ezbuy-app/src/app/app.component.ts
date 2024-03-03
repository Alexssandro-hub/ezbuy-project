import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DragDropModule, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DragDropModule ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ezbuy-app';
  items = ['Item 1', 'Item 2', 'Item 3', 'Item 4'];

  drop(event: any) {
    moveItemInArray(this.items, event.previousIndex, event.currentIndex);
  }
}

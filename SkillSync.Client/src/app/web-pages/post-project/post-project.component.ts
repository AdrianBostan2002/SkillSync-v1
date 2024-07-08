import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-post-project',
  templateUrl: './post-project.component.html',
  styleUrl: './post-project.component.css'
})
export class PostProjectComponent {

  items: MenuItem[] = [];
  activeIndex: number = 0;

  ngOnInit() {
    this.items = [
      {
        label: 'Overview',
        routerLink: 'overview'
      },
      {
        label: 'Pricing',
        routerLink: 'pricing'
      },
      {
        label: 'Description & FAQ',
        routerLink: 'description-faq'
      },
      {
        label: 'Gallery',
        routerLink: 'gallery'
      },
      {
        label: 'Publish',
        routerLink: 'publish'
      }
    ];
  }
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-unauthenticated-header',
  templateUrl: './unauthenticated-header.component.html',
  styleUrl: './unauthenticated-header.component.css'
})
export class UnauthenticatedHeaderComponent {
  displaySearchBar: boolean = false;
}
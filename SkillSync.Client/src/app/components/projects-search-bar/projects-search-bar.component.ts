import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-projects-search-bar',
  templateUrl: './projects-search-bar.component.html',
  styleUrl: './projects-search-bar.component.css'
})
export class ProjectsSearchBarComponent {
  @Output() searchProjectsPreviewEvent = new EventEmitter<string>();
  searchText: string = '';

  searchProjects() {
    this.searchProjectsPreviewEvent.emit(this.searchText);
  }
}

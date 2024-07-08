import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { NgxDocViewerModule } from 'ngx-doc-viewer';

@Component({
  selector: 'app-document-view',
  standalone: true,
  imports: [CommonModule, NgxDocViewerModule],
  templateUrl: './document-view.component.html',
  styleUrl: './document-view.component.css'
})
export class DocumentViewComponent {
  @Input() documentUrl?: string;
}

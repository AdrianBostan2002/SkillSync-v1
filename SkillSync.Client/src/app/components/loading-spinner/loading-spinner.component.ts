import { Component } from '@angular/core';
import { LoadingSpinnerService } from '../../services/loading-spinner.service';

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrl: './loading-spinner.component.css'
})
export class LoadingSpinnerComponent {
  isLoading: boolean = false;

  constructor(private loadingSpinnerService: LoadingSpinnerService) { }

  ngOnInit() {
    this.loadingSpinnerService.spinnerVisible$.subscribe(status => {
      this.isLoading = status;
    });
  }
}

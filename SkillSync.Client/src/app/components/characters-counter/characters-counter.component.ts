import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-characters-counter',
  templateUrl: './characters-counter.component.html',
  styleUrl: './characters-counter.component.scss'
})
export class CharactersCounterComponent {
  @Input() minCount: number = 0;
  @Input() maxCount: number = 0;
  @Input() characterCounter: number = 0;
}

import { Component } from '@angular/core';

if (globalThis.window === undefined) {
  globalThis.window =
    ({
      addEventListener: () => {},
    } as never);
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SkillSync.Client';
}

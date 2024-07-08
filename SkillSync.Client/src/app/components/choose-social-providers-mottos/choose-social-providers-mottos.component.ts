import { Component } from '@angular/core';

@Component({
  selector: 'app-choose-social-providers-mottos',
  templateUrl: './choose-social-providers-mottos.component.html',
  styleUrl: './choose-social-providers-mottos.component.css'
})
export class ChooseSocialProvidersMottosComponent {
  mainMotto: string = "Empower Your Success Journey Here";
  mottos: string[] = ["Connect with Global Talent, Anywhere, Anytime", "Explore 100+ Categories, Limitless Possibilities", "Empower Your Succes Journey Here"];
}

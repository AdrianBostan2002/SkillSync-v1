import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../../services/authentication.service';

@Component({
  selector: 'app-login-response',
  templateUrl: './login-response.component.html',
  styleUrl: './login-response.component.css'
})
export class LoginResponseComponent {
  linkedInToken = "";

  constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService) { }

  async ngOnInit() {
    this.linkedInToken = this.route.snapshot.queryParams["code"];

    if (this.linkedInToken != "") {
      await this.authenticationService.linkedInLogin(this.linkedInToken);
      this.router.navigate(["/landing-page"]);
    }
  }
}

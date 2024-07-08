import { isPlatformBrowser } from '@angular/common';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { jwtDecode } from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  jwtToken: string = "";
  decodedToken?: { [key: string]: string };

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {
    if (isPlatformBrowser(this.platformId)) {
      this.jwtToken = localStorage.getItem("token") || "";
      this.decodeToken();
    }
  }

  resetToken() {
    this.jwtToken = "";
    this.decodedToken = undefined;
  }

  setToken(token: string) {
    if (token) {
      this.jwtToken = token;
      this.decodeToken();
    }
  }

  decodeToken() {
    if (this.jwtToken) {
      this.decodedToken = jwtDecode(this.jwtToken);
    }
  }

  getDecodeToken() {
    return jwtDecode(this.jwtToken);
  }

  getRole() {
    return this.decodedToken ? this.decodedToken['role'] : null;
  }

  getEmail() {
    return this.decodedToken ? this.decodedToken['email'] : null;
  }

  getUsername() {
    return this.decodedToken ? this.decodedToken['unique_name'] : null;
  }

  getProfilePictureUrl() {
    return this.decodedToken ? this.decodedToken['profile-picture'] : null;
  }

  getExpiryTime() {
    return this.decodedToken ? this.decodedToken['exp'] as unknown as number : null;
  }

  isTokenExpired(): boolean {
    const expiryTime: number | null = this.getExpiryTime();
    if (expiryTime) {
      return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
    } else {
      return false;
    }
  }
}
import { Injectable } from '@angular/core';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor(private tokenService: TokenService) { }

  public setItem(item: string, value: string) {
    localStorage.setItem(item, value);
    this.tokenService.setToken(value);
  }

  public removeItem(item: string) {
    localStorage.removeItem(item);
  }

  public removeToken(){
    localStorage.removeItem("token");
    this.tokenService.resetToken();
  }

  public getItem(item: string) {
    return localStorage.getItem(item);
  }
}
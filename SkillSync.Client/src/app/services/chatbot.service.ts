import { Injectable } from '@angular/core';
import { Subject, lastValueFrom } from 'rxjs';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChatbotService {
  private readonly httpOptions = jsonHttpOptions;

  visibility$ = new Subject<boolean>();

  constructor(private httpClient: HttpClient) { }

  async executeQuery(query: string) {
    let route = buildRoute(`api/ChatBot/${query}`);

    let result = this.httpClient.get<any>(route, this.httpOptions);

    return await lastValueFrom(result);
  }
}
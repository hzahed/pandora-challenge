import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class DataService {
  constructor(private httpClient: HttpClient) {}

  post(url: string, dto: any) {
    return this.httpClient.post(`${environment.apiRoot}/${url}`, dto);
  }
}

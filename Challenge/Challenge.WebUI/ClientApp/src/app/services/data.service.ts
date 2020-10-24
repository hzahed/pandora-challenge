import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class DataService {
  constructor(private httpClient: HttpClient) {}

  post(url: string, dto: any) {
    const body = JSON.stringify(dto);
    const link = `${environment.apiRoot}/${url}`;
    return this.httpClient.post(link, dto);
  }
}

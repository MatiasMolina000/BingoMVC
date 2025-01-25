import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { catchError, Observable, tap, map, throwError } from 'rxjs';

import { ILogin } from '../../models/login.interface';
import { IResponse } from '../../models/response.interface';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private httpClient = inject(HttpClient);

  private url: string = 'http://localhost:9091/api/';

  constructor(private authenticationService: AuthenticationService) { }

  signIn (request: ILogin): Observable<string> {
    return this.httpClient.post<any>(this.url.concat('Auth/Authentication'), request)
    .pipe(
      catchError(error =>{
        console.error(error);
        return throwError(() => new Error('Server connection error. Please try again later.'));
      }),
      tap((response: IResponse) => {
        if (!response.success) {
          throw new Error(response.message);
        }
        this.authenticationService.saveToken(response.data.token);
      }),
      map((response: IResponse) => {
        return response.message;
      }),
    );
  }
}

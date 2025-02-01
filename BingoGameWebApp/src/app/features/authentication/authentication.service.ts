import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ILogin } from '../../shared/models/login.interface';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { IResponse } from '../../shared/models/response.interface';
import { AuthService } from '../../core/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private httpClient = inject(HttpClient);

  private url: string = 'http://localhost:9091/api/';

  constructor(private authService: AuthService) { }

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
        this.authService.saveToken(response.data.token);
      }),
      map((response: IResponse) => {
        return response.message;
      }),
    );
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AccessToken } from 'src/app/models/token';
import { environment } from 'src/environments/environment';

@Injectable()
export class AccessTokenService {

  constructor(private readonly http:HttpClient) { }

  public generateToken(userId:number):Observable<AccessToken>{
    return this.http.get<AccessToken>(`${environment.apiUrl}/api/Token/GenerateToken/${userId}`);
  }

  public checkIfTokenIsValid(token: string): Observable<AccessToken> {
    return this.http.get<AccessToken>(`${environment.apiUrl}/api/Token/CheckIfTokenIsValid/${token}`);
  }

  public deleteInvalidTokensByUserId(userId: number) {
    return this.http.get(`${environment.apiUrl}/api/Token/DeleteInvalidUserTokens/${userId}`);
  }
}

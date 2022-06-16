import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class LoginService {
  
  constructor(private readonly http: HttpClient) { }

  public addUser(userName: string): Observable<any> {
    return this.http.post(`${environment.apiUrl}/api/User/AddUser/${userName}`, null);
  }
}

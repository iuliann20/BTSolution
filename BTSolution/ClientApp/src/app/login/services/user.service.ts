import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private readonly http: HttpClient) { }

  public removeUser(userId: number) {
    return this.http.get(`${environment.apiUrl}/api/User/RemoveUser/${userId}`);
  }

  public getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/api/User/GetAllUsers`);
  }

  public getUserByUserName(userName:any): Observable<User>{
    return this.http.get<User>(`${environment.apiUrl}/api/User/GetUserByUserName/${userName}`)
  }

}

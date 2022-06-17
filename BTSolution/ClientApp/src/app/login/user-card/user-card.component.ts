import { Component, Input, OnInit } from '@angular/core';
import { AccessTokenService } from '../services/access-token.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {
  @Input("userId") id = 0;
  @Input("userName") name = "";
  constructor(private readonly userService: UserService, private readonly accessTokenService: AccessTokenService) { }

  ngOnInit(): void {
  }
  public removeUser(): void {
    this.userService.removeUser(this.id).subscribe(result => {
      console.log("success");
      location.reload();
    }, error => {
      console.log(error);
    });
  }

  public deleteInvalidUserTokens() {
    this.accessTokenService.deleteInvalidTokensByUserId(this.id).subscribe(result => {
      location.reload();
    }, error => {
      console.log(error);
    });
  }
}

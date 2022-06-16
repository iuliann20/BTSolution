import { Component, Input, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {
  @Input("userId") id = 0;
  @Input("userName") name = "";
  constructor(private readonly userService:UserService) { }

  ngOnInit(): void {
  }
  public removeUser(): void {
    this.userService.removeUser(this.id).subscribe(result => {
      console.log("success");
    }, error => {
      console.log(error);
    });
  }
}

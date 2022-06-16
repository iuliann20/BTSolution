import { Component, OnInit } from '@angular/core';
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AccessTokenService } from '../services/access-token.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']
})
export class LoginModalComponent implements OnInit {
  public userName: any;
  public tokenGenerated: string = '';
  public token: string = '';
  public isTokenGenerated: boolean = false;
  public isUserLogin: boolean = false;
  timeLeft: number = 0;
  interval: any;
  constructor(private modalService: NgbModal, private readonly userService: UserService, private readonly accessTokenService: AccessTokenService) { }

  ngOnInit(): void {
  }

  public open(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-title' }).result;
  }

  public checkIfUserNameInputIsEmpty() {
    if (this.userName != undefined) {
      this.isTokenGenerated = true;
      this.getUserByUserName();
    } else {
      console.log("please insert user name");

    }
  }


  public loginUser(): void {
    this.accessTokenService.getToken(this.tokenGenerated).subscribe(result => {
      if (result.IsValid) {
        this.isUserLogin = true;
      }
    }, error => {
      console.log("nu a mers");
    })
  }


  private startTimer(result: any): void {
    this.interval = setInterval(() => {
      if (this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.accessTokenService.generateToken(result.userId).subscribe(result => {
          this.tokenGenerated = result.token;
        }, error => {
          console.log(error);
        });
        this.timeLeft = 30;
      }
    }, 1000)
  }

  public pauseTimer() {
    clearInterval(this.interval);
    this.token = '';
    this.userName = '';
    this.timeLeft = 0;
    this.isTokenGenerated = false;
  }

  public logoutUser() {
    this.isUserLogin = false;
  }
  private getUserByUserName(): void {
    this.userService.getUserByUserName(this.userName).subscribe(
      result => {
        this.startTimer(result);
      }, error => {
        console.log(error);
        return null;

      }
    );
  }
}

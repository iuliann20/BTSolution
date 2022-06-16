import { Component, OnInit } from '@angular/core';
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";


@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']
})
export class LoginModalComponent implements OnInit {
  public userName: any;
  public token: string = '';
  public isTokenGenerated: boolean = false;
  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  public open(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-title' }).result;
  }
 
  public checkIfUserNameInputIsEmpty() {
    if (this.userName != '') {
      this.isTokenGenerated = true;
    } else {
      console.log("please insert user name");

    }
  }
  public getUserByUserName() {
    console.log();
  }
}

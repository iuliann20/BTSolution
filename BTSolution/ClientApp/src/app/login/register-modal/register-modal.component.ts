import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import { User } from 'src/app/models/user-model';


@Component({
  selector: 'app-register-modal',
  templateUrl: './register-modal.component.html',
  styleUrls: ['./register-modal.component.css']
})
export class RegisterModalComponent implements OnInit {
  public userName: any;

  constructor(private readonly loginService: LoginService, private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  

  public addUser():void{
    this.loginService.addUser(this.userName).subscribe(result=>{
      this.userName = '';
      console.log(result);
    });
  }
  getUserName(name: string): void {
    this.userName = name;
  }
  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-title'}).result;
  }
}

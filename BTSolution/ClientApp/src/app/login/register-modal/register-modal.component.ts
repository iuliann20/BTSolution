import { Component, OnInit } from '@angular/core';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import { User } from 'src/app/models/user-model';
import { LoginService } from '../services/login.service';


@Component({
  selector: 'app-register-modal',
  templateUrl: './register-modal.component.html',
  styleUrls: ['./register-modal.component.css']
})
export class RegisterModalComponent implements OnInit {
  public userName: any;

  constructor( private readonly modalService: NgbModal, private readonly loginService:LoginService) { }

  ngOnInit(): void {
  }

  

  public addUser():void{
    this.loginService.addUser(this.userName).subscribe((result: any)=>{
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

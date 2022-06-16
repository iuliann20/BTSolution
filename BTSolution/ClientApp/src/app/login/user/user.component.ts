import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user-model';
import { UserService } from '../services/user.service';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  public users: Array<User> = [];

  constructor(private readonly userService:UserService, private modalService:NgbModal) { }

  ngOnInit(): void {
  }
  public getAllUsers(): void {
    this.userService.getAllUsers().subscribe({
      next: (v) => this.users = v,
      error: (e) => console.log(e),
      complete: () => {
        
      }
    });
  }

  
  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-title'}).result;
  }
}

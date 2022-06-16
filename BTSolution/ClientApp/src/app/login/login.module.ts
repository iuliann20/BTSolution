import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { LoginService } from './login.service';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { RegisterModalComponent } from './register-modal/register-modal.component';
import { LoginModalComponent } from './login-modal/login-modal.component';


@NgModule({
  declarations: [
    RegisterModalComponent,
    LoginModalComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    MatInputModule,
    FormsModule,
    NgbModule
  ],
  providers:[
    LoginService
  ]
})
export class LoginModule { }

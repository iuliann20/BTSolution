import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { LoginService } from './services/login.service';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { RegisterModalComponent } from './register-modal/register-modal.component';
import { LoginModalComponent } from './login-modal/login-modal.component';
import { UserComponent } from './user/user.component';
import { UserCardComponent } from './user-card/user-card.component';
import { UserService } from './services/user.service';
import { AccessTokenService } from './services/access-token.service';


@NgModule({
  declarations: [
    RegisterModalComponent,
    LoginModalComponent,
    UserComponent,
    UserCardComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    MatInputModule,
    FormsModule,
    NgbModule
  ],
  providers:[
    LoginService,
    UserService,
    AccessTokenService
  ]
})
export class LoginModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterModalComponent } from './register-modal/register-modal.component';

const routes: Routes = [
  {
    path: '', component: RegisterModalComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }

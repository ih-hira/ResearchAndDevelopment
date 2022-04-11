import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './user-login/login/login.component';
import { ProfileComponent } from './user-profile/profile/profile.component';
import { AuthGuardService } from './common-services/authorize/auth-guard.service'
import { SignupComponent } from './user-registration/signup/signup.component';

const routes: Routes = [
  { path: '', component: ProfileComponent,canActivate: [AuthGuardService] },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'profile/:username', component: ProfileComponent, canActivate: [AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

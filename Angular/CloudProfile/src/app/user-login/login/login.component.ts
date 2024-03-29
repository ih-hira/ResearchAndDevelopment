import { Token } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LocalStorageService } from 'src/app/common-services/local-storage/local-storage.service';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public errorMsg: string = '';
  constructor(private router: Router,
    private route: ActivatedRoute,
    private loginService: LoginService,
    private localStorageService: LocalStorageService) {

  }

  ngOnInit(): void {
  }

  login(loginForm: any) {

    if (loginForm.invalid) {
      this.errorMsg = "Invalid input!! Try again."
    }
    else {
      console.log(this);
      this.errorMsg = '';
      let userCred = loginForm.value;
      this.loginService.userLogin(userCred).subscribe({
        next: (tokens) => {
          this.localStorageService.set('access_token', Object(tokens)['accessToken']);
          this.localStorageService.set('refresh_token', Object(tokens)['refreshToken']);
        },
        error: (e) => this.errorMsg = e,
        complete: () => {
          if (!this.errorMsg)
            this.router.navigate(['profile', userCred.username]);
        }
      });
    }

  }
}

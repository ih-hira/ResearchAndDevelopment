import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public errorMsg:string='';
  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  login(loginForm: any){
    
    if(loginForm.invalid)
    {
      this.errorMsg="Invalid input!! Try again."
    }else{
      this.errorMsg='';
      let userCred=loginForm.value;
      console.log(userCred);
    }
    
  }
}

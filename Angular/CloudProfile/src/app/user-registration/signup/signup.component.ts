import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  regForm = new FormGroup({
    firstname: new FormControl(''),
    lastname: new FormControl(''),
    addresses: new FormArray([new FormControl()]),
    email: new FormControl('',Validators.required)
  });
  get email(){return this.regForm.get('email')}
  get addressControls(){
    return (<FormArray>this.regForm.get('addresses')).controls;
  }

  addNewAddress(){
    const control = new FormControl(null);
    (<FormArray>this.regForm.get('addresses')).push(control);
  }
}

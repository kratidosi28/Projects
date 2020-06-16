import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { HttpClientModule, HttpClient, HttpErrorResponse } from '@angular/common/http';
import{Router} from "@angular/router";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  SignUpFormGroup: FormGroup;
  result: any;
  id : number;

  readonly rootURL = 'https://localhost:44351/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.SignUpFormGroup=this.formBuilder.group({
      FullName:['',Validators.required],
     Email:['',Validators.required],
     MobileNumber :['',Validators.required]
    })
  }
  check(){
    this.httpService.post(this.rootURL+'/Signups',{FullName:this.SignUpFormGroup.value.FullName,Email:this.SignUpFormGroup.value.Email,MobileNumber:this.SignUpFormGroup.value.MobileNumber}).subscribe(res=>{
        this.result=res;
        console.log(this.result);
       });
  }

}

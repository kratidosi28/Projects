import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { HttpClientModule, HttpClient, HttpErrorResponse } from '@angular/common/http';
import{Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  customerLoginFormGroup: FormGroup;
  result: any;
  id : any;
  value;

  readonly rootURL = 'https://localhost:44351/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.customerLoginFormGroup=this.formBuilder.group({
      Email:['',Validators.required],
      
    });
  }
  check(){
    if(localStorage.getItem('id')){
     alert("you successfully logged in");
    } else{
   this.httpService.post(this.rootURL+'/Login',{Email:this.customerLoginFormGroup.value.Email}).subscribe(res=>{
        this.result=res;
       console.log(this.result);
       localStorage.setItem('id', this.result.RegistrationId);
        //alert("you successfully logged in");
        this.value = localStorage.getItem('url');
        this.id = localStorage.getItem('catid');
        this.router.navigate(['/foodlist/', this.id])
   });
      
    }
      }
        
    
  }



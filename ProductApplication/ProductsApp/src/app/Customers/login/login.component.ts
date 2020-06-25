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
  id : number;

  readonly rootURL = 'https://localhost:44316/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.customerLoginFormGroup=this.formBuilder.group({
      Email:['',Validators.required],
      Password:['',Validators.required]
    })
  }
  check(){
    this.httpService.post(this.rootURL+'/Login',{Email:this.customerLoginFormGroup.value.Email,Password:this.customerLoginFormGroup.value.Password}).subscribe(res=>{
        this.result=res;
         localStorage.setItem("token",JSON.stringify(this.result));
         console.log(this.result);
        // alert("you successfully logged in");
        //  this.router.navigate(['/search-product']);
     
        
    });
  }
  }

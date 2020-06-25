import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import{Router} from "@angular/router"

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styles: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {

  customerFormGroup: FormGroup;
  result: any;

  readonly rootURL = 'https://localhost:44316/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.customerFormGroup=this.formBuilder.group({
      FirstName:['',Validators.required],
      LastName:['',Validators.required],
      Email:['',Validators.required],
      Password:['',Validators.required],
      ConfirmPassword:['',Validators.required],
      MobileNumber:['',Validators.required],
      Gender:['',Validators.required],
      Address:['',Validators.required],
      Dob:['',Validators.required]
     
    })
  }
 Register(){
    this.httpService.post(this.rootURL+'/Customers',{FirstName:this.customerFormGroup.value.FirstName,LastName:this.customerFormGroup.value.LastName,Email:this.customerFormGroup.value.Email,Password:this.customerFormGroup.value.Password,ConfirmPassword:this.customerFormGroup.value.ConfirmPassword,MobileNumber:this.customerFormGroup.value.MobileNumber,Gender:this.customerFormGroup.value.Gender,Address:this.customerFormGroup.value.Address
    ,Dob:this.customerFormGroup.value.Dob}).subscribe(res=>{
      this.result=res;
      console.log(this.result);
      //this.router.navigate[("/login")];
    
      
    })
    this.httpService.get(this.rootURL+'/Login');
  }

}

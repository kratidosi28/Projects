import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { HttpClientModule, HttpClient, HttpErrorResponse } from '@angular/common/http';
import{Router} from "@angular/router";

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css']
})
export class UpdateProfileComponent implements OnInit {

  customerProfileFormGroup: FormGroup;
  result: any;
  id : number;
  Get:any;
  email:any;
  title:any;
  isReadonly : boolean;
 readonly rootURL = 'https://localhost:44316/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {

   this.Get = JSON.parse(localStorage.getItem("token"));
   console.log(this.Get)
   this.email =JSON.parse(localStorage.getItem("token")).Email ;
   this.isReadonly = true;
   this.customerProfileFormGroup=this.formBuilder.group({
    FirstName:['',Validators.required],
    LastName:['',Validators.required],
    Email:[''],
    Password:['',Validators.required],
    ConfirmPassword:['',Validators.required],
    MobileNumber:['',Validators.required],
    Gender:['',Validators.required],
    Address:['',Validators.required],
    Dob:['',Validators.required]
   
  });
  this.customerProfileFormGroup.controls.FirstName.setValue(this.Get.FirstName);
  this.customerProfileFormGroup.controls.LastName.setValue(this.Get.LastName);
  
  this.customerProfileFormGroup.controls.Password.setValue(this.Get.Password);
  this.customerProfileFormGroup.controls.ConfirmPassword.setValue(this.Get.ConfirmPassword);
  this.customerProfileFormGroup.controls.MobileNumber.setValue(this.Get.MobileNumber);
  this.customerProfileFormGroup.controls.Gender.setValue(this.Get.Gender);
  this.customerProfileFormGroup.controls.Address.setValue(this.Get.Address);
  this.customerProfileFormGroup.controls.Dob.setValue(this.Get.Dob);

  }

  Update(){
    this.httpService.put(this.rootURL+'/Customers/'+this.Get.CustomerId,{CustomerId:this.Get.CustomerId,FirstName:this.customerProfileFormGroup.value.FirstName,LastName:this.customerProfileFormGroup.value.LastName,Email:this.Get.Email,Password:this.customerProfileFormGroup.value.Password,ConfirmPassword:this.customerProfileFormGroup.value.ConfirmPassword,MobileNumber:this.customerProfileFormGroup.value.MobileNumber,Gender:this.customerProfileFormGroup.value.Gender,Address:this.customerProfileFormGroup.value.Address
    ,Dob:this.customerProfileFormGroup.value.Dob}).subscribe(res=>{
      this.result=res;
      console.log(this.result);
      //this.router.navigate[("/login")];
    
      
    });

}
}
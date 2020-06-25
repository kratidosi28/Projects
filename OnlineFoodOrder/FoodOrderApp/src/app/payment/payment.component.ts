import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { HttpClientModule, HttpClient, HttpErrorResponse } from '@angular/common/http';
import{Router} from "@angular/router";

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  paymentFormGroup: FormGroup;
  result: any;
  id;
  token;
  value;

  readonly rootURL = 'https://localhost:44351/api';
  data: Object;
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.paymentFormGroup=this.formBuilder.group({
     CardOwnerName:['',Validators.required],
     CardNumber:['',Validators.required],
     ExpirationDate:['',Validators.required],
     CVV:['',Validators.required]
      
    })
  }
  check(){
    
    this.httpService.post(this.rootURL+'/Payments',{CardOwnerName:this.paymentFormGroup.value.CardOwnerName, CardNumber:this.paymentFormGroup.value.CardNumber,
    ExpirationDate:this.paymentFormGroup.value.ExpirationDate, CVV:this.paymentFormGroup.value.CVV}).subscribe(res=>{
        this.result=res;
        console.log(this.result); 
      });

     this.token = localStorage.getItem('token');
     this.value = localStorage.getItem('id');
     console.log(this.value);
        

     this.httpService.post(this.rootURL+'/Orders',{RegistrationId:this.value, FoodId: this.token}).subscribe(res =>{
      this.data = res;
      console.log(this.data);
  });
        
   
        alert("your order is successfully booked");
      
     
        
    
  }

  }

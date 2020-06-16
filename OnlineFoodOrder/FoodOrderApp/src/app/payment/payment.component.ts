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
  id : number;

  readonly rootURL = 'https://localhost:44351/api';
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
    alert("your order is successfully booked");
    this.httpService.post(this.rootURL+'/Payments',{CardOwnerName:this.paymentFormGroup.value.CardOwnerName, CardNumber:this.paymentFormGroup.value.CardNumber,
    ExpirationDate:this.paymentFormGroup.value.ExpirationDate, CVV:this.paymentFormGroup.value.CVV}).subscribe(res=>{
        this.result=res;
        console.log(this.result);
      
     
        
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quantities',
  templateUrl: './quantities.component.html',
  styleUrls: ['./quantities.component.css']
})
export class QuantitiesComponent implements OnInit {
 
  quantityFormGroup:FormGroup;
  result : any;
  id:any;
  searchText;
  value;
  readonly rootURL = 'https://localhost:44351/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { 

  this.quantityFormGroup = this.formBuilder.group({
    quantity:['']
  });
 }

  ngOnInit(): void {
    
    
  

  }
  continue(){
    this.value= this.quantityFormGroup.value.quantity;
    console.log(this.value);
    this.router.navigate(['/totalprice/', this.value]);
  }

}

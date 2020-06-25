import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import{Router} from "@angular/router"

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  ProductFormGroup: FormGroup;
  result: any;

  readonly rootURL = 'https://localhost:44316/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.ProductFormGroup=this.formBuilder.group({
      ProductCode:['',Validators.required],
      ProductName:['',Validators.required],
      ProductDescription:['',Validators.required],
      ProductBrand:['',Validators.required],
      ProductPrice:['',Validators.required],
  })

}

AddProduct(){
  this.httpService.post(this.rootURL+'/Customers',{ProductName:this.ProductFormGroup.value.ProductName,ProductCode:this.ProductFormGroup.value.ProductCode,ProductDescription:this.ProductFormGroup.value.ProductDescription,ProductPrice:this.ProductFormGroup.value.ProductPrice,ProductBrand:this.ProductFormGroup.value.ProductBrand}).subscribe(res=>{
        console.log(res);
        
      });
      this.router.navigate(['/productlist']);
}
}

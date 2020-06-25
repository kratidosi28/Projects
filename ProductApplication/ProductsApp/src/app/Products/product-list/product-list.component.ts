import { Component,OnInit } from '@angular/core';
import{FormGroup ,FormBuilder} from '@angular/forms';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  
  result:any;
  readonly rootURL = 'https://localhost:44316/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {

    this.httpService.get(this.rootURL+'/Products').subscribe(res=>{
        
      this.result=res;   
      
    });
  }

  DeleteProduct(id)
  {
 this.httpService.delete<any>(this.rootURL+'/Products'+id).subscribe(res=>
 {
   console.log(res);
 }
 ) 
  }     

}

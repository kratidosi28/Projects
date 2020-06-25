import { Component,OnInit } from '@angular/core';
import{FormGroup ,FormBuilder} from '@angular/forms';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent implements OnInit {

  Products:any;
  searchText;
  title:"Products"
  readonly rootURL = 'https://localhost:44316/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }
  ngOnInit(): void {
    
    this.httpService.get(this.rootURL+'/Products').subscribe(res=>{
        
      this.Products=res;   
      
    });
  }

}

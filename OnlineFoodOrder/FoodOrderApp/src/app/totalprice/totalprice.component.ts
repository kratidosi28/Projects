import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-totalprice',
  templateUrl: './totalprice.component.html',
  styleUrls: ['./totalprice.component.css']
})
export class TotalpriceComponent implements OnInit {

  result : any;
  FoodCategoryId : any;
  quantity:any;
  searchText;
  subscription;
  data:any;
  value;
  readonly rootURL = 'https://localhost:44351/api';

  
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
  this.quantity = +this.activatedRoute.snapshot.paramMap.get('id')
  this.FoodCategoryId =localStorage.getItem('token');
  //console.log(this.id);
  
    this.httpService.get(this.rootURL+'/FoodLists/'+this.FoodCategoryId).subscribe(res =>{
      this.result = res;
      console.log(this.result);
         this.value = this.quantity * this.result.FoodPrice;
          console.log(this.value);
  });

  }

 
}

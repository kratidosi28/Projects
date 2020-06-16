import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-food-categories',
  templateUrl: './food-categories.component.html',
  styleUrls: ['./food-categories.component.css']
})
export class FoodCategoriesComponent implements OnInit {
  result : any;
  RestaurantId : any;
  id:any;
  searchText;
  subscription;
  data:any;
  readonly rootURL = 'https://localhost:44351/api';

  
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
  this.id = +this.activatedRoute.snapshot.paramMap.get('id')
  //console.log(this.id);
   this.httpService.get(this.rootURL+'/Restaurants/'+this.id).subscribe(res =>{
     this.data =res;
     console.log(this.data);
   });
    this.httpService.post(this.rootURL+'/VCategories', {RestaurantId: this.id}).subscribe(res =>{
      this.result = res;
      console.log(this.result);
  });

  }
}

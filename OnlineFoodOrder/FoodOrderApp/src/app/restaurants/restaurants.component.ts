import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.css']
})
export class RestaurantsComponent implements OnInit {
  result : any;
  searchText;
  readonly rootURL = 'https://localhost:44351/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.httpService.get(this.rootURL+'/Restaurants').subscribe(res=>{
      this.result=res;
  });

  }
}
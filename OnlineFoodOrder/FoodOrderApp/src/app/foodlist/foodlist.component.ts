import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-foodlist',
  templateUrl: './foodlist.component.html',
  styleUrls: ['./foodlist.component.css']
})
export class FoodlistComponent implements OnInit {

  result : any;
  FoodCategoryId : any;
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
  
    this.httpService.post(this.rootURL+'/FoodLists', {FoodCategoryId: this.id}).subscribe(res =>{
      this.result = res;
      console.log(this.result);
  });

  }

  Add(id: any){
    if(localStorage.getItem('user')){
      localStorage.setItem('token', id);
      console.log(id);
      this.router.navigate(['/quantities']);
    }
    else{
      localStorage.setItem('url',this.rootURL+'/FoodLists')
      this.router.navigate(['/login'])
    }
   

  }

}

import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute}  from '@angular/router';
import {HttpClient} from '@angular/common/http';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-listoffood',
  templateUrl: './listoffood.component.html',
  styleUrls: ['./listoffood.component.css']
})
export class ListoffoodComponent implements OnInit {
  priceFormGroup:FormGroup;
  id:any;
  value;
  final = [];
  calculate;
  
  result: any;
  Qty;
  searchText;
  readonly rootURL = 'https://localhost:44351/api';
  constructor(private httpService : HttpClient, private router : Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) { 
    this.priceFormGroup = this.formBuilder.group({
      Quantity:['']
    })
  }


  ngOnInit(): void {
    //this.id = +this.activatedRoute.snapshot.paramMap.get('id')
    //console.log(this.id);
    
      this.httpService.post(this.rootURL+'/FoodLists', {FoodCategoryId: 1}).subscribe(res =>{
        this.result = res;
        console.log(this.result);
    });
  }

  Add(price: any, id:any){
        this.Qty = this.priceFormGroup.value.Quantity;
        if(this.Qty > 0){
        
          this.calculate = this.Qty * price;
           console.log(this.calculate);
            // this.final[id-1] =[{
            //   price: this.calculate
            // }];
            // console.log(id-1);
            this.final.push(this.calculate);
        }
      }
continue(){
  var sum = this.final.reduce((acc, cur) => acc + cur, 0);
console.log(sum)

// this.value = 0;
// for(var i=0; i<this.final.length;  i++){
//  // console.log(this.final[i]);
//   this.value = this.value + this.final[i];

// }
// console.log(this.value);
}



    //if(localStorage.getItem('user')){


     // localStorage.setItem('token', id);
      //console.log(id);
      //this.router.navigate(['/quantities']);
    // }
    // else{
    //   //localStorage.setItem('url',this.rootURL+'/FoodLists')
    //   this.router.navigate(['/login'])
    // }
   

  }




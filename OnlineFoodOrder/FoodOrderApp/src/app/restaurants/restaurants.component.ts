import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';


@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.css']
})
export class RestaurantsComponent implements OnInit {
  result : any;
  searchText;
  path;
  image:any;
  thumbnail:any;
  readonly rootURL = 'https://localhost:44351/api';
 constructor(private formBuilder:FormBuilder,private httpService: HttpClient,private router:Router,private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
//     this.httpService.get(this.rootURL+'/Restaurants').subscribe((data: any) => {

//       let objectURL = 'data:image/png;base64,' + data.Image;
// this.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);

// }, (err) => {
// console.log('HttpErrorResponse error occured.');
// });
this.httpService.get(this.rootURL+'/Restaurants').subscribe(res =>{
  this.result =res;
  

});
    
}
}
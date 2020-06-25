import { Component, OnInit } from '@angular/core';

import { NgForm } from '@angular/forms';
import {CourseService} from '../../shared/course.service';

@Component({
  selector: 'app-add-courses',
  templateUrl: './add-courses.component.html'

})
export class AddCoursesComponent implements OnInit{
 
  constructor(public courseService: CourseService) {}
  ngOnInit() {
    this.resetForm();

  }
  resetForm(form?:NgForm){
    if(form !=null)
    form.form.reset();
    this.courseService.formData ={
      CourseId:0,
      CourseName:''
     }
  }
  
  onSubmit(form:NgForm){
 
    this.insertRecord(form);
   }
 
   insertRecord(form:NgForm){
     console.log(this.courseService.formData);
     //console.log(form);
     this.courseService.postCourseDetail().subscribe(
       res=>{
         this.resetForm(form);
     },
       err=>{
         console.log(err);
       }
     )
   }
}
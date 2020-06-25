import { Component, OnInit } from '@angular/core';

import { StudentService } from '../shared/student.service';

import{NgForm} from '@angular/forms';
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

 result:any;

  constructor(public service:StudentService) {
    
   }

  ngOnInit(): void {
   this.resetForm();

  }

  resetForm(form?:NgForm){
    if(form !=null)
    form.form.reset();
    this.service.formData ={
      EnrollmentNumber:0,
      StudentFirstName:'',
      StudentLastName:'',
      StudentAge:0,
      StudentAddress:'',
      StudentEmailId:'',
      StudentMobileNumber:'',
      CourseSpecializationId:0,
      AcademicYear:0

    }
  }
  
  onSubmit(form:NgForm){
 
   this.insertRecord(form);
  }

  insertRecord(form:NgForm){
    console.log(this.service.formData);
    //console.log(form);
    this.service.postStudentDetail().subscribe(
      res=>{
        this.resetForm(form);
    },
      err=>{
        console.log(err);
      }
    )
  }


}

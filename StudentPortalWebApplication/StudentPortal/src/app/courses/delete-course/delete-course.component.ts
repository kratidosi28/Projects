import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CourseService } from '../../shared/course.service';

@Component({
  selector: 'app-delete-course',
  templateUrl: './delete-course.component.html'

})
export class DeleteCourseComponent implements OnInit {

  studentFormGroup:FormGroup;
  result:any;
  constructor(private formBuilder:FormBuilder,public service:CourseService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.studentFormGroup = this.formBuilder.group({
      EnrollmentNumber:['',Validators.required]
     
    })
  }
  onDelete(CourseId){
    console.log("hello");
    this.service.deleteCourse(CourseId).subscribe(res =>
      {
        this.result=res;
          this.service.refreshList();
    },
    err=>{
      console.log(err);
    }
    )
  

}
}

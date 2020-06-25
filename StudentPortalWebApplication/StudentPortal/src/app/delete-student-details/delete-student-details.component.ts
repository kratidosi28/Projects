import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../shared/student.service';

@Component({
  selector: 'app-delete-student-details',
  templateUrl: './delete-student-details.component.html',
  styleUrls: ['./delete-student-details.component.css']
})
export class DeleteStudentDetailsComponent implements OnInit {

  studentFormGroup:FormGroup;
  result:any;
  constructor(private formBuilder:FormBuilder,public service:StudentService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.studentFormGroup = this.formBuilder.group({
      EnrollmentNumber:['',Validators.required]
     
    })
  }
  onDelete(EnrollmentNumber){
    console.log("hello");
    this.service.deleteStudent(EnrollmentNumber).subscribe(res =>
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

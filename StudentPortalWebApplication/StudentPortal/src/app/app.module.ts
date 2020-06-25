import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule,Routes} from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import {StudentService} from './shared/student.service';
import {CourseService} from './shared/course.service';
import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { CoursesListComponent } from './courses/courses-list/courses-list.component';
import { AddCoursesComponent } from './courses/add-courses/add-courses.component';

import { AppRoutingModule } from './app.routing';
import{FormsModule,ReactiveFormsModule} from '@angular/forms';
import { StudentsListComponent } from './students-list/students-list.component';
import { DeleteStudentDetailsComponent } from './delete-student-details/delete-student-details.component';
import { DeleteCourseComponent } from './courses/delete-course/delete-course.component';



@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    CoursesListComponent,
    AddCoursesComponent,
 
    StudentsListComponent,
 
    DeleteStudentDetailsComponent,
    DeleteCourseComponent,
 
  
  ],
  imports: [
    BrowserModule,HttpClientModule,FormsModule,ReactiveFormsModule,AppRoutingModule
   
  ],
  providers: [StudentService,CourseService],
  bootstrap: [AppComponent]
})
export class AppModule { }

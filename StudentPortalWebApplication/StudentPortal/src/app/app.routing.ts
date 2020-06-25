import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentComponent } from './student/student.component';
import { CoursesListComponent } from './courses/courses-list/courses-list.component';
import { AddCoursesComponent } from './courses/add-courses/add-courses.component';
import { StudentsListComponent } from './students-list/students-list.component';
import { DeleteStudentDetailsComponent } from './delete-student-details/delete-student-details.component';
import { DeleteCourseComponent } from './courses/delete-course/delete-course.component';

const routes: Routes = [
  {path:'student',component: StudentComponent},
  {path:'courses-list',component:CoursesListComponent},
  {path:'add-courses',component:AddCoursesComponent},
  {path:'students-list',component:StudentsListComponent},
  {path:'delete-student-details',component:DeleteStudentDetailsComponent},
  {path:'delete-course',component:DeleteCourseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
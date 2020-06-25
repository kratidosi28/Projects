import{Course} from './course.model';
import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';


 @Injectable({
     providedIn:'root'
 })

export class CourseService {
    formData :Course;
    readonly rootURL ='http://localhost:63556/api';
   list:Course[];

    constructor(private http:HttpClient){}
   
    postCourseDetail(){
      return this.http.post(this.rootURL +'/Courses',this.formData);
  }

  refreshList(){
      this.http.get(this.rootURL +'/Courses')
      .toPromise()
      .then(res => this.list = res as Course[] );
    }

    deleteCourse(id){
        return this.http.delete(this.rootURL +'/Courses/'+id);
    }
}


import{Student} from './student.model';
import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Course } from './course.model';

@Injectable({
    providedIn:'root'
})

export class StudentService {
    formData :Student;
    readonly rootURL ='http://localhost:63556/api';
    list:Student[];

    constructor(private http:HttpClient){}
    postStudentDetail(){
        return this.http.post(this.rootURL +'/Students',this.formData);
    }

    refreshList(){
      this.http.get(this.rootURL +'/Students')
      .toPromise()
      .then(res => this.list = res as Student[] );
    }
    

    deleteStudent(id){
        return this.http.delete(this.rootURL +'/Students/'+id);
    }
}


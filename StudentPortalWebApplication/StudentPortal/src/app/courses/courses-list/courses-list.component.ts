import { Component, OnInit } from '@angular/core';
import {CourseService} from '../../shared/course.service';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html'
 
})
export class CoursesListComponent implements OnInit {

  constructor(public service:CourseService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

}

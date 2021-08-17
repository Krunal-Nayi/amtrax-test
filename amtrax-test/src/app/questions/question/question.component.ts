import { Component, OnInit } from '@angular/core';
import { QuestionModel } from 'src/app/_models';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  questionmodel: QuestionModel = new QuestionModel();

  constructor() { }

  ngOnInit(): void {
    // this.questionmodel.name = ""
    // this.questionmodel.type = ""
  }

}

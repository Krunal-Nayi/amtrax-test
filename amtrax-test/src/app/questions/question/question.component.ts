import { Component, OnInit } from '@angular/core';
import { QuestionModel } from 'src/app/_models';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  questions: QuestionModel[] = [
                                { name: '1', type: 'text' },
                                { name: '2', type: 'submit' },
                                { name: '3', type: 'checkbox' },
                                { name: '4', type: 'color' }
                              ];

  constructor() { }

  ngOnInit(): void {

  }
}

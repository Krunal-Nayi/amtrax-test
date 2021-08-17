import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { QuestionModel } from 'src/app/_models';

@Component({
  selector: 'app-question-maker',
  templateUrl: './question-maker.component.html',
  styleUrls: ['./question-maker.component.scss']
})
export class QuestionMakerComponent implements OnInit {

  formData = new FormGroup({ questions: new FormControl() });
  questions: QuestionModel[] = [];

  get formControls() { return this.formData.controls; }
  
  constructor() { }

  ngOnInit(): void { }

  onClickSubmit() {
    console.log(this.formControls.questions.value.split('\n'));

    let inputs = this.formControls.questions.value.split('\n');

    for (let i = 0; i < inputs.length; i++) {
      let input = inputs[i].split('|')
      let question = new QuestionModel();
      question.type = input[0]
      question.name = input[1]
      this.questions.push(question);
      console.log(question);
    }
  }

  onClickClear() {
    this.formControls.questions.setValue("");
    this.questions = [];
  }
}

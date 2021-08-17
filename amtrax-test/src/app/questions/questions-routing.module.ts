import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuestionMakerComponent } from './question-maker/question-maker.component';
import { QuestionComponent } from './question/question.component';

const routes: Routes = [
  { path: 'question', component: QuestionComponent },
  { path: '', component: QuestionMakerComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuestionsRoutingModule { }

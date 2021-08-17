import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuestionMakerComponent } from './question-maker/question-maker.component';

const routes: Routes = [
  { path: '', component: QuestionMakerComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuestionsRoutingModule { }

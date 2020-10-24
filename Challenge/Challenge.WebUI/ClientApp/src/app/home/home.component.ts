import { Component } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  inputText: string = null;

  constructor(private dataService: DataService) {
  }

  send() {
    let dto = {inputText: this.inputText};
    this.dataService.post('tasks', dto).subscribe(
      (result: any) => {

      },
      (error) => {
        console.error(error);
      }
    );
  }
}

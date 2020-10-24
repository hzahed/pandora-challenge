import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  inputText: string = null;

  constructor(private dataService: DataService, private snackBar: MatSnackBar) {
  }

  send() {
    const dto = {inputText: this.inputText};
    this.dataService.post('tasks', dto).subscribe(
      (result: any) => {
        this.snackBar.open('Input text queued successfully.');
        //this.inputText = null;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}

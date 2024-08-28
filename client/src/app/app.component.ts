import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'BookStore';
  books: any;

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/books').subscribe({
      next: response => this.books = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }
}
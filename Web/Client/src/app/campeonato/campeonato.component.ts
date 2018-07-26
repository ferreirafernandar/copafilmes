import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-campeonato',
  templateUrl: './campeonato.component.html',
  styleUrls: ['./campeonato.component.scss']
})
export class CampeonatoComponent implements OnInit {
  data;
  movies;

  constructor(private appService: AppService) { }

  ngOnInit() {
    this.data = this.appService.get();

    this.appService.postMovies(this.data)
      .subscribe(data => {
        this.movies = data;
      });
  }
}

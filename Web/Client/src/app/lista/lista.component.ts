import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { AppService } from '../app.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit {
  title = 'app';
  movies: Array<any> = [];
  selectedMovies = [];
  result: any;
  id: string;
  primaryTitle: string;
  year: string;
  averageRatingnumber;

  constructor(private appService: AppService, private router: Router) {}

  ngOnInit() {
    this.getMovies();
  }

  getMovies() {
    this.appService.getMovies().subscribe(
      (response: any) => {
        this.movies = response;
      },
      error => {
        console.log('error ', error);
      }
    );
  }

  onCheck(e) {
    if (e.target.checked) {
      const findEl = this.movies.find(filme => filme.id === e.target.value);
      if (this.selectedMovies.length >= 16) {
        e.stopPropagation();
        return alert('Você só pode adicionar 16 filmes seu imbecil!');
      }
      this.selectedMovies.push(findEl);
    } else {
      const index = this.movies.indexOf(filme => filme.id === e.target.value);
      this.selectedMovies.splice(index, 1);
    }
  }

  gerarCampeonato() {
    this.appService.set(this.selectedMovies);
    this.router.navigate(['/campeonato']);
  }
}

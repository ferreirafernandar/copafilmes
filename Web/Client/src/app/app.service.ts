import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class AppService {

  storedData;

  constructor(private http: HttpClient) {

  }

  getMovies(): Observable<Object> {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .get('http://localhost:54431/api/movies', { headers });
  }

  returnGame(): Observable<Object> {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .get('http://localhost:54431/api/movies/game', { headers });
  }

  postMovies(movies) {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .post('http://localhost:54431/api/movies/game', { movies }, { headers });
  }

  public get() {
    return this.storedData;
  }

  public set(data) {
    this.storedData = data;
  }
}

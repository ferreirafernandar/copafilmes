import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { AppService } from './app.service';
import { HttpClientModule } from '@angular/common/http';
import { ListaComponent } from './lista/lista.component';
import { CampeonatoComponent } from './campeonato/campeonato.component';

const ROUTES: Routes = [
  {
    path: 'lista',
    component: ListaComponent
  },
  {
    path: 'campeonato',
    component: CampeonatoComponent
  },
  { path: '',
    redirectTo: '/lista',
    pathMatch: 'full'
  },
];

@NgModule({
  declarations: [
    AppComponent,
    ListaComponent,
    CampeonatoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }

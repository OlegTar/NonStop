import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { DocumentsComponent } from './documents/documents.component';
import { NavComponent } from './common/nav/nav.component';
import { UniversityComponent } from './university/university.component';

import { MaterialModule } from './material/material.module';
import { UniversityListComponent } from './university/university-list/university-list.component';
import { UniversityFilterComponent } from './university/university-filter/university-filter.component';
import { HeaderComponent } from './common/header/header.component';
import { FooterComponent } from './common/footer/footer.component';
import { LinksComponent } from './common/links/links.component';
import { RatingComponent } from './rating/rating.component';
import { GeneralComponent } from './general/general.component';

const appRoutes: Routes = [
  { path: 'general', component: GeneralComponent },
  { path: 'university', component: UniversityComponent },
  { path: 'mydocs', component: DocumentsComponent },
  { path: 'rating', component: RatingComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    DocumentsComponent,
    NavComponent,
    UniversityComponent,
    UniversityListComponent,
    UniversityFilterComponent,
    HeaderComponent,
    FooterComponent,
    LinksComponent,
    RatingComponent,
    GeneralComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

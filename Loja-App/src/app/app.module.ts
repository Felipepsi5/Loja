import { LojaService } from './services/loja.service';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ProdutoComponent } from './components/produto/produto.component';
import { FornecedorComponent } from './components/fornecedor/fornecedor.component';
import { FooterComponent } from './components/footer/footer.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgxMaskModule} from 'ngx-mask';
import { CommonModule } from '@angular/common';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';
import {NgxPaginationModule} from 'ngx-pagination';
import {BsDropdownModule, TooltipModule, ModalModule} from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { MenuComponent } from './components/menu/menu.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FornecedoreditComponent } from './components/fornecedor/fornecedoredit/fornecedoredit.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MenuComponent,
    FooterComponent,
    FornecedorComponent,
    FornecedoreditComponent,
    ProdutoComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    NgxMaskModule.forRoot(),
    ToastrModule.forRoot(),
    ReactiveFormsModule,
    NgxPaginationModule,
    FormsModule

  ],
  providers: [
     HttpClient,
     LojaService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

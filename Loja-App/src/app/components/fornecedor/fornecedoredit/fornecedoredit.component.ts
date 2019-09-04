import { ToastrModule, ToastrService } from 'ngx-toastr';
import { LojaService } from './../../../services/loja.service';
import { Component, OnInit } from '@angular/core';
import { Fornecedores } from 'src/app/_models/Fornecedores';

@Component({
  selector: 'app-fornecedoredit',
  templateUrl: './fornecedoredit.component.html',
  styleUrls: ['./fornecedoredit.component.css']
})
export class FornecedoreditComponent implements OnInit {
  _filtroLista = '';
  fornecedoresFiltrados: Fornecedores[];
  fornecedores: Fornecedores[];
  fornecedor: Fornecedores;
  constructor(
    private lojaService: LojaService
  , private toastr: ToastrService

  ) { }

  ngOnInit() {
    this.getFornecedores();
  }
  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.fornecedoresFiltrados = this._filtroLista ? this.filtrarFornecedores(this.filtroLista) : this.fornecedores;
  }
  filtrarFornecedores(filtrarPor: string): Fornecedores[] {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.fornecedores.filter(
          fornecedor => fornecedor.nomedaempresa.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
  }
  getFornecedores() {
    this.lojaService.getAllFornecedor().subscribe(
      (_fornecedor: Fornecedores[]) => {
        this.fornecedores = _fornecedor;
        this.fornecedoresFiltrados = this.fornecedores;
        console.log(this.fornecedores)
      }, error => {
        this.toastr.error(`Erro ao tentar carregar Fornecedor`);

      }
    )
  }

}

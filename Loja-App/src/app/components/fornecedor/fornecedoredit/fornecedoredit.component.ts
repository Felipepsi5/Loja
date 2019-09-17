import { ToastrModule, ToastrService } from 'ngx-toastr';
import { LojaService } from './../../../services/loja.service';
import { Component, OnInit } from '@angular/core';
import { Fornecedores } from 'src/app/_models/Fornecedores';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-fornecedoredit',
  templateUrl: './fornecedoredit.component.html',
  styleUrls: ['./fornecedoredit.component.css']
})
export class FornecedoreditComponent implements OnInit {
  _filtroLista = '';
  bodyDeletarFornecedor = '';
  registerForm: FormGroup;
  fornecedoresFiltrados: Fornecedores[];
  fornecedores: Fornecedores[];
  fornecedor: Fornecedores;
  constructor(
    private lojaService: LojaService
  , private toastr: ToastrService
  , private fb: FormBuilder

  ) { }

  ngOnInit() {
    this.getFornecedores();
    this.validation();
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
          fornecedor => fornecedor.nomeDaEmpresa.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
  }
  getFornecedores() {
    this.lojaService.getAllFornecedor().subscribe(
      (fornecedor: Fornecedores[]) => {
        this.fornecedores = fornecedor;
        this.fornecedoresFiltrados = this.fornecedores;

      }, error => {
        this.toastr.error(`Erro ao tentar carregar Fornecedor`);

      }
    );
  }
  excluirFornecedor(fornecedor: Fornecedores, template: any) {
    this.openModal(template);
    this.fornecedor = fornecedor;
    this.bodyDeletarFornecedor = `Tem certeza que deseja excluir o Fornecedor: ${fornecedor.nomeDaEmpresa}`;
  }
  confirmeDelete(template: any) {
    this.lojaService.deleteFornecedor(this.fornecedor.id).subscribe(
      () => {
        template.hide();
        this.getFornecedores();
        this.toastr.success('Deletado com Sucesso');
      }, error => {
        this.toastr.error('Erro ao tentar Deletar');

      }
    );
  }
  validation() {
    this.registerForm = this.fb.group({
        nomeDaEmpresa: ['', Validators.required],
        nomeDoContato: ['', Validators.required],
        cargoDoContato: ['', Validators.required],
        endereco: ['', Validators.required ],
        cidade: ['', Validators.required],
        uf: ['', Validators.required],
        cep: ['', Validators.required],
        pais: ['', Validators.required],
        telefone: ['', Validators.required]
      });
  }
  editarFornecedor(fornecedor: Fornecedores, template: any) {
    this.openModal(template);
    this.fornecedor = Object.assign({}, fornecedor);
    this.registerForm.patchValue(this.fornecedor);
    console.log(this.fornecedor);
  }

  salvarAlteracao(template: any) {
     this.fornecedor = Object.assign({id: this.fornecedor.id}, this.registerForm.value);
     console.log(this.fornecedor);
     this.lojaService.putFornecedor(this.fornecedor).subscribe(
       () => {
        template.hide();
        this.toastr.success('Editado com Sucesso!');
        this.getFornecedores();
      }, error => {
        this.toastr.error(`Erro ao Editar: ${error}`);
      }
     );
  }

  openModal(template: any) {
    template.show();
  }

}

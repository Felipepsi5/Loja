import { LojaService } from './../../services/loja.service';
import { Fornecedores } from './../../_models/Fornecedores';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-fornecedor',
  templateUrl: './fornecedor.component.html',
  styleUrls: ['./fornecedor.component.css']
})
export class FornecedorComponent implements OnInit {
  titulo = 'Fornecedores';
  fornecedores: Fornecedores;
  modoSalvar = 'post';
  registerForm: FormGroup;
  constructor(
    private fb: FormBuilder
  , private toastr: ToastrService
  , private lojaservice: LojaService
  ) { }

  ngOnInit() {
    this.validation();
  }
  validation() {
    this.registerForm = this.fb.group({
        nomedaempresa: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(50)]],
        nomedocontato: ['', Validators.required],
        cargodocontato: ['', Validators.required],
        endereco: ['', Validators.required ],
        cidade: ['', Validators.required],
        uf: ['', Validators.required],
        cep: ['', Validators.required],
        pais: ['', Validators.required],
        telefone: ['', Validators.required]
      });
  }

  salvarFornecedor(template: any) {
    this.fornecedores = Object.assign({}, this.registerForm.value);
    this.lojaservice.postFornecedor(this.fornecedores).subscribe(
      () => {
        this.toastr.success('Salvo com Sucesso!');
      }, error => {
        this.toastr.error(`Erro ao Editar: ${error}`);
      }
    );
    }
}


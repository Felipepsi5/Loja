import { DateTimeFormatPipePipe } from './../_helps/DateTimeFormatPipe.pipe';

export class Fornecedores {
  constructor() {}

  id: number;
  nomeDaEmpresa: string;
  nomeDoContato: string;
  cargoDoContato: string;
  endereco: string;
  cidade: string;
  uf: string;
  cep: string;
  pais: string;
  telefone: string;
  DataCadastro: Date;
}

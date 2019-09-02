import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fornecedores } from '../_models/Fornecedores';

@Injectable({
  providedIn: 'root'
})
export class LojaService {
  baseURLFornecedor = 'http://localhost:5000/api/Fornecedores';

constructor(private http: HttpClient) { }

  getAllFornecedor(): Observable<Fornecedores[]> {
    return this.http.get<Fornecedores[]>(this.baseURLFornecedor);
  }
  getFornecedorById(id: number): Observable<Fornecedores> {
     return this.http.get<Fornecedores>(`${this.baseURLFornecedor}/${id}`);
  }
  postFornecedor(fornecedor: Fornecedores) {
    return this.http.post(this.baseURLFornecedor, fornecedor);
  }
  putFornecedor(fornecedor: Fornecedores) {
   return this.http.put(`${this.baseURLFornecedor}/${fornecedor.id}`, fornecedor);
  }
  deleteFornecedor(id: number) {
    return this.http.delete(`${this.baseURLFornecedor}/${id}`);
  }
}

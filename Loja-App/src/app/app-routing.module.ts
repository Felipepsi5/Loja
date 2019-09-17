import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FornecedorComponent } from './components/fornecedor/fornecedor.component';
import { FornecedoreditComponent } from './components/fornecedor/fornecedoredit/fornecedoredit.component';

const routes: Routes = [
  { path: 'fornecedor', component: FornecedorComponent },
  { path: 'fornecedoredit',  component: FornecedoreditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

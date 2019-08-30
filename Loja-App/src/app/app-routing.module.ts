import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FornecedorComponent } from './components/fornecedor/fornecedor.component';


const routes: Routes = [
  { path: 'fornecedor', component: FornecedorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEditComponent } from './components/customer/create-edit/create-edit.component';
import { CustomerComponent } from './components/customer/customer.component';

const routes: Routes = [
  { path: 'customers', component: CustomerComponent },
  { path: 'organization/create', component: CreateEditComponent },
  { path: 'organization/edit/:id', component: CreateEditComponent },
  { path: '', redirectTo: '/customers', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}

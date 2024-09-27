import { Component, OnInit } from '@angular/core';
import { IOrganizationEntherprise } from '../../interfaces/IOrganizationEntherprise';
import { OrganizationEnterpriseService } from '../../services/organization-enterprise.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss'],
  providers: [OrganizationEnterpriseService],
})
export class CustomerComponent implements OnInit {
  isVisible: boolean = false;
  customers: IOrganizationEntherprise[] = [];

  constructor(
    private organization: OrganizationEnterpriseService,
    private router: Router
  ) {}

  ngOnInit() {
    this.initializeCustomers();
  }

  initializeCustomers() {
    this.organization.getAll().subscribe((data) => {
      this.customers = data;
    });
  }

  addNewOrganization() {
    this.isVisible = true;
    this.router.navigate(['/organization/create']);
  }

  editCustomer(customer: any) {
    this.router.navigate(['/organization/edit', customer.id]);
  }

  deleteCustomer(customer: any) {
    this.organization.delete(customer.id).subscribe(() => {
      this.initializeCustomers();
    });
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrganizationEnterpriseService } from '../../../services/organization-enterprise.service';
import { IOrganizationEntherprise } from '../../../interfaces/IOrganizationEntherprise';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-edit',
  templateUrl: './create-edit.component.html',
  styleUrls: ['./create-edit.component.css'],
  providers: [MessageService],
})
export class CreateEditComponent implements OnInit {
  @Input() isVisible: boolean = false;
  organizationForm: FormGroup;
  isEditMode: boolean = false;
  organizationId?: string;

  constructor(
    private fb: FormBuilder,
    private organizationService: OrganizationEnterpriseService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.organizationForm = this.fb.group({
      name: ['', Validators.required],
      classificationType: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    debugger;
    this.route.params.subscribe((params) => {
      const id = params['id'];
      if (id) {
        this.isEditMode = true;
        this.loadOrganization(id);
      }
    });
  }

  loadOrganization(id: string) {
    this.organizationService.getById(id).subscribe((organization) => {
      this.organizationId = organization.id;
      this.organizationForm.patchValue(organization);
    });
  }

  saveOrganization() {
    if (this.organizationForm.invalid) {
      return;
    }

    const organization: IOrganizationEntherprise = this.organizationForm.value;
    if (this.isEditMode && this.organizationId) {
      organization.id = this.organizationId;
      this.organizationService.update(organization).subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: 'Organização atualizada',
        });
        this.router.navigate(['/customers']);
      });
    } else {
      this.organizationService.create(organization).subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: 'Organização criada',
        });
        this.router.navigate(['/customers']);
      });
    }
  }

  clearForm() {
    this.organizationForm.reset();
    this.isEditMode = false;
  }
}

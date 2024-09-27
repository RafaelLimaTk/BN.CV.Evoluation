import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { IOrganizationEntherprise } from '../interfaces/IOrganizationEntherprise';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/dev';

@Injectable({
  providedIn: 'root',
})
export class OrganizationEnterpriseService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<IOrganizationEntherprise[]> {
    return this.http
      .get<{
        success: boolean;
        type: string;
        message: string;
        data: IOrganizationEntherprise[];
      }>(`${environment.apiUrl}/api/v1/OrganizationEntherprise`)
      .pipe(map((response) => response.data));
  }

  create(organizationEnterprise: IOrganizationEntherprise): Observable<any> {
    return this.http.post(
      `${environment.apiUrl}/api/v1/OrganizationEntherprise`,
      organizationEnterprise
    );
  }

  update(organizationEnterprise: IOrganizationEntherprise): Observable<any> {
    return this.http.post(
      `${environment.apiUrl}/api/v1/OrganizationEntherprise`,
      organizationEnterprise
    );
  }

  delete(id: string): Observable<any> {
    return this.http.delete(
      `${environment.apiUrl}/api/v1/OrganizationEntherprise/${id}`
    );
  }

  getById(id: string): Observable<IOrganizationEntherprise> {
    return this.http
      .get<{
        success: boolean;
        type: string;
        message: string;
        data: IOrganizationEntherprise;
      }>(`${environment.apiUrl}/api/v1/OrganizationEntherprise/${id}`)
      .pipe(map((response) => response.data));
  }
}

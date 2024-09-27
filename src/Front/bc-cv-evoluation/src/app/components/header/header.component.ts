import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  items: any[] = [];
  constructor() {}

  ngOnInit() {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        routerLink: '/',
      },
      {
        label: 'Sobre',
        icon: 'pi pi-info-circle',
        routerLink: '/sobre',
      },
      {
        label: 'Serviços',
        icon: 'pi pi-cog',
        routerLink: '/servicos',
      },
      {
        label: 'Contato',
        icon: 'pi pi-envelope',
        routerLink: '/contato',
      },
    ];
  }
}

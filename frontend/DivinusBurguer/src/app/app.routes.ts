import {Routes} from '@angular/router'
import { HomeComponent } from './home/home.component';
import { CardapioComponent } from './cardapio/cardapio.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';

export const ROUTES: Routes = [
    {path:'',component:HomeComponent},
    {path:'cardapio',component:CardapioComponent},
    {path:'carrinho',component:CarrinhoComponent}
]
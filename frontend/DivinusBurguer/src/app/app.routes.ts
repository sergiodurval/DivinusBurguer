import {Routes} from '@angular/router'
import { HomeComponent } from './home/home.component';
import { CardapioComponent } from './cardapio/cardapio.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { OrderSummaryComponent } from './order-summary/order-summary.component';
import { HistoricoComponent } from './historico/historico.component';

export const ROUTES: Routes = [
    {path:'',component:HomeComponent},
    {path:'cardapio',component:CardapioComponent},
    {path:'carrinho',component:CarrinhoComponent},
    {path:'checkout',component:CheckoutComponent},
    {path:'login',component:LoginComponent},
    {path:'register',component:RegisterComponent},
    {path:'order-summary/:numeroPedido',component:OrderSummaryComponent},
    {path:'historico',component:HistoricoComponent}
]
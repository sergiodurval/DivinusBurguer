import {Routes} from '@angular/router'
import { HomeComponent } from './home/home.component';
import { CardapioComponent } from './cardapio/cardapio.component';

export const ROUTES: Routes = [
    {path:'',component:HomeComponent},
    {path:'cardapio',component:CardapioComponent}
]
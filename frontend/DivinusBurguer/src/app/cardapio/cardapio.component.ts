import { Component, OnInit, Input, Injectable } from '@angular/core';
import { Food } from './food.model';
import { FoodService } from './food.service';
import { NotificacaoService } from 'app/notificacao/notificacao.service';
import { CarrinhoService } from 'app/carrinho/carrinho.service';
import {ToastyService, ToastyConfig, ToastOptions, ToastData} from 'ng2-toasty';
import { AuthenticationService } from 'app/login/authentication.service';
import { User } from 'app/login/user.model';
import { Router, NavigationEnd} from '@angular/router';

@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css'],
})

@Injectable()
export class CardapioComponent implements OnInit {

  foods : Food[]
  itemSelecionado : Food
  user: User
  isLogged : boolean
  

  constructor(private foodService:FoodService , private notificationService:NotificacaoService,
              private carrinhoService:CarrinhoService,
              private toastyService:ToastyService, 
              private toastyConfig: ToastyConfig,
              private authenticationService: AuthenticationService,
              private router: Router) {
                this.router.events.subscribe((e) => {
                  console.log(e)
                  if (e instanceof NavigationEnd) {
                      if(this.authenticationService.isLoggedIn()){
                        this.user = this.authenticationService.getUser()
                        if(this.authenticationService.mensagemBoasVindas){
                          this.authenticationService.showMensagem(false)
                          setTimeout(()=>{
                            this.addToast('aviso',this.user.email)
                       }, 1000);
                        }
                      
                        

                      }
                  }
               });
               }

  ngOnInit() {
    if(this.user != undefined){
      this.isLogged = true
    }

    this.foodService.foods()
    .subscribe(foods => this.foods = foods)
  }


  addCart(id:string):void{
     this.carrinhoService.adicionarCarrinho(this.getFood(id))
     this.addToast(this.getName(id))
  }

  getName(id:string):string{
     for(let food of this.foods){
       if(food.id == id){
         return food.name;
       }
     }
  }

  getFood(id:string):Food{
    for(let food of this.foods){
       if(food.id == id){
         return food;
       }
    }
  }

  addToast(title:string , userName?:string) {
    var toastOptions:ToastOptions = {
        title: title,
        msg: (userName != undefined) ? `${userName} seja bem vindo` : 'Adicionado ao carrinho',
        showClose: true,
        timeout: 2000,
        theme: 'bootstrap',
        onAdd: (toast:ToastData) => {
            console.log('Toast ' + toast.id + ' has been added!');
        },
        onRemove: function(toast:ToastData) {
            console.log('Toast ' + toast.id + ' has been removed!');
        }
    };
    
    this.toastyService.success(toastOptions);
  }

  logoff():void{
     this.authenticationService.logoff()
     this.carrinhoService.esvaziarCarrinho()
     this.router.navigate(['/'])
  }

}

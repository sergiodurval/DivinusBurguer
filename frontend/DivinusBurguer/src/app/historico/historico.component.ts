import { Component, OnInit } from '@angular/core';
import { FoodHistory } from './foodHistory.model';
import { User } from 'app/login/user.model';
import { FoodHistoryService } from './foodHistory.service';
import { AuthenticationService } from 'app/login/authentication.service';
import { Router, NavigationEnd } from '@angular/router';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';
import { Food } from 'app/cardapio/food.model';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.css']
})
export class HistoricoComponent implements OnInit {
  
  isLogged : boolean
  foodHistory : FoodHistory[]
  user: User 

  constructor(private foodHistoryService:FoodHistoryService,
              private authenticationService: AuthenticationService,
              private toastyService:ToastyService,
              private toastyConfig: ToastyConfig,
              private router: Router  ) {
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

     this.foodHistoryService.history(this.user.id)
      .subscribe(data => this.foodHistory = data)
       
    }

    


  }

  imprimir(){
     let totalItems = this.foodHistory.length
     
     for(var i = 0 ; i < totalItems ; i++){
        let foods = this.foodHistory[i].foods
        console.log(`Número do pedido:${this.foodHistory[i].orderNumber}`)
        console.log(`Valor total do pedido:${this.foodHistory[i].totalValue}`)
        console.log('Itens do pedido:')
        for(let food of foods){
          console.log(food.name)
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
    this.router.navigate(['/'])
 }

}

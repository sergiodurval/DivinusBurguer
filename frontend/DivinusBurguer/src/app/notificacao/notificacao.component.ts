import { Component, OnInit } from '@angular/core';
import {ToastyService, ToastyConfig, ToastOptions, ToastData} from 'ng2-toasty';
import { NotificacaoService } from './notificacao.service';

@Component({
  selector: 'app-notificacao',
  templateUrl: './notificacao.component.html',
  styleUrls: ['./notificacao.component.css']
})
export class NotificacaoComponent implements OnInit {
  
  title : string

  constructor(private toastyService:ToastyService, private toastyConfig: ToastyConfig,
    private notificationService:NotificacaoService) { 
    this.toastyConfig.theme = 'bootstrap';
 }

  ngOnInit() {
    this.notificationService.notificacao.subscribe(message => {
      this.title = message
      this.addToast()
    })
  }

 
  addToast() {
    var toastOptions:ToastOptions = {
        title: this.title,
        msg: "Adicionado ao carrinho",
        showClose: true,
        timeout: 5000,
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

}

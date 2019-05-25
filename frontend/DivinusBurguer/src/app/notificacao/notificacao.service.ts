import { EventEmitter } from "@angular/core";

export class NotificacaoService{
    notificacao = new EventEmitter<string>()


    notificar(mensagem:string){
        this.notificacao.emit(mensagem)
    }
}
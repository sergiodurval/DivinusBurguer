import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { User } from "./user.model";
import { DIVINUSBURGUER_API } from '../app.api'
import 'rxjs/add/operator/do'

@Injectable()
export class AuthenticationService{
    user : User
    mensagemBoasVindas : boolean
    token:string

    constructor(private http:HttpClient){
        this.mensagemBoasVindas = true
    }


    isLoggedIn():boolean{
        return this.user != undefined
    }

    showMensagem(exibir:boolean){
        this.mensagemBoasVindas = exibir
    }

    logoff():void{
        this.user = null
    }

    getUser():User{
        return this.user
    }

    setUser(user:User){
        this.user = user
    }

    login(user:User):Observable<User>{
        this.user = user
        return this.http.post<User>(`${DIVINUSBURGUER_API}/api/user/Authenticate`,user)
    }

    register(user:User):Observable<User>{
        return this.http.post<User>(`${DIVINUSBURGUER_API}/api/user/Register`,user)
    }

    getToken():Observable<any>{
        var userData = "username=" + this.user.email + "&password=" + this.user.password + "&grant_type=password"
        console.log(userData)
        var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded','No-Auth':'True' });
        return this.http.post<any>(`${DIVINUSBURGUER_API}/token`,userData,{headers: reqHeader})
    }
}
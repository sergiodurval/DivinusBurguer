import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { User } from "./user.model";
import { DIVINUSBURGUER_API } from '../app.api'


@Injectable()
export class AuthenticationService{

    constructor(private http:HttpClient){}

    login(user:User):Observable<User>{
        return this.http.post<User>(`${DIVINUSBURGUER_API}/api/user/Authenticate`,user)
    }

    register(user:User):Observable<User>{
        return this.http.post<User>(`${DIVINUSBURGUER_API}/api/user/Register`,user)
    }

    getToken():Observable<any>{
        const email = "gabrielamp18@gmail.com"
        const senha = "chocolicia"
        var userData = "username=" + email + "&password=" + senha + "&grant_type=password"
        console.log(userData)
        var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded','No-Auth':'True' });
        return this.http.post<any>(`${DIVINUSBURGUER_API}/token`,userData,{headers: reqHeader})
    }
}
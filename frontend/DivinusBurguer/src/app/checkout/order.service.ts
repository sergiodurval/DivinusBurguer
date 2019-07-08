import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Order } from './order.model';
import { DIVINUSBURGUER_API } from 'app/app.api';
import { Injectable } from '@angular/core';

@Injectable()
export class OrderService{

    constructor(private http:HttpClient){}


    createOrder(order:Order,token:string){
        let headers = new HttpHeaders()
        headers =  headers.set('Authorization',`Bearer  ${token}`)
        return this.http.post(`${DIVINUSBURGUER_API}/api/order/CreateOrder`,order,{headers:headers})
    }
}
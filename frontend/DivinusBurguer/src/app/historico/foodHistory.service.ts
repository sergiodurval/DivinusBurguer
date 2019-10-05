import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http'
import {Observable} from 'rxjs/Observable'
import 'rxjs/add/operator/map'

import { DIVINUSBURGUER_API } from '../app.api'
import { FoodHistory } from './foodHistory.model'

@Injectable()
export class FoodHistoryService{
   
    constructor(private http:HttpClient){}

    history(userId:string):Observable<FoodHistory[]>{
        let params = new HttpParams().set("id",userId);
        return this.http.get<FoodHistory[]>(`${DIVINUSBURGUER_API}/api/order/OrderHistory`,{params:params})
    }
}
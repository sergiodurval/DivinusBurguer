import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import {Observable} from 'rxjs/Observable'
import 'rxjs/add/operator/map'

import { DIVINUSBURGUER_API } from '../app.api'
import { Food } from './food.model';



@Injectable()
export class FoodService{
    
    constructor(private http:HttpClient){}

    foods(): Observable<Food[]>{
        return this.http.get<Food[]>(`${DIVINUSBURGUER_API}/api/food/GetAllOrdered`)
        
    }
}
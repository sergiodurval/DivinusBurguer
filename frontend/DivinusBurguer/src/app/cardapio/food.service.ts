import { Http } from '@angular/http'
import { Injectable } from '@angular/core'
import {Observable} from 'rxjs/Observable'
import 'rxjs/add/operator/map'

import { DIVINUSBURGUER_API } from '../app.api'
import { Food } from './food.model';



@Injectable()
export class FoodService{
    
    constructor(private http:Http){}

    foods(): Observable<Food[]>{
        return this.http.get(`${DIVINUSBURGUER_API}/api/food/GetAll`)
        .map(response => response.json())
    }
}
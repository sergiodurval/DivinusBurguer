import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Address } from "./address.model";
import { DIVINUSBURGUER_API } from '../app.api'

@Injectable()
export class AddressService{
    
    constructor(private http:Http){}
    
    getAddress(zipCode:string):Observable<Address>{
        return this.http.get(`${DIVINUSBURGUER_API}/api/address/Search?zipcode=${zipCode}`)
        .map(response => response.json())
    }
}
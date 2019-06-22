import { Injectable } from "@angular/core";
import { Http , Response  } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Address } from "./address.model";
import { DIVINUSBURGUER_API } from '../app.api'
import 'rxjs/add/operator/do';

@Injectable()
export class AddressService{
    
    constructor(private http:Http){}
    
    getAddress(zipCode:string):Observable<Address>{
        return this.http.get(`${DIVINUSBURGUER_API}/api/address/Search?zipcode=${zipCode}`)
        .map((response: Response) => <Address>response.json())
        .do(data => console.log('endereço: ' + JSON.stringify(data)))
    }

    getState():Array<string>{
        let listaEstados = Array<string>()
        listaEstados.push("AC")
        listaEstados.push("AL")
        listaEstados.push("AP")
        listaEstados.push("AM")
        listaEstados.push("BA")
        listaEstados.push("CE")
        listaEstados.push("DF")
        listaEstados.push("ES")
        listaEstados.push("GO")
        listaEstados.push("MA")
        listaEstados.push("MT")
        listaEstados.push("MS")
        listaEstados.push("MG")
        listaEstados.push("PA")
        listaEstados.push("PB")
        listaEstados.push("PR")
        listaEstados.push("PE")
        listaEstados.push("PI")
        listaEstados.push("RJ")
        listaEstados.push("RN")
        listaEstados.push("RS")
        listaEstados.push("RO")
        listaEstados.push("RR")
        listaEstados.push("SC")
        listaEstados.push("SP")
        listaEstados.push("SE")
        listaEstados.push("TO")
        return listaEstados
    }
}
import { Address } from "./address.model";
import { ItemCarrinho } from "app/carrinho/itemCarrinho.model";
import { PurchaseOrder } from "./purchaseOrder.model";

export class Order{
    public orderNUmber:number;
    
    constructor(
        public address:Address,
        public paymentMethod:string,
        public purchaseOrder:Array<PurchaseOrder>,
        public totalValue:number,
        public idUser:string){}
}
import { Address } from "./address.model";
import { ItemCarrinho } from "app/carrinho/itemCarrinho.model";

export class Order{

    constructor(
        public address:Address,
        public paymentMethod:string,
        public itensCarrinho:Array<ItemCarrinho>,
        public valorTotal:number){}
}
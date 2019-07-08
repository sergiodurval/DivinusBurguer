import { ItemCarrinho } from "app/carrinho/itemCarrinho.model";

export class PurchaseOrder{
    public id:string
    public name:string
    public description:string
    public price:number
    public imageName:string
    public category:string
    public quantity:number


    convertToPurchaseOrder(itemCarrinho:Array<ItemCarrinho>):Array<PurchaseOrder>{
        let lista : Array<PurchaseOrder> = new Array<PurchaseOrder>()
        for(let item of itemCarrinho){
            let purchaseOrder = new PurchaseOrder();
            purchaseOrder.category = item.food.category
            purchaseOrder.id = item.food.id
            purchaseOrder.imageName = item.food.imageName
            purchaseOrder.name = item.food.name
            purchaseOrder.price = item.food.price
            purchaseOrder.quantity = item.quantidade
            purchaseOrder.description = item.food.description
            lista.push(purchaseOrder)
        }
        return lista
    }
}
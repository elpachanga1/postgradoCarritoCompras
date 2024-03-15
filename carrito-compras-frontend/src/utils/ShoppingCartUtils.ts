import { Item, ShoppingCart } from "../entities/Interfaces";
import * as ItemService from '../services/ItemService';

export const getShoppingCart = async (): Promise<ShoppingCart> => {
    const items: Item[] = await ItemService.getItems();
    const currentCountProducts = items.reduce((total, item) => total + item.quantity, 0);
    const currentTotal = items.reduce((total, item) => total + item.totalPrice, 0);
    return {
        items,
        countProducts: currentCountProducts,
        total: currentTotal
    };
}
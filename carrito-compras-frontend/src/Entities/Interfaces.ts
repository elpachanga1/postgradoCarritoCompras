export interface Product {
    id: number;
    sku: string;
    name: string;
    description?: string;
    availableUnits: number;
    unitPrice: number;
    image?: string;
}

export interface Item {
    id: number;
    idProduct: number;
    quantity: number;
    isDeleted: boolean;
    totalPrice: number;
}

export interface ShoppingCart {
    items: Item[];
    countProducts: number;
    total: number;
}
export interface Product {
    id: number;
    sku: string;
    name: string;
    description?: string;
    availableUnits: number;
    unitPrice: number;
    image?: string;
}

export interface ProductProps {
    allProducts: Product[];
    setAllProducts: React.Dispatch<React.SetStateAction<Product[]>>;
    countProducts: number;
    setCountProducts: React.Dispatch<React.SetStateAction<number>>;
    total: number;
    setTotal: React.Dispatch<React.SetStateAction<number>>;
}
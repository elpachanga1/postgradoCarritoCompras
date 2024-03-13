
import axios from "axios";
import { Product } from "../entities/Interfaces";

const apiUrl: string = process.env.REACT_APP_API_URL || "";

export const addProductToShoppingCart = async (product: Product): Promise<any> => {
    try {
        const response = await axios.post<any>(`${apiUrl}/Store/AddProductToShoppingCart?IdUser=${1}&IdProduct=${product.id}&Quantity=${1}`);
        console.log(response);
        return response.data;
    } catch (error: any) {
        console.log("Error: ", error.message);
        return [];
    }
};
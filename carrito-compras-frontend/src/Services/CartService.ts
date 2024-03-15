
import axios from "axios";
import { Operation } from "../entities/Interfaces";

const apiUrl: string = process.env.REACT_APP_API_URL || "";

export const addProductToShoppingCart = async (productId: number, operation: Operation): Promise<any> => {
    try {
        const quantity = operation === "increase" ? 1 : -1;
        const response = await axios.post<any>(`${apiUrl}/Store/AddProductToShoppingCart?IdUser=${1}&IdProduct=${productId}&Quantity=${quantity}`);
        console.log(response);
        return response.data;
    } catch (error: any) {
        console.log("Error: ", error.message);
        return [];
    }
};

export const EmptyShoppingCart = async (): Promise<any> => {
    try {
        const response = await axios.delete<any>(`${apiUrl}/Store/EmptyShoppingCart?IdUser=${1}`);
        console.log(response);
        return response.data;
    } catch (error: any) {
        console.log("Error: ", error.message);
        return [];
    }
};

export const DeleteProductFromShoppingCart = async (idItem: number): Promise<any> => {
    try {
        const response = await axios.delete<any>(`${apiUrl}/Store/DeleteProductFromShoppingCart?IdUser=${1}&IdItem=${idItem}`);
        console.log(response);
        return response.data;
    } catch (error: any) {
        console.log("Error: ", error.message);
        return [];
    }
};

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
export const UpdateProductFromShoppingCart = async (IdProduct: number, quantity: number): Promise<any> => {
    try {
        const response = await axios.post<any>(`${apiUrl}/Store/AddProductToShoppingCart?IdUser=${1}&IdProduct=${IdProduct}&Quantity=${quantity}`);
        console.log(response);
        return response.data;
    } catch (error: any) {
        console.log("Error: ", error.message);
        return [];
    }

};
export const CompleteCarTransaction = async (): Promise<any> => {
    try {
        const response = await axios.post<any>(`${apiUrl}/Store/CompleteCarTransaction?IdUser=1}`);
        console.log(response);
        return response.data;
    } catch (error: any) {
        console.log("Error: ", error.message);
        return [];
    }
}
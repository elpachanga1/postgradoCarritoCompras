import axios from "axios";
import { Item } from "../entities/Interfaces";

const apiUrl: string = process.env.REACT_APP_API_URL || "";

export const getItemsByProductId = async (productId: number): Promise<Item[]> => {
    try {
        const response = await axios.get<Item[]>(`${apiUrl}/Product/GetItemsByProductId/${productId}`);
        console.log(response);
        return response.data;
    } catch (error: any) {
        console.log("Error: ", error.message);
        return [];
    }
};
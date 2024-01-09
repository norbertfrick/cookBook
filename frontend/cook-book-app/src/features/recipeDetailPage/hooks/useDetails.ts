import axios from "axios";
import { RecipeDetail } from "../../../model/recipeDetail"
import {mockDetails} from "../../../mockData"

const service = axios.create();

export default function useDetails() {
    const getDetails = async (recipeId: string): Promise<RecipeDetail> => {
        const recipeDetails = await service.get<RecipeDetail>("")

        return recipeDetails.data;
    }

    const getMockDetails = (recipeId: string): RecipeDetail | undefined => {
        const result = mockDetails.find(f => f.RecipeId === recipeId);
        return result;
    }

    return {getDetails, getMockDetails};
}
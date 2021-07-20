import axios, { AxiosResponse } from "axios";
import { Recipe } from "../model/recipe";

const api = axios.create();

export default function useRecipes() {
  const getRecipes = async () => {
    const result = await api.get<Recipe, AxiosResponse<Recipe[]>>(
      `https://randomuser.me/api/?results=25`
    );
    return result.data;
  };

  return [getRecipes];
}

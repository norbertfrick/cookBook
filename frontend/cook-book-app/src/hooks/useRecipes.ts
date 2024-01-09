import axios, { AxiosResponse } from "axios";
import { useQuery } from "react-query";
import { Recipe } from "../model/recipe";
import { mockData } from "../mockData";

const api = axios.create();

export default function useRecipes() {
  const mockRecipes =  mockData;

  const fetchRecipes = async (): Promise<Recipe[]> => {
    const response = await fetch("");

    if (response.ok)
      return response.json();
    else
      return Promise.reject()
    
  }

  

  // const {data, status, error, isLoading} = useQuery<Recipe[]>("recipes", fetchRecipes)

  // const searchRecipes = (searchTerm: string) => {
  //   let filteredData = data?.filter(d => d.Title.includes(searchTerm) || d.Tags.includes(searchTerm))

  //   if (filteredData) return filteredData;

  //   return [];

  // }

  //return {data, status, error, isLoading, searchRecipes};
  return [mockRecipes]
}
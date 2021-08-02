import axios, { AxiosResponse } from "axios";
import { useQuery } from "react-query";
import { Recipe } from "../model/recipe";


const api = axios.create();

export default function useRecipes() {
  const fetchRecipes = async () => {
    const result = await api.get(
      `https://randomuser.me/api/?results=25`
    );
    return result.data.results;
  };


  const searchRecipes = (searchTerm: string, state: any) => {
    // let filteredData = data?.filter(d => d.Title.includes(searchTerm))

    // if (filteredData) return filteredData;

    // return {};
    console.log(state);
  }

  return {fetchRecipes, searchRecipes};
}

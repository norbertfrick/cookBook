import { useEffect, useState } from "react";
import { useQuery } from "react-query";
import SearchBar from "../../components/searchBar/searchBar";
import useRecipes from "../../hooks/useRecipes";
import { useHistory } from "react-router-dom";
import { Recipe } from "../../model/recipe";
import { mockData } from "../../mockData";
import backgroundImage from "../../assets/pexels-valeria-boltneva-1860205.jpg"

export default function Main() {
  const { fetchRecipes, searchRecipes } = useRecipes();
  const [recipes, setRecipes] = useState<Recipe[]>([]);
  const [searchResults, setSearchResults] = useState<Recipe[]>([]);
  const history = useHistory();
  const data = mockData;
  //const { data, status, isError, isLoading, isFetching } = useQuery("recipes", fetchRecipes);

  useEffect(() => {
    setRecipes(data);
  }, [data]);

  const recipeCardOnClick = (recipe: Recipe) => {
    history.push(`recipes/${recipe.Id}`);
  };

  const onSearch = (keyword: string) => {

  };

  const onSearchInputChange = (keyword: string) => {

  }


  return (
    <div style={{backgroundImage: `url(${backgroundImage})`}} className="p-5 bg-origin-padding relative w-screen h-screen bg-no-repeat bg-top bg-cover overflow-hidden gap-0 max-h-screen justify-items-center items-center">

        <div className="relative top-1/3 left-1/3 grid-cols-1 z-10 w-2/5 justify-self-center">
          <SearchBar
            search={onSearch}
            inputTextChange={onSearchInputChange}
          ></SearchBar>
        </div>
    </div>
  );
}

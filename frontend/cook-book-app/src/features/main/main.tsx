import { useEffect, useState } from "react";
import { useQuery } from "react-query";
import SearchBar from "../../components/searchBar/searchBar";
import useRecipes from "../../hooks/useRecipes";
import RecipeCard from "./recipeCard";
import { useHistory } from "react-router-dom";
import { Recipe } from "../../model/recipe";
import { mockData } from "../../mockData";

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

  const bindSearchResults = (recipes: Recipe[] | undefined) => {
    console.log(recipes?.slice(0, 1));
    setSearchResults(recipes ?? []);
  };

  return (
    <div className="grid grid-cols-1 grid-rows-1 overflow-hidden gap-0 max-h-screen justify-items-center">
      <img
        className="grid-cols-1 left-10 opacity-80 px-5 py-3 my-3 shadow-md max-w-4xl w-width mx-auto"
        src="pexels-valeria-boltneva-1860205.jpg"
      ></img>
      <div className="relative bottom-56 grid-cols-1 w-11/12 z-10 max-w-4xl">
        <SearchBar
          onSearchResultsChange={bindSearchResults}
          data={data}
        ></SearchBar>
        <div className= "relative left-14 w-11/12">
          {searchResults.length > 0 && (
            <RecipeCard
              onRecipeClick={recipeCardOnClick}
              recipe={searchResults[0]}
            ></RecipeCard>
          )}
        </div>
      </div>
      <div></div>
    </div>
  );
}

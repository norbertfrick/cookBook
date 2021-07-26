import { useState } from "react";
import { useQuery } from "react-query";
import SearchBar from "../../components/searchBar/searchBar";
import useRecipes from "../../hooks/useRecipes";
import RecipeCard from "./recipeCard";
import { useHistory } from "react-router-dom";
import { Recipe } from "../../model/recipe";

export default function Main() {
  const [getRecipes] = useRecipes();
  const [searchResults, setSearchResults] = useState<Recipe[]>([]);
  const history = useHistory();

  const { data, status, isError, isLoading } = useQuery("recipes", getRecipes);

  const onSearchbarClick = (searchTerm: string) => {
    let results = data?.filter((d) => d.Title.includes(searchTerm));

    if (results) setSearchResults(results.slice(0, 2));
  };

  const searchRecipeCards = (searchTerm: string ) => {
    let recipes = data?.filter(d => d.Title.includes(searchTerm));

    if (recipes){
      setSearchResults(recipes.sort().slice(0, 1))
    }
  }

  const recipeCardOnClick = (recipe: Recipe) => {
    history.push(`recipes/${recipe.Id}`)
  };

  return (
    <div className="grid grid-cols-1 grid-rows-1 overflow-hidden gap-0 max-h-screen justify-items-center">
      <img
        className="grid-cols-1 left-10 opacity-80 px-5 py-3 my-3 shadow-md max-w-full w-width mx-auto"
        src="pexels-valeria-boltneva-1860205.jpg"
      ></img>
      <div className="relative bottom-52 grid-cols-1 left-6 w-11/12 z-10 max-w-4xl">
        <SearchBar onSearchbarType={searchRecipeCards} onSearchClick={onSearchbarClick}></SearchBar>
        {searchResults.map((r) => {
          <RecipeCard recipe={r} onRecipeClick={recipeCardOnClick}></RecipeCard>;
        })}
      </div>
      <div></div>
    </div>
  );
}
 
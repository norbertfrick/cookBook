import { useEffect, useState } from "react";
import SearchBar from "../../components/searchBar/searchBar";
import useRecipes from "../../hooks/useRecipes";
import { useHistory } from "react-router-dom";
import { Recipe } from "../../model/recipe";

import backgroundImage from "../../assets/pexels-valeria-boltneva-1860205.jpg"
import { ResultsPane } from "./resultsPane";
import { SearchPageProps } from "../searchPage/searchPage";

export default function MainPage() {
  const [ mockRecipes ] = useRecipes();
  const [recipes, setRecipes] = useState<Recipe[]>([]);
  const [searchResults, setSearchResults] = useState<Recipe[]>([]);
  const history = useHistory();

useEffect(() => {
  const getRec = async () =>{
    let recipes = await mockRecipes();
    setRecipes(recipes);
  }
  getRec();
}, [])

  const recipeCardOnClick = (recipe: Recipe) => {
    history.push(`recipes/${recipe.Id}`);
  };

  const onSearch = (keyword: string) => {
    let props: SearchPageProps = {
      keyword: keyword
    }

      history.push(`search?searchTerm=${keyword}`, props);
  };

  const onSearchInputChange = (keyword: string) => {
    if (keyword === '') {
      setSearchResults([]);
      return;
    }

    const results = searchRecipes(keyword);
    setSearchResults(results);
  }

  const searchRecipes = (keyword:string): Recipe[] => {
    let results = recipes.filter(r => r.Title.toLowerCase().includes(keyword.toLowerCase()) || r.Description.toLowerCase().includes(keyword.toLowerCase()) || r.Tags.includes(keyword));

    return results;
  }

  return (
    <div style={{backgroundImage: `url(${backgroundImage})`}} className="p-5 bg-origin-padding relative w-screen h-screen bg-no-repeat bg-top bg-cover overflow-hidden gap-0 max-h-screen justify-items-center items-center">
        <div className="relative top-1/3 left-1/3 grid-cols-1 z-10 w-2/5 justify-self-center">
          <SearchBar
            search={onSearch}
            inputTextChange={onSearchInputChange}
          ></SearchBar>
          <ResultsPane cardOnClick={recipeCardOnClick} searchResults={searchResults}></ResultsPane>
        </div>
    </div>
  );
}
import { MouseEventHandler, useState } from "react";
import { Recipe } from "../../model/recipe";

export default function RecipeCard(props: RecipeCardProps) {
  const [recipe, setRecipe] = useState<Recipe>();

  const OnRecipeClick = (event: MouseEventHandler<HTMLDivElement>) => {
    if (recipe) props.onRecipeClick(recipe);
  };

  return (
    <div className=" space-x-2 m-2 w-2/3 font-mono rounded-xl shadow-xl  border-2 border-transparent border-gray-200 hover:bg-gray-300 md:inline-flex">
      <img
        className="max-h-48 p-2 w-full object-scale-down rounded-xl lg:max-h-32 md:object-left "
        src={props.recipe?.PictureUrl}
      ></img>
      <div className="flex space-x-2 place-content-center items-center">
        <h2 className="font-bold ">{props.recipe.Title}</h2>
        <a className="text-xs hover:text-pink-400">{"by " + props.recipe.User}</a>
        
      </div>
      <div className="flex space-x-2 place-content-center items-center">
        <span>{props.recipe.Description}</span>
      </div>
      
    </div>
  );
}

interface RecipeCardProps {
  onRecipeClick: (r: Recipe) => void;
  recipe: Recipe;
}

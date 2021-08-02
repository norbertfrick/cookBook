import { MouseEventHandler } from "react";
import { Recipe } from "../../model/recipe";

const RecipeCard: React.FC<RecipeCardProps> = (props: RecipeCardProps) => {
  const OnRecipeClick = (event: MouseEventHandler<HTMLDivElement>) => {
    if (props.recipe) props.onRecipeClick(props.recipe);
  };

  return (
    <div className="space-x-2 m-2 w-2/3 shadow-xl bg-white border-2 border-transparent border-gray-200 hover:bg-gray-300 md:inline-flex">
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

export default RecipeCard;

interface RecipeCardProps {
  onRecipeClick: (r: Recipe) => void;
  recipe: Recipe;
}

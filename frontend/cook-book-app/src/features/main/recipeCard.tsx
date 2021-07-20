import { MouseEventHandler, useState } from "react";
import {Recipe} from "../../model/recipe";

export default function RecipeCard(props: RecipeCardProps){
    const [recipe, setRecipe] = useState<Recipe>();
    setRecipe(props.recipe);

    const OnRecipeClick = (event: MouseEventHandler<HTMLDivElement>) => {
        if (recipe)
            props.onRecipeClick(recipe);
    }

    return (
        <div onClick={() => OnRecipeClick}></div>
    );


}

interface RecipeCardProps{
    onRecipeClick: (recipe: Recipe) => void;
    recipe: Recipe;
}
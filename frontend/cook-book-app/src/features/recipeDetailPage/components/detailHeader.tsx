import { Recipe } from "../../../model/recipe";
import { RecipeDetail } from "../../../model/recipeDetail";


type DetailHeaderProps = {
    recipe: Recipe | undefined;
    details: RecipeDetail | undefined;
}

export default function DetailHeader(props: DetailHeaderProps) {
    return (
    <div className="bg-gray-100 basis-full z-10 min-w-min flex p-5 text-sm justify-around items-center shadow-md" >
        <div className="flex space-x-1">
            <h2 className=" font-semibold">Recipe by:</h2>
            <a href={`/users/${props.recipe?.UserId}`} className="underline hover:text-blue-700 hover:italic">{props.recipe?.User}</a>
        </div>
        <div className="flex space-x-1 items-center">
            <h2 className=" font-semibold">Tags:</h2>
            {props.recipe?.Tags.map(t => 
                <a href={`/search?tag=${t}`} className="bg-pink-400 p-2 hover:bg-pink-300 font-mono text-xs rounded-xl min-h-10 ">{t}</a>
                )}
        </div>
        <div className="flex space-x-1">
            <h2 className=" font-semibold">Time to cook:</h2>
            <p>{props.details?.TimeToCook} minutes</p>
        </div>
        <div className="flex space-x-1">
            <h2 className=" font-semibold">Servings:</h2>
            <p>{props.details?.Servings}</p>
        </div>
    </div>
    )
}
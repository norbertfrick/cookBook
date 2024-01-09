import { FunctionComponent } from "react";
import { Link } from "react-router-dom";
import { Recipe } from "../../model/recipe";
import defaultImage from "../../assets/food-placeholder.jpg"

export interface ResultCardProps {
    recipe: Recipe;

}

export const ResultCard: FunctionComponent<ResultCardProps> = (props: ResultCardProps) => {

    return (
            <Link to={`./recipe/${props.recipe.Id}`} className="flex-col col-span-2 lg:col-span-3 items-center bg-white rounded-lg m-3 border shadow-md lg:flex-row l:max-w-xl w-72 hover:bg-gray-100 hover:shadow-lg dark:border-gray-700 dark:bg-gray-800 dark:hover:bg-gray-700 cursor-pointer overflow-hidden">
                <img className="object-cover w-full rounded-t-lg l:h-auto h-3/6 md:rounded-t-lg" src={props.recipe.PictureUrl === "" ? defaultImage: props.recipe.PictureUrl} alt={props.recipe.Title} />
                <div className="flex flex-col justify-between p-4 ">
                    <h5 className="mb-2 text-lg font-bold tracking-tight text-gray-900 dark:text-white p-5">{props.recipe.Title}</h5>
                    <p className="mb-3 font-normal text-gray-700 dark:text-gray-400 p-5 text-xs text-left">{props.recipe.Description}</p>
                </div>
                <div>
                    footer
                </div>
            </Link>
    )
} 
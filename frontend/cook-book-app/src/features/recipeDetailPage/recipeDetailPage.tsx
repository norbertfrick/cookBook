import { useState } from "react";
import { useForm } from "react-hook-form"
import { useLocation, useParams } from "react-router-dom"
import useQueryParam from "../../hooks/helpers/useQueryParam";
import useRecipes from "../../hooks/useRecipes";
import { Recipe } from "../../model/recipe";
import { RecipeDetail } from "../../model/recipeDetail";
import DetailHeader from "./components/detailHeader";
import useDetails from "./hooks/useDetails";


export default function RecipeDetailPage() {
    const { getQueryParam } = useQueryParam(window.location);
    const [mockRecipes] = useRecipes();
    const [edit, setEdit] = useState(getQueryParam<string>('edit') === 'true');
    const { getMockDetails } = useDetails();
    const { id } = useParams<{ id: string }>();

    const [detail, setDetail] = useState<RecipeDetail | undefined>(getMockDetails(id))
    const [recipe, setRecipe] = useState<Recipe | undefined>(mockRecipes.find(r => r.Id === id))

    detail?.Steps.sort(s => s.ordinal);

    console.log(detail);
    console.log(recipe);


    const readonlyForm =
        <div className="flex my-5 justify-center overflow-auto ">
            <div className="flex-col justify-center items-center max-w-7xl min-w-0 shadow-xl font-serif">
                <img src="https://placekitten.com/1920/1080" className="object-cover" >
                </img>
                <DetailHeader recipe={recipe} details={detail} ></DetailHeader>
                <div className="bg-white flex content-center justify-evenly text-left max-h-7xl">
                    <div className="m-3 bg-white w-1/5 max-w-md min-w-max border-r border-dashed border-opacity-80">
                        <ol className="list-none list-inside leading-relaxed space-y-4 p-3">
                            {detail?.Ingredients.map(i => <li className="border-b border-dashed border-opacity-80 border-gray-300">{i.amount} {i.unit} {i.description}</li>)}
                        </ol>
                    </div>
                    <div className="m-3 bg-white p-3 max-w-4xl ">
                        <h1 className="text-xl antialiased underline font-semibold uppercase mb-10 mt-1">{recipe?.Title}</h1>
                        <ol className="list-none list-inside leading-relaxed space-y-7 ">
                            {detail?.Steps.map(s =>
                                <li className="border-b border-dashed border-opacity-80 ">
                                    {s.description}
                                </li>
                            )}
                        </ol>

                    </div>
                </div>
                <div className="bg-gray-100 h-5 mt-5">
                    
                </div>
            </div>
        </div>;

    const editForm =

        <div className="flex my-5 justify-center min-w-max">
            <div className="flex-col justify-center items-center max-w-7xl shadow-xl font-serif">
                <img src="https://placekitten.com/1920/1080" className="object-cover" >
                    {/* Picture */}
                </img>
                <div className="bg-gray-100 basis-full z-10 min-w-min mt-5">
                    {/* Detail */}
                    details - edit
                </div>
                <div className="bg-white flex content-center justify-evenly text-left max-h-7xl">
                    <div className="m-3 bg-white w-1/5 max-w-md min-w-max border-r border-dashed border-opacity-80">
                        <ol className="list-none list-inside leading-relaxed space-y-4 p-3">
                            {detail?.Ingredients.map(i => <li className="border-b border-dashed border-opacity-80 border-gray-300">{i.amount} {i.unit} {i.description}</li>)}
                        </ol>
                    </div>
                    <div className="m-3 bg-white p-3 max-w-4xl ">
                        <ol className="list-none list-inside leading-relaxed space-y-7 ">
                            {detail?.Steps.map(s =>
                                <li>
                                    {s.description}
                                </li>
                            )}
                        </ol>

                    </div>
                </div>
                <div className="bg-gray-100 h-5 mt-5">
                    
                </div>
            </div>
        </div>;



    return edit ? editForm : readonlyForm;
}
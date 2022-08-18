import { CookingIngredient } from "./cookingIngredient";
import { CookingStep } from "./cookingStep";

export type RecipeDetail = {
    Id: string;
    RecipeId: string;
    Steps: CookingStep[];
    Ingredients: CookingIngredient[];
    TimeToCook: number;
    Servings: number;

}
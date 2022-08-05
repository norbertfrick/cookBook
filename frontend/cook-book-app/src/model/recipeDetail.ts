import { CookingIngredient } from "./cookingIngredient";
import { CookingStep } from "./cookingStep";

export interface RecipeDetail {
    id: string;
    steps: CookingStep[];
    ingredients: CookingIngredient[];

}
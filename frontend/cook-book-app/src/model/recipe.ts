import { CookingIngredient } from "./cookingIngredient";
import { CookingStep } from "./cookingStep";

export type Recipe = {
    Id: string;
    Title: string;
    Description: string;
    PictureUrl: string;
    User: string;
    UserId: string;
    Tags: string[]
}
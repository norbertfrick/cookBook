import { Recipe } from '../../model/recipe';
import ResultCard from './resultCard';

export interface ResultsPaneProps{
    searchResults?: Recipe[];
}

export function ResultsPane(props: ResultsPaneProps){

    const recipes: Recipe[] = [];

    if(recipes.length == 0)
        return null;

    return (
        <div className='relative w-full bg-white'>
            { recipes.map((r: Recipe) => {return (<ResultCard recipe={r}></ResultCard>)})}
        </div>
    );
}
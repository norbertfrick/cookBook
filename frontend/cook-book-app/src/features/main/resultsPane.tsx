import { Recipe } from '../../model/recipe';
import ResultCard from './resultCard';

export interface ResultsPaneProps{
    searchResults?: Recipe[];
}

export function ResultsPane(props: ResultsPaneProps){

    return (
        <div className='relative w-full bg-white'>
            { props.searchResults?.map((r: Recipe) => {return (<ResultCard key={r.Id} recipe={r}></ResultCard>)})}
        </div>
    );
}
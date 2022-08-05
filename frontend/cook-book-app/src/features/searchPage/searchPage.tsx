import { FunctionComponent, useEffect, useState } from "react";
import { useHistory, useLocation } from "react-router-dom"
import SearchBar from "../../components/searchBar/searchBar";
import useRecipes from "../../hooks/useRecipes";
import { Recipe } from "../../model/recipe"
import {ResultCard} from "../searchPage/resultCard"


export interface SearchPageProps{

}

export const SearchPage: FunctionComponent<SearchPageProps> = (props: SearchPageProps) =>{
    const navigation = useHistory();
    const [mockData] = useRecipes();
    const [results, setResults] = useState<Recipe[]>();
    const location = useLocation();
    const searchTerm = new URLSearchParams(location.search).get('searchTerm');

    const filterData = (data: Recipe[], keyword: string): Recipe[] => {
        return data.filter(r => r.Title.includes(keyword) 
        || r.Description.includes(keyword)
        || r.Tags.includes(keyword)
        );
    }
    useEffect(() => {
        setResults(filterData(mockData(), searchTerm ?? " "))

    }, [])

    const search = (keyword: string) => {
        // if (keyword === "")
        //     return;
        let data = filterData(mockData(), keyword);

        setResults(data);
    }
    
    return (
        <div className="my-12 rounded-sm mx-1.5 space-y-14 lg:space-y-0 lg:flex lg:space-x-5  lg:max-w-7xl min-w-[70%]" >
            <div className=" border-gray-100 border-t shadow-lg px-2 py-5 lg:w-1/4 lg:max-w-96">
                <SearchBar inputText={searchTerm ?? ""} searchButtonHidden={true} search={search}></SearchBar>
            </div>
            <div className=" border-gray-100 border-t shadow-lg h-full w-full flex p-5 flex-wrap  overflow-auto">
                    {results?.map(r => <ResultCard recipe={r} key={r.Id}></ResultCard>)}
            </div>
        </div>
    )
}
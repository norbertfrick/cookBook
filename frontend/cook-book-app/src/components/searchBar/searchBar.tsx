import React, { useCallback, useState } from "react";
import { debounce } from "lodash";
import { Recipe } from "../../model/recipe";
import { ResultsPane } from "./resultsPane";

interface SearchBarProps {
  data: Recipe[];
  resultClick: (recipe: Recipe) => void;
  search: (keyword:string) => void;
}

export default function SearchBar(props: SearchBarProps) {

  const [searchResults, setSearchResults] = useState<Recipe[]>();

  const handleChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    onSearchType(e.target.value);
  }, []);
  const debounceEventHandler = debounce(handleChange, 500);

  const onSearchType = (searchString: string) => {
    if (searchString == '') return [{}];

    let filteredData = props.data.filter(
      (p) => p.User.includes(searchString) || p.Title.includes(searchString)
    );
    setSearchResults(filteredData);
  };

  const onClickSearch = () => { };

  return (
    <div>
      <div className="flex items-center bg-white rounded-lg">
      <label className="sr-only">Search</label>
      <div className="relative w-full">
        <div className="flex absolute inset-y-0 left-0 items-center pl-3 pointer-events-none">
          <svg className="w-5 h-5 text-gray-500 dark:text-gray-400" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd"></path></svg>
        </div>
        <input type="text" id="simple-search" onChange={debounceEventHandler} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-pink-400 focus:border-pink-400 block w-full pl-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Search" required />
      </div>
      <button onClick={onClickSearch} type="button" className="p-2.5 text-sm font-medium text-white bg-gray-500 rounded-lg border border-gray-00 hover:bg-gray-300 focus:ring-2 focus:outline-none focus:ring-pink-400"><svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path></svg></button>
    </div>
      <ResultsPane searchResults = {searchResults}></ResultsPane>
    </div>
  );
}

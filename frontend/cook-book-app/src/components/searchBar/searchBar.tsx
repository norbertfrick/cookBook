import React, { useCallback } from "react";
import { debounce } from "lodash";
import { Recipe } from "../../model/recipe";

interface SearchBarProps {
  data: Recipe[];
  onSearchResultsChange: (recipes: Recipe[]) => void;
}

export default function SearchBar(props: SearchBarProps) {
  const handleChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    onSearchType(e.target.value);
  }, []);

  const debounceEventHandler = debounce(handleChange, 500);

  const onSearchType = (searchString: string) => {
    if (searchString == '') return [{}];

    let filteredData = props.data.filter(
      (p) => p.User.includes(searchString) || p.Title.includes(searchString)
    );
    props.onSearchResultsChange(filteredData);
  };

  const onClickSearch = () => {};

  return (
    <div>
      <div>
        <form className="">
          <input
            type="text"
            className="h-12 w-6/12
            rounded-md shadow-lg border-t-2 border-opacity-50 border-gray-200 outline-none
            focus:ring-2 focus: ring-pink-400 px-3 "
            placeholder="Search"
            onChange={debounceEventHandler}
          ></input>
          <svg
            onClick={onClickSearch}
            className="w-10 h-10 inline-block left mx-2"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth="2"
              d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
            ></path>
          </svg>
        </form>
      </div>
      <div></div>
    </div>
  );
}

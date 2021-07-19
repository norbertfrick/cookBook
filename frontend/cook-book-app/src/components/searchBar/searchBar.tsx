import React, { useCallback } from "react";
import { debounce } from "lodash";

export default function SearchBar() {
  const handleChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    console.log(e.target.value);
  }, []);

  const debounceEventHandler = debounce(handleChange, 500);

  const onClickSearch = () => {
    console.log("click");
  };

  return (
    <div>
      <div>
        <form className="">
          <input
            type="text"
            className="h-12 w-6/12 my-80 
            rounded-md shadow-lg border-t-2 border-opacity-50 border-gray-200 outline-none
            focus:ring-2 focus: ring-pink-400 px-3 "
            placeholder="Search"
            onChange={debounceEventHandler}
          ></input>
          <svg
            onClick={onClickSearch}
            className="w-6 h-6 inline-block mx-2"
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

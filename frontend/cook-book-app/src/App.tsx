import "./App.css";
import Header from "./components/header";
import SearchBar from "./components/searchBar/searchBar";

function App() {
  return (
    <div className="App">
      <Header></Header>
      <div className="relative">
        <img className="opacity-70 px-5 py-3 shadow-md w-auto mx-auto" src="pexels-valeria-boltneva-1860205.jpg"></img>
        <div className="absolute top-12 left-20 w-11/12 z-10">
          <SearchBar></SearchBar>
        </div>
      </div>
    </div>
  );
}

export default App;

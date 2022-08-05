import "./App.css";
import Header from "./components/header";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import {SearchPage} from "./features/searchPage/searchPage";
import RecipeDetailPage from "./features/recipeDetailPage/recipeDetailPage";
import MainPage from "./features/mainPage/mainPage";

function App() {
  

  return (
    <div className="App content-center">
      <Header></Header>
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={MainPage}></Route>
            <Route path="/recipe/:id" exact component={RecipeDetailPage}></Route>
            <Route path="/search" component={SearchPage}></Route>
          </Switch>
        </BrowserRouter>
    </div>
  );
}

export default App;

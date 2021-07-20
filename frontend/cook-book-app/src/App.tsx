import "./App.css";
import Header from "./components/header";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Main from "./features/main/main";

function App() {
  

  return (
    <div className="App">
      <Header></Header>
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={Main}></Route>
          </Switch>
        </BrowserRouter>
    </div>
  );
}

export default App;

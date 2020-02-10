import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Home from "./Home";
import About from "./About";
import Footer from "./Footer";
import logo from "../images/logo.png";
import "../styles/app.css";

class App extends React.Component {
  render() {
    return (
      <>
        <Router>
          <nav>
            <ul className="nav-list">
              <li>
                <img alt="SimpliPass Logo" src={logo} />
              </li>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/about">About</Link>
              </li>
            </ul>
          </nav>

          <Switch>
            <Route path="/about">
              <About />
            </Route>
            <Route path="/">
              <Home />
            </Route>
          </Switch>
        </Router>

        <Footer />
      </>
    );
  }
}

export default App;

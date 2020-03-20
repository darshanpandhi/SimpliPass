import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Home from "./Home";
import CourseReview from "./CourseReview";
import Recommendations from "./Recommendations";
import About from "./About";
import Footer from "./Footer";
import logo from "../images/logo.png";
import "../styles/app.css";
import { Nav, Navbar } from "react-bootstrap";

class App extends React.Component {
  render() {
    return (
      <>
        <Navbar sticky="top" collapseOnSelect expand="sm" variant="dark" id="simplipass-navbar">
          <Navbar.Brand href="/">
            <img alt="Simplipass Logo" src={logo} />
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="ml-auto">
              <Nav.Link href="/">Home</Nav.Link>
              <Nav.Link href="/CourseReview">Review Couse</Nav.Link>
              <Nav.Link href="/Recommendations">Couse Recommendations</Nav.Link>
              <Nav.Link href="/About">About</Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Navbar>

        <Router>
          <Switch>
            <Route path="/CourseReview">
              <CourseReview />
            </Route>
            <Route path="/Recommendations">
              <Recommendations />
            </Route>
            <Route path="/About">
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

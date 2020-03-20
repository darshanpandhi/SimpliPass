import React from "react";
import { BrowserRouter as Router, Switch, Route, NavLink } from "react-router-dom";
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
        <Router>
          <Navbar sticky="top" collapseOnSelect expand="sm" variant="dark" id="simplipass-navbar">
            <Navbar.Brand href="/">
              <img alt="Simplipass Logo" src={logo} />
            </Navbar.Brand>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
              <Nav className="ml-auto">
                <Nav.Link as={NavLink} to="/">Home</Nav.Link>
                <Nav.Link as={NavLink} to="/CourseReview">Review Course</Nav.Link>
                <Nav.Link as={NavLink} to="/Recommendations">Course Recommendations</Nav.Link>
                <Nav.Link as={NavLink} to="/About">About</Nav.Link>
              </Nav>
            </Navbar.Collapse>
          </Navbar>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/CourseReview" exact component={CourseReview} />
            <Route path="/Recommendations" exact component={Recommendations} />
            <Route path="/About" exact component={About} />
          </Switch>
        </Router>
        <Footer />
      </>
    );
  }
}

export default App;

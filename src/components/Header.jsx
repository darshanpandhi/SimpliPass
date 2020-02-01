import React from "react";
import Navbar from "react-bootstrap/Navbar";
import "../styles/header.css";
import logo from "../images/logo.png";

const Header = () => {
  return (
    <Navbar bg="light">
      <Navbar.Brand className="logo">
        <img alt="" src={logo} />
      </Navbar.Brand>
    </Navbar>
  );
};

export default Header;

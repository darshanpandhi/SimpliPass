import React from "react";
import { Row, Col } from "react-bootstrap";
import "../styles/header.css";
import logo from "../images/logo.png";

const Header = () => {
  return (
    <Row>
      <Col className="d-flex justify-content-center logo">
        <img alt="SimpliPass Logo" src={logo} />
      </Col>
    </Row>
  );
};

export default Header;

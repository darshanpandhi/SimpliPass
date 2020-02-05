import React from "react";
import "../styles/dialog.css";
import Alert from "react-bootstrap/Alert";

const Dialog = props => {
  return (
    <Alert variant={props.type}>
      <Alert.Heading className="dialog-heading">{props.heading}</Alert.Heading>
      <p className="dialog-message">{props.message}</p>
    </Alert>
  );
};

export default Dialog;

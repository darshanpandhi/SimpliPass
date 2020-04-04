import React from "react";
import "../styles/dialog.css";

const Dialog = (props) => {
  return (
    <div className={props.type !== undefined ? props.type : "general"}>
      <h1 className="dialog-heading">{props.heading}</h1>
      <p className="dialog-message">{props.message}</p>
    </div>
  );
};

export default Dialog;

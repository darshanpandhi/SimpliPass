import React from "react";
import "../styles/loader.css";

const Loader = () => {
  return (
    <div className="loader-container">
      <div className="loader"></div>
      <span>Loading...</span>
    </div>
  );
};

export default Loader;

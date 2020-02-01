import React from "react";
import "../styles/courseView.css";

const CourseView = props => {
  return (
    <div className="courseViewContainer">
      <h1>{props.currCourse}</h1>
    </div>
  );
};

export default CourseView;

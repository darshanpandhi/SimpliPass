import React from "react";
import Select from "react-select";
import "../styles/courseSelector.css";
import { getAllCoursesForDept } from "../utils/utils";

const CourseSelector = props => {
  const courseList = getAllCoursesForDept(props.currDept, props.coursesList);

  const selectCourse = selectedOption => {
    props.handleSelectCourse(selectedOption.label);
  };

  return (
    <Select
      className="courseSelector"
      onChange={selectCourse}
      options={courseList}
      placeholder="Select a Course"
    />
  );
};

export default CourseSelector;

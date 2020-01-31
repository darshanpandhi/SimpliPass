import React from "react";
import Select from "react-select";
import "../styles/courseSelector.css";

const CourseSelector = props => {
  // Course List would come from Database based on value of props.currDept
  const compSciList = [
    { value: 1, label: "COMP 1010" },
    { value: 2, label: "COMP 1020" },
    { value: 3, label: "COMP 2140" },
    { value: 4, label: "COMP 2150" },
    { value: 5, label: "COMP 3350" }
  ];

  const engList = [
    { value: 1, label: "ENG 1450" },
    { value: 2, label: "ENG 1430" },
    { value: 3, label: "ENG 2040" }
  ];

  const businessList = [
    { value: 1, label: "MKT 2210" },
    { value: 2, label: "GMGT 1010" }
  ];

  const selectCourse = selectedOption => {
    props.handleSelectCourse(selectedOption.label);
  };

  const getOptions = () => {
    if (props.currDept === "Computer Science") return compSciList;
    else if (props.currDept === "Engineering") return engList;
    else if (props.currDept === "Business") return businessList;
  };

  return (
    <Select
      className="courseSelector"
      onChange={selectCourse}
      options={getOptions()}
      placeholder="Select a Course"
    />
  );
};

export default CourseSelector;

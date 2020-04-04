import React from "react";
import Select from "react-select";
import "../styles/departmentSelector.css";
import { getAllDepartments } from "../utils/utils";

const DepartmentSelector = (props) => {
  const deparmentList = getAllDepartments(props.coursesList);

  const selectDept = (selectedOption) => {
    props.handleSelectDept(selectedOption.label);
  };

  return (
    <Select
      className="departmentSelector"
      onChange={selectDept}
      options={deparmentList}
      placeholder="Select a Department"
    />
  );
};

export default DepartmentSelector;

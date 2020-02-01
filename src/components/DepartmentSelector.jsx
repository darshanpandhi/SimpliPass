import React from "react";
import Select from "react-select";
import "../styles/departmentSelector.css";

const DepartmentSelector = props => {
  // Would come from Database
  const deparmentList = [
    { value: 1, label: "Computer Science" },
    { value: 2, label: "Engineering" },
    { value: 3, label: "Business" }
  ];

  const selectDept = selectedOption => {
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

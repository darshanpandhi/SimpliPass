import React from "react";
import Select from "react-select";
import "../styles/department.css";

const Department = () => {
  // Would come from Database
  const deparmentList = [
    { value: 1, label: "Computer Science" },
    { value: 2, label: "Engineering" },
    { value: 3, label: "Business" },
    { value: 4, label: "Mathematics" },
    { value: 5, label: "Physics" },
    { value: 6, label: "Chemistry" },
    { value: 7, label: "Biology" }
  ];

  const handleChange = selectedOption => {
    console.log(selectedOption);
  };

  return (
    <Select
      className="departmentSelector"
      onChange={handleChange}
      options={deparmentList}
      placeholder="Select a Department"
    />
  );
};

export default Department;

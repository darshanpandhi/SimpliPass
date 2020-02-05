import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import DepartmentSelector from "../components/DepartmentSelector";
import { sampleCoursesList } from "./testData";

Enzyme.configure({ adapter: new Adapter() });

describe("DepartmentSelector", () => {
  it("should render a selector for departments based on provided coursesList", () => {
    const component = shallow(
      <DepartmentSelector coursesList={sampleCoursesList} />
    );

    expect(component.prop("placeholder")).toEqual("Select a Department");
    expect(component.prop("options")).toEqual([
      { value: "Computer Science", label: "Computer Science" },
      { value: "Mathematics", label: "Mathematics" }
    ]);
  });
});

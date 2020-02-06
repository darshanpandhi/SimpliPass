import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import CourseSelector from "../components/CourseSelector";
import { sampleCoursesList } from "./testData";

Enzyme.configure({ adapter: new Adapter() });

describe("CourseSelector", () => {
  it("should render a selector for Courses based on provided coursesList and the current Department selected", () => {
    const component = shallow(
      <CourseSelector
        currDept={"Computer Science"}
        coursesList={sampleCoursesList}
      />
    );

    expect(component.prop("placeholder")).toEqual("Select a Course");
    expect(component.prop("options")).toEqual([
      { value: "COMP 2140", label: "COMP 2140" },
      { value: "COMP 1010", label: "COMP 1010" }
    ]);
  });
});

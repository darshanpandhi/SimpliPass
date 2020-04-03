import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import CourseView from "../../components/CourseView";
import { sampleCoursesList } from "./Stub";

Enzyme.configure({ adapter: new Adapter() });

describe("CourseView", () => {
  it("should render a course Header containing the course id, course name and department name and also course difficulty and its list of section ratings based on the props of coursesList and the current Course selected", () => {
    const component = shallow(
      <CourseView currCourse={"COMP 2140"} coursesList={sampleCoursesList} />
    );

    // Course ID and Name
    expect(component.find("h1")).toHaveLength(1);
    expect(component.find("h1").text()).toEqual(
      "COMP 2140 - Data Structures and Algorithms"
    );

    // Department Name
    expect(component.find("h2")).toHaveLength(1);
    expect(component.find("h2").text()).toEqual(
      "Department of Computer Science"
    );

    // Difficulty Level
    expect(component.find("span")).toHaveLength(1);
    expect(component.find("span").text()).toEqual("5");

    // Section Ratings
    expect(component.find("h5").text()).toEqual("Section Ratings");
    expect(component.find("div")).toHaveLength(5);

    expect(
      component
        .find("div")
        .at(2)
        .text()
    ).toEqual("Brad Pitt82 reviews");
    expect(
      component
        .find("div")
        .at(3)
        .text()
    ).toEqual("Tom Hanks63 reviews");

    expect(
      component
        .find("div")
        .at(4)
        .text()
    ).toEqual("Robert Downey, Jr.95 reviews");
  });
});

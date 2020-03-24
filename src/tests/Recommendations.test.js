import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import Recommendations from "../components/Recommendations";
import { sampleCoursesList } from "./Stub";

Enzyme.configure({ adapter: new Adapter() });

describe("Recommendations", () => {
  it("should render a header and a list of courses with their difficulty and the number of reviews.", () => {
    const component = shallow(<Recommendations />);

    // Initially Loading...
    expect(component.state().loaded).toEqual(false);
    component.setState({
      loaded: true,
      recommendationsList: sampleCoursesList
    });

    // Header
    expect(component.find("h1")).toHaveLength(1);
    expect(component.find("h1").text()).toEqual("Recommended Popular Courses ");

    // Recommended Courses
    expect(component.find("h3")).toHaveLength(3);
    expect(component.find("h5")).toHaveLength(3);
    expect(component.find("p")).toHaveLength(3);

    // COMP 2140
    expect(
      component
        .find("h3")
        .at(0)
        .text()
    ).toEqual("COMP 2140 - Data Structures and Algorithms");
    expect(
      component
        .find("h5")
        .at(0)
        .text()
    ).toEqual("Difficulty: 5");
    expect(
      component
        .find("p")
        .at(0)
        .text()
    ).toEqual("5 reviews");

    // COMP 1010
    expect(
      component
        .find("h3")
        .at(1)
        .text()
    ).toEqual("COMP 1010 - Introductory Computer Science 1");
    expect(
      component
        .find("h5")
        .at(1)
        .text()
    ).toEqual("Difficulty: 3.2");
    expect(
      component
        .find("p")
        .at(1)
        .text()
    ).toEqual("11 reviews");

    // MATH 1700
    expect(
      component
        .find("h3")
        .at(2)
        .text()
    ).toEqual("MATH 1700 - Calculus 2");
    expect(
      component
        .find("h5")
        .at(2)
        .text()
    ).toEqual("Difficulty: 6.7");
    expect(
      component
        .find("p")
        .at(2)
        .text()
    ).toEqual("8 reviews");
  });
});

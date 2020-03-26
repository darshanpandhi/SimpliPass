import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import CourseReview from "../../components/CourseReview";

Enzyme.configure({ adapter: new Adapter() });

describe("CourseReview", () => {
  it("should render a page title and input labels for course id, name, dept, difficulty, instructor, rating and a submit button", () => {
    const component = shallow(<CourseReview />);

    // Initially Loading...
    expect(component.state().loaded).toEqual(false);
    component.setState({ loaded: true });

    // Page Title
    expect(component.find("h1")).toHaveLength(1);
    expect(component.find("h1").text()).toEqual(" Review Course ");

    // Labels
    expect(component.find("label")).toHaveLength(8);

    // Input fields
    expect(component.find("input")).toHaveLength(5);

    // Course ID
    expect(
      component
        .find("label")
        .at(0)
        .text()
    ).toEqual("Course ID");

    // Name
    expect(
      component
        .find("label")
        .at(1)
        .text()
    ).toEqual("Name ");

    // Dept
    expect(
      component
        .find("label")
        .at(2)
        .text()
    ).toEqual("Department ");

    // Diff
    expect(
      component
        .find("label")
        .at(3)
        .text()
    ).toEqual("Difficulty Level ");

    // Section Title
    expect(component.find("h2")).toHaveLength(1);
    expect(component.find("h2").text()).toEqual(" Section");

    // Instructor
    expect(
      component
        .find("label")
        .at(5)
        .text()
    ).toEqual("Instructor ");

    // Rating
    expect(
      component
        .find("label")
        .at(6)
        .text()
    ).toEqual(" Rating ");

    // Hints
    expect(component.find("p")).toHaveLength(2);

    expect(
      component
        .find("p")
        .at(0)
        .text()
    ).toEqual(" 1 - Very Easy, 10 - Extremely Difficult");

    expect(
      component
        .find("p")
        .at(1)
        .text()
    ).toEqual(" 1 - Poor, 10 - Excellent");

    // Submit Button
    expect(component.find("button")).toHaveLength(1);
    expect(component.find("button").text()).toEqual("Submit Review");
  });
});

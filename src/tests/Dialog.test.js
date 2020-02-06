import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import Dialog from "../components/Dialog";

Enzyme.configure({ adapter: new Adapter() });

describe("Dialog", () => {
  it("should render 1 div with className as the type passed in, 1 h1 as the heading passed in and 1 p as the message passed in", () => {
    const component = shallow(
      <Dialog
        type="error"
        heading="Some Error Heading"
        message="Some Message"
      />
    );

    // Main div
    expect(component.find("div")).toHaveLength(1);
    expect(component.find("div").hasClass("error"));

    // Heading
    expect(component.find("h1")).toHaveLength(1);
    expect(component.find("h1").text()).toEqual("Some Error Heading");

    // Message
    expect(component.find("p")).toHaveLength(1);
    expect(component.find("p").text()).toEqual("Some Message");
  });
});

import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import Loader from "../components/Loader";

Enzyme.configure({ adapter: new Adapter() });

describe("Loader", () => {
  it("should render 2 divs and 1 p tag with Loading text", () => {
    const component = shallow(<Loader />);

    expect(component.find("div")).toHaveLength(2);
    expect(component.find("p")).toHaveLength(1);
    expect(component.find("p").text()).toEqual("Loading...");
  });
});

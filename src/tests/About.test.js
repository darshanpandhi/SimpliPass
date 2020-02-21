import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import Header from "../components/About";

Enzyme.configure({ adapter: new Adapter() });

describe("About", () => {
  it("should render 1 h1, 1 h3, and 2 p tags", () => {
    const component = shallow(<Header />);

    expect(component.find("h1")).toHaveLength(1);
    expect(component.find("h3")).toHaveLength(1);
    expect(component.find("p")).toHaveLength(2);
  });
});

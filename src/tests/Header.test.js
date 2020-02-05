import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import Header from "../components/Header";

Enzyme.configure({ adapter: new Adapter() });

describe("Header", () => {
  it("should render the logo inside 1 img tag", () => {
    const component = shallow(<Header />);
    const img = component.find("img");
    expect(img).toHaveLength(1);
  });
});

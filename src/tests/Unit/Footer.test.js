import React from "react";
import Enzyme, { shallow } from "enzyme";
import Adapter from "enzyme-adapter-react-16";
import Footer from "../../components/Footer";

Enzyme.configure({ adapter: new Adapter() });

describe("Footer", () => {
  it("should render SimpliPass inside a p tag", () => {
    const component = shallow(<Footer />);

    expect(component.find("p")).toHaveLength(1);
    expect(component.find("p").text()).toEqual("© SimpliPass");
  });
});

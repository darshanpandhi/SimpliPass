import React from "react";
import Header from "./components/Header";
import Footer from "./components/Footer";
import DepartmentSelector from "./components/DepartmentSelector";
import CourseSelector from "./components/CourseSelector";

class App extends React.Component {
  constructor() {
    super();
    this.state = {
      currDept: "",
      currCourse: ""
    };

    // this.handleChange = this.handleChange.bind(this);
  }

  handleSelectDept = dept => {
    this.setState({ currDept: dept, currCourse: "" });
  };

  handleSelectCourse = crs => {
    this.setState({ currCourse: crs });
  };

  renderSelectors() {
    return (
      <>
        <DepartmentSelector handleSelectDept={this.handleSelectDept} />
        <CourseSelector
          handleSelectCourse={this.handleSelectCourse}
          currDept={this.state.currDept}
        />
      </>
    );
  }

  render() {
    return (
      <div className="App">
        <Header />
        {/* {this.renderSelectors()} */}
        <Footer />
      </div>
    );
  }
}

export default App;

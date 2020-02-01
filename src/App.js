import React from "react";
import Header from "./components/Header";
import Footer from "./components/Footer";
import Loader from "./components/Loader";
import DepartmentSelector from "./components/DepartmentSelector";
import CourseSelector from "./components/CourseSelector";
import CourseView from "./components/CourseView";
import { proxyURL, apiRootURL } from "./Utils/constants";

class App extends React.Component {
  constructor() {
    super();

    this.state = {
      currDept: "",
      currCourse: "",
      coursesList: [],
      loaded: false
    };
  }

  componentDidMount() {
    fetch(proxyURL + apiRootURL + "course/")
      .then(response => response.json())
      .then(result => {
        this.setState({ coursesList: result, loaded: true });
      })
      .catch(error => {
        console.error("Error:", error);
      });
  }

  handleSelectDept = dept => {
    this.setState({ currDept: dept, currCourse: "" });
  };

  handleSelectCourse = crs => {
    this.setState({ currCourse: crs });
  };

  renderCourseView() {
    return (
      <>
        <CourseView
          currCourse={this.state.currCourse}
          coursesList={this.state.coursesList}
        />
      </>
    );
  }

  renderSelectors() {
    return (
      <>
        <DepartmentSelector
          handleSelectDept={this.handleSelectDept}
          coursesList={this.state.coursesList}
        />
        <CourseSelector
          coursesList={this.state.coursesList}
          handleSelectCourse={this.handleSelectCourse}
          currDept={this.state.currDept}
        />
      </>
    );
  }

  render() {
    return this.state.loaded ? (
      <div className="App">
        <Header />
        {this.renderSelectors()}
        {this.renderCourseView()}
        <Footer />
      </div>
    ) : (
      <Loader />
    );
  }
}

export default App;

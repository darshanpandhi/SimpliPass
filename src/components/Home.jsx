import React from "react";
import Loader from "./Loader";
import DepartmentSelector from "./DepartmentSelector";
import CourseSelector from "./CourseSelector";
import CourseView from "./CourseView";
import Dialog from "./Dialog";
import { proxyURL, apiRootURL, allCourses } from "../Utils/constants";
import { Container, Row, Col } from "react-bootstrap";

class Home extends React.Component {
  constructor() {
    super();

    this.state = {
      currDept: "",
      currCourse: "",
      coursesList: [],
      loaded: false,
      serverError: false
    };
  }

  componentDidMount() {
    fetch(proxyURL + apiRootURL + allCourses)
      .then(response => response.json())
      .then(result => {
        this.setState({ coursesList: result, loaded: true });
      })
      .catch(error => {
        this.setState({ serverError: true });
        console.error("Error:", error);
      });
  }

  handleSelectDept = dept => {
    this.setState({ currDept: dept, currCourse: "" });
  };

  handleSelectCourse = crs => {
    this.setState({ currCourse: crs });
  };

  renderBody() {
    return (
      <>
        <Container>
          <Row>
            <Col className="d-flex justify-content-center">
              <DepartmentSelector
                handleSelectDept={this.handleSelectDept}
                coursesList={this.state.coursesList}
              />
            </Col>
          </Row>
          <Row>
            <Col className="d-flex justify-content-center">
              <CourseSelector
                coursesList={this.state.coursesList}
                handleSelectCourse={this.handleSelectCourse}
                currDept={this.state.currDept}
              />
            </Col>
          </Row>
          <Row>
            <Col className="d-flex justify-content-center">
              <CourseView
                currCourse={this.state.currCourse}
                coursesList={this.state.coursesList}
              />
            </Col>
          </Row>
        </Container>
      </>
    );
  }

  renderServerError() {
    return (
      <Dialog
        type="error"
        heading="Server Error!"
        message="Please try refreshing."
      />
    );
  }

  render() {
    return (
      <>
        {this.state.serverError && this.renderServerError()}

        {this.state.loaded && !this.state.serverError ? (
          this.renderBody()
        ) : (
            <Loader />
          )}
      </>
    );
  }
}

export default Home;

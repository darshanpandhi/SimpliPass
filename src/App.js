import React from "react";
import Header from "./components/Header";
import Footer from "./components/Footer";
import Loader from "./components/Loader";
import DepartmentSelector from "./components/DepartmentSelector";
import CourseSelector from "./components/CourseSelector";
import CourseView from "./components/CourseView";
import Dialog from "./components/Dialog";
import { proxyURL, apiRootURL } from "./Utils/constants";
import { Container, Row, Col } from "react-bootstrap";

class App extends React.Component {
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
    fetch(proxyURL + apiRootURL + "course/")
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
      <Container className="App">
        <Header />

        {this.state.serverError && this.renderServerError()}

        {this.state.loaded && !this.state.serverError ? (
          this.renderBody()
        ) : (
            <Loader />
          )}

        <Footer />
      </Container >
    );
  }
}

export default App;

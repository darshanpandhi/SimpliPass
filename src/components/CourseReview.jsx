import React from "react";
import Loader from "./Loader";
import DepartmentSelector from "./DepartmentSelector";
import CourseSelector from "./CourseSelector";
import Dialog from "./Dialog";
import {
  proxyURL,
  apiRootURL,
  allCourses,
  updateDifficulty
} from "../Utils/constants";
import { Row, Col } from "react-bootstrap";
import Select from "react-select";
import "../styles/courseReview.css";

class CourseReview extends React.Component {
  constructor() {
    super();

    this.state = {
      currDiff: "",
      currDept: "",
      currCourse: "",
      coursesList: [],
      loaded: false,
      currMessage: ""
    };
  }

  componentDidMount() {
    fetch(proxyURL + apiRootURL + allCourses)
      .then(response => response.json())
      .then(result => {
        this.setState({ coursesList: result, loaded: true });
      })
      .catch(error => {
        this.setState({
          currMessage: "Please try refreshing."
        });
        console.error("Error:", error);
      });
  }

  handleSelectDept = dept => {
    this.setState({ currDept: dept, currCourse: "", currMessage: "" });
  };

  handleSelectCourse = crs => {
    this.setState({ currCourse: crs, currMessage: "" });
  };

  handleSelectDifficulty = diff => {
    this.setState({ currDiff: diff.value, currMessage: "" });
  };

  handleSubmitReview = () => {
    if (
      this.state.currDept !== "" &&
      this.state.currCourse !== "" &&
      this.state.currDiff !== ""
    ) {
      fetch(
        proxyURL +
          apiRootURL +
          allCourses +
          this.state.currCourse +
          updateDifficulty +
          this.state.currDiff,
        {
          method: "PUT"
        }
      )
        .then(response => {
          if (response.status === 200) {
            this.setState({ currMessage: "Review has been submitted." });
          } else {
            this.setState({
              currMessage: "Submitting failed. Please try again."
            });
          }
        })
        .catch(error => {
          console.error("Error:", error);
        });
    } else if (
      this.state.currDept !== "" &&
      this.state.currCourse === "" &&
      this.state.currDiff !== ""
    ) {
      this.setState({
        currMessage:
          "Course does not match department. Please select the correct course for the correct department."
      });
    } else {
      this.setState({
        currMessage:
          "Some fields empty. Please select department, course and difficulty level."
      });
    }
  };

  renderBody() {
    return (
      <div className="reviewContainer">
        <h2>Difficulty Review</h2>
        <h3>Department: </h3>
        <Row>
          <Col className="d-flex justify-content-left">
            <DepartmentSelector
              handleSelectDept={this.handleSelectDept}
              coursesList={this.state.coursesList}
            />
          </Col>
        </Row>
        <h3>Course: </h3>
        <Row>
          <Col className="d-flex justify-content-left">
            <CourseSelector
              coursesList={this.state.coursesList}
              handleSelectCourse={this.handleSelectCourse}
              currDept={this.state.currDept}
            />
          </Col>
        </Row>
        <h3>Difficulty Level: </h3>
        <Row>
          <Col className="d-flex justify-content-left">
            <Select
              className="difficultySelector"
              onChange={this.handleSelectDifficulty}
              isSearchable={false}
              options={
                this.state.currCourse === ""
                  ? []
                  : [
                      { value: "1", label: "1" },
                      { value: "2", label: "2" },
                      { value: "3", label: "3" },
                      { value: "4", label: "4" },
                      { value: "5", label: "5" },
                      { value: "6", label: "6" },
                      { value: "7", label: "7" },
                      { value: "8", label: "8" },
                      { value: "9", label: "9" },
                      { value: "10", label: "10" }
                    ]
              }
              placeholder=""
            />
          </Col>
        </Row>
        <p> 1 - Very Easy, 10 - Extremely Difficult</p>
        <button
          className="submitReviewBtn"
          onClick={this.handleSubmitReview}
          disabled={
            this.state.currDept === "" &&
            this.state.currCourse === "" &&
            this.state.currDiff === ""
          }
        >
          Submit Review
        </button>
      </div>
    );
  }

  renderMessage() {
    let dialog = (
      <Dialog
        type="general"
        heading="Error!"
        message={this.state.currMessage}
      />
    );

    if (this.state.currMessage.toString().startsWith("Review")) {
      dialog = (
        <Dialog
          type="success"
          heading="Success!"
          message={this.state.currMessage}
        />
      );
    } else if (this.state.currMessage.toString().startsWith("Please")) {
      dialog = (
        <Dialog
          type="error"
          heading="Server Error!"
          message={this.state.currMessage}
        />
      );
    }

    return this.state.currMessage !== "" && dialog;
  }

  render() {
    return (
      <>
        {this.state.loaded ? this.renderBody() : <Loader />}
        {this.renderMessage()}
      </>
    );
  }
}

export default CourseReview;

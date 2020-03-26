import React from "react";
import Loader from "./Loader";
import Dialog from "./Dialog";
import { courseExists } from "../Utils/utils";
import {
  proxyURL,
  apiRootURL,
  allCourses,
  updateExistingCourse,
  newCourse,
  successCode,
  commonSelectorOptions
} from "../Utils/constants";
import { Row, Col } from "react-bootstrap";
import Select from "react-select";
import "../styles/courseReview.css";

class CourseReview extends React.Component {
  constructor() {
    super();

    this.state = {
      coursesList: [],
      currMessage: "",
      currCourseCode: "",
      currCourseNum: "",
      currName: "",
      currDept: "",
      currDiff: "",
      currSec: "",
      currSecRating: "",
      loaded: false
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

  handleSubmitReview = () => {
    if (
      this.state.currCourseCode !== "" &&
      this.state.currCourseNum !== "" &&
      this.state.currName !== "" &&
      this.state.currDept !== "" &&
      this.state.currDiff !== "" &&
      this.state.currSec !== "" &&
      this.state.currSecRating !== ""
    ) {
      if (
        courseExists(
          this.state.currCourseCode + " " + this.state.currCourseNum,
          this.state.coursesList
        )
      ) {
        fetch(
          proxyURL +
            apiRootURL +
            allCourses +
            this.state.currCourseCode +
            " " +
            this.state.currCourseNum +
            updateExistingCourse +
            this.state.currDiff +
            "/" +
            this.state.currSec +
            "/" +
            this.state.currSecRating,
          {
            method: "PUT"
          }
        )
          .then(response => {
            if (response.status === successCode) {
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
      } else {
        fetch(
          proxyURL +
            apiRootURL +
            allCourses +
            newCourse +
            this.state.currCourseCode +
            " " +
            this.state.currCourseNum +
            "/" +
            this.state.currName +
            "/" +
            this.state.currDept +
            "/" +
            this.state.currDiff +
            "/" +
            this.state.currSec +
            "/" +
            this.state.currSecRating,

          {
            method: "POST"
          }
        )
          .then(response => {
            if (response.status === successCode) {
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
      }
    } else {
      this.setState({
        currMessage:
          "Some fields empty. Please enter course id, name, department, difficulty level and a section with its rating."
      });
    }
  };

  onChangeValueCourseCode = event => {
    this.setState({
      currCourseCode: event.target.value.toString().toUpperCase(),
      currMessage: ""
    });
  };

  onChangeValueCourseNum = event => {
    this.setState({ currCourseNum: event.target.value, currMessage: "" });
  };

  onChangeValueCourseName = event => {
    this.setState({ currName: event.target.value, currMessage: "" });
  };

  onChangeValueDept = event => {
    this.setState({ currDept: event.target.value, currMessage: "" });
  };

  onChangeValueSection = event => {
    this.setState({ currSec: event.target.value, currMessage: "" });
  };

  handleSelectDifficulty = diff => {
    this.setState({ currDiff: diff.value, currMessage: "" });
  };

  handleSelectSectionRating = secRating => {
    this.setState({ currSecRating: secRating.value, currMessage: "" });
  };

  renderBody() {
    return (
      <div className="reviewContainer">
        <Row>
          <h1 className="pageTitle"> Review Course </h1>
        </Row>

        <Row>
          <Col md={5}>
            <label>Course ID</label>
          </Col>
          <Col md={7} className="d-flex justify-content-left review-course">
            <input
              className="crsCode"
              type="text"
              maxLength="4"
              placeholder="COMP"
              value={this.state.currCourseCode}
              onChange={this.onChangeValueCourseCode}
            />
            <input
              className="crsNum"
              type="text"
              maxLength="4"
              placeholder="1010"
              value={this.state.currCourseNum}
              onChange={this.onChangeValueCourseNum}
            />
          </Col>
        </Row>
        <Row>
          <Col md={5}>
            <label>Name </label>
          </Col>
          <Col md={7} className="d-flex justify-content-left review-course">
            <input
              type="text"
              placeholder="Intro to Computer Science 1"
              value={this.state.currName}
              onChange={this.onChangeValueCourseName}
            />
          </Col>
        </Row>
        <Row>
          <Col md={5}>
            <label>Department </label>
          </Col>
          <Col md={7} className="d-flex justify-content-left review-course">
            <input
              type="text"
              placeholder="Computer Science"
              value={this.state.currDept}
              onChange={this.onChangeValueDept}
            />
          </Col>
        </Row>
        <Row>
          <Col md={5}>
            <label>Difficulty Level </label>
          </Col>
          <Col md={7} className="d-flex justify-content-left review-course">
            <Select
              className="difficultySelector"
              onChange={this.handleSelectDifficulty}
              options={
                this.state.currCourseCode === "" ||
                this.state.currCourseNum === ""
                  ? []
                  : commonSelectorOptions
              }
              placeholder=""
            />
          </Col>
        </Row>
        <Row>
          <Col md={5} className="emptyLabel">
            <label></label>
          </Col>
          <Col md={7} className="d-flex justify-content-left">
            <p className="hint"> 1 - Very Easy, 10 - Extremely Difficult</p>
          </Col>
        </Row>

        <Row>
          <h2 className="secTitle"> Section</h2>
        </Row>
        <Row>
          <Col md={5}>
            <label>Instructor </label>
          </Col>
          <Col md={7} className="d-flex justify-content-left review-course">
            <input
              type="text"
              placeholder="John Smith"
              value={this.state.currSec}
              onChange={this.onChangeValueSection}
            />
          </Col>
        </Row>
        <Row>
          <Col md={5}>
            <label> Rating </label>
          </Col>
          <Col md={7} className="d-flex justify-content-left review-course">
            <Select
              className="sectionRatingSelector"
              onChange={this.handleSelectSectionRating}
              options={this.state.currSec === "" ? [] : commonSelectorOptions}
              placeholder=""
            />
          </Col>
        </Row>
        <Row>
          <Col md={5} className="emptyLabel">
            <label></label>
          </Col>
          <Col md={7} className="d-flex justify-content-left">
            <p className="hint"> 1 - Poor, 10 - Excellent</p>
          </Col>
        </Row>
        <Row>
          <Col>
            <button
              className="submitReviewBtn"
              onClick={this.handleSubmitReview}
              disabled={
                this.state.currDept === "" &&
                this.state.currCourseCode === "" &&
                this.state.currCourseNum === "" &&
                this.state.currDiff === "" &&
                this.state.currSec === "" &&
                this.state.currSecRating === ""
              }
            >
              Submit Review
            </button>
          </Col>
        </Row>
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
        {this.renderMessage()}
        {this.state.loaded ? this.renderBody() : <Loader />}
      </>
    );
  }
}

export default CourseReview;

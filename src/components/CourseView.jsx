import React from "react";
import "../styles/courseView.css";
import { getCourseInfo } from "../Utils/utils";
import Badge from "react-bootstrap/Badge";

const CourseView = props => {
  const courseInfo = getCourseInfo(props.currCourse, props.coursesList);

  const renderCourseHeader = () => {
    return (
      <div className="header">
        <h1>
          {courseInfo.id} - {courseInfo.name}
        </h1>
        <h3>Department of {courseInfo.department}</h3>
      </div>
    );
  };

  const renderDifficulty = () => {
    let modifier;

    if (courseInfo.difficulty >= 8) {
      modifier = "danger";
    } else if (courseInfo.difficulty >= 5 && courseInfo.difficulty < 8) {
      modifier = "warning";
    } else if (courseInfo.difficulty >= 0 && courseInfo.difficulty < 5) {
      modifier = "success";
    }

    return (
      <div className="difficultyContainer">
        Difficulty Level
        <span className="difficultyNumber">
          <Badge pill variant={modifier}>
            {courseInfo.difficulty}
          </Badge>
        </span>
      </div>
    );
  };

  const renderSectionRatings = () => {
    let sectionRatingsList = [];

    for (let [key, value] of Object.entries(courseInfo.section_ratings)) {
      sectionRatingsList.push(<h5 key={key}> {`${key}:  ${value}`} </h5>);
    }

    return (
      <div className="sectionRatingsContainer">
        <h3 className="sectionRatingsHeader">Section Ratings</h3>
        {sectionRatingsList}
      </div>
    );
  };

  return (
    courseInfo.length !== 0 && (
      <div className="courseViewContainer">
        {renderCourseHeader()}
        {renderDifficulty()}
        {renderSectionRatings()}
      </div>
    )
  );
};

export default CourseView;

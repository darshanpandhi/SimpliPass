import React from "react";
import "../styles/courseView.css";
import { getCourseInfo } from "../Utils/utils";

const CourseView = props => {
  const courseInfo = getCourseInfo(props.currCourse, props.coursesList);

  const renderCourseInfo = () => {
    return (
      <>
        <h1>
          {courseInfo.id} - {courseInfo.name}
        </h1>
        <h3>Department of {courseInfo.department}</h3>
        <br />
        <h3> Difficulty Level: {courseInfo.difficulty}</h3>
      </>
    );
  };

  const renderSectionRatings = () => {
    let sectionRatingsList = [];

    for (let [key, value] of Object.entries(courseInfo.section_ratings)) {
      sectionRatingsList.push(<p key={key}> {`${key}:  ${value}`} </p>);
    }

    return (
      <>
        <br />
        <h3>Section Ratings</h3>
        {sectionRatingsList}
      </>
    );
  };

  return (
    courseInfo.length !== 0 && (
      <div className="courseViewContainer">
        {renderCourseInfo()}
        {renderSectionRatings()}
      </div>
    )
  );
};

export default CourseView;

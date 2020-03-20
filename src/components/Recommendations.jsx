import React from "react";
import Loader from "./Loader";
import Dialog from "./Dialog";
import "../styles/recommendations.css";
import {
  proxyURL,
  apiRootURL,
  allCourses,
  recommendations
} from "../Utils/constants";

class Recommendations extends React.Component {
  constructor() {
    super();

    this.state = {
      recommendationsList: [],
      currMessage: "",
      loaded: false
    };
  }

  componentDidMount() {
    fetch(proxyURL + apiRootURL + allCourses + recommendations)
      .then(response => response.json())
      .then(result => {
        this.setState({ recommendationsList: result, loaded: true });
      })
      .catch(error => {
        this.setState({
          currMessage: "Please try refreshing."
        });
        console.error("Error:", error);
      });
  }

  renderRecommendations = () => {
    let list = [];

    Object.values(this.state.recommendationsList).forEach(crs => {
      list.push(
        <div key={crs.id}>
          <h3>
            {`${crs.id}`} - {`${crs.name}`}
          </h3>
          <h5>{`Difficulty: ${crs.difficulty}`}</h5>
          <p>{`${crs.difficultyCount} reviews`}</p>
        </div>
      );
    });

    return (
      <div className="recommendationsContainer">
        <h1>Recommended Popular Courses </h1>
        {list}
      </div>
    );
  };

  renderMessage() {
    return (
      this.state.currMessage !== "" && (
        <Dialog
          type="error"
          heading="Server Error!"
          message={this.state.currMessage}
        />
      )
    );
  }

  render() {
    return (
      <>
        {this.state.loaded ? this.renderRecommendations() : <Loader />}
        {this.renderMessage()}
      </>
    );
  }
}

export default Recommendations;

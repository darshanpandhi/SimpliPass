import React from "react";
import "../styles/about.css";

const About = () => {
  return (
    <div className="aboutContainer">
      <h1>Why SimpliPass?</h1>
      <h3>
        Our vision is to help students maximize their academic success by
        providing course reviews along with instructor specific section ratings
        to allow optimal course selections and the best possible learning
        experience.
      </h3>
      <p>
        Course selection is one of the most crucial decisions a student must
        make in their university life. Both course content and instructor are
        equally important and have a huge impact on a student's overall course
        experience. Despite this, university students have very little or no
        insight into what they are signing up for. Sometimes they do not even
        realize this until later in the course, which ends up in either them
        withdrawing or receiving an unsatisfactory grade. SimpliPass is a
        cross-platform mobile and web application that aims to solve this
        problem by curating section reviews and recommending the best available
        instructor for a course.
      </p>
      <br />
      <p>
        Compared to existing competition, SimpliPass offers a unique feature of
        reviewing a combination of course and instructor (section) rather than
        just individual courses or instructors. We believe every instructor has
        their niche and they are likely to make a difficult course more
        enjoyable and understandable if it falls under their area of expertise.
        By bringing the best of both worlds together, our review system resolves
        the hassle of manually relating them. Also, we are envisioning to
        introduce features like elective recommendations and course load
        suggestions per term, making SimpliPass a one-stop destination for all
        academic planning needs. Not only does this make SimpliPass a valuable
        tool for the students, but it also gives it a significant competitive
        advantage over existing solutions.
      </p>
    </div>
  );
};

export default About;

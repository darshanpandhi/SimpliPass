const proxyURL = "https://cors-anywhere.herokuapp.com/";
const apiRootURL =
  "http://simplipass-development.tmyzhjtuxt.us-east-2.elasticbeanstalk.com/";
const allCourses = "course/";
const recommendations = "recommendations/";
const updateExistingCourse = "/updateExistingCourse/";
const newCourse = "new/";
const successCode = 200;
const commonSelectorOptions = [
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
];

export {
  proxyURL,
  apiRootURL,
  allCourses,
  recommendations,
  updateExistingCourse,
  newCourse,
  successCode,
  commonSelectorOptions
};

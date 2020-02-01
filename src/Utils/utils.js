export const getAllDepartments = coursesList => {
  let temp = [];
  let deparmentList = [];

  Object.values(coursesList).forEach(crs => {
    if (temp.indexOf(crs.department) === -1) {
      temp.push(crs.department);
    }
  });

  temp.forEach(item => {
    deparmentList.push({
      value: item,
      label: item
    });
  });

  return deparmentList;
};

export const getAllCoursesForDept = (currDept, coursesList) => {
  let courses = [];

  Object.values(coursesList).forEach(crs => {
    if (currDept === crs.department) {
      courses.push({ value: crs.id, label: crs.id });
    }
  });

  return courses;
};

export const getCourseInfo = (currCourse, coursesList) => {
  let courseInfo = [];

  return courseInfo;
};

export const getAllDepartments = coursesList => {
  let temp = [];
  let deparmentList = [];

  if (isValid(coursesList)) {
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
  }

  return deparmentList;
};

export const getAllCoursesForDept = (currDept, coursesList) => {
  let courses = [];

  if (isValid(coursesList) && isValid(currDept)) {
    Object.values(coursesList).forEach(crs => {
      if (
        currDept
          .toString()
          .trim()
          .toUpperCase() ===
        crs.department
          .toString()
          .trim()
          .toUpperCase()
      ) {
        courses.push({ value: crs.id, label: crs.id });
      }
    });
  }

  return courses;
};

export const getCourseInfo = (currCourse, coursesList) => {
  let courseInfo = [];

  if (isValid(coursesList) && isValid(currCourse)) {
    Object.values(coursesList).forEach(crs => {
      if (
        currCourse
          .toString()
          .trim()
          .toUpperCase() ===
        crs.id
          .toString()
          .trim()
          .toUpperCase()
      ) {
        courseInfo = crs;
      }
    });
  }

  return courseInfo;
};

export const capitalizeFirstChar = text => {
  let result = "";

  if (isValid(text)) {
    result = text
      .toLowerCase()
      .split(" ")
      .map(temp => temp.charAt(0).toUpperCase() + temp.slice(1))
      .join(" ");
  }

  return result;
};

const isValid = item => {
  return item !== undefined && item !== null && item.length !== 0;
};

export const getAllDepartments = coursesList => {
  let temp = [];
  let deparmentList = [];

  if (
    coursesList !== undefined &&
    coursesList !== null &&
    coursesList.length !== 0
  ) {
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

  if (
    coursesList !== undefined &&
    coursesList !== null &&
    coursesList.length !== 0
  ) {
    if (currDept !== undefined && currDept !== null && currDept.length !== 0) {
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
  }

  return courses;
};

export const getCourseInfo = (currCourse, coursesList) => {
  let courseInfo = [];

  if (
    coursesList !== undefined &&
    coursesList !== null &&
    coursesList.length !== 0
  ) {
    if (
      currCourse !== undefined &&
      currCourse !== null &&
      currCourse.length !== 0
    ) {
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
  }

  return courseInfo;
};

export const courseExists = (currCourse, coursesList) => {
  let found = false;

  if (
    coursesList !== undefined &&
    coursesList !== null &&
    coursesList.length !== 0
  ) {
    if (
      currCourse !== undefined &&
      currCourse !== null &&
      currCourse.length !== 0
    ) {
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
          found = true;
        }
      });
    }
  }

  return found;
};

import {
  getAllDepartments,
  getAllCoursesForDept,
  getCourseInfo
} from "../Utils/utils";
import { sampleCoursesList } from "./testData";

/*
    Test - getAllDepartments()
*/

describe("Utils - getAllDepartments", () => {
  it("returns a list of all the Departments given a courses List", () => {
    const expected = [
      {
        label: "Computer Science",
        value: "Computer Science"
      },
      {
        label: "Mathematics",
        value: "Mathematics"
      }
    ];
    const result = getAllDepartments(sampleCoursesList);

    expect(result).toEqual(expected);
  });
});

/*
    Test - getAllCoursesForDept()
*/

describe("Utils - getAllCoursesForDept", () => {
  it("returns a list of all the Courses for a specific Department", () => {
    const expected = [
      {
        label: "COMP 2140",
        value: "COMP 2140"
      },
      {
        label: "COMP 1010",
        value: "COMP 1010"
      }
    ];
    const result = getAllCoursesForDept("Computer Science", sampleCoursesList);

    expect(result).toEqual(expected);
  });
});

/*
    Test - getCourseInfo()
*/

describe("Utils - getCourseInfo", () => {
  it("returns a Course object containning all its info for a specific Course", () => {
    const expected = {
      id: "MATH 1700",
      department: "Mathematics",
      difficulty: 8,
      name: "Calculus 2",
      section_ratings: { "Justin Timberlake": 7, Adele: 5 }
    };
    const result = getCourseInfo("MATH 1700", sampleCoursesList);

    expect(result).toEqual(expected);
  });
});

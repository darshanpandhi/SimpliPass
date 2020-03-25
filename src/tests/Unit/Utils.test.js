import {
  getAllDepartments,
  getAllCoursesForDept,
  getCourseInfo,
  courseExists
} from "../../Utils/utils";
import { sampleCoursesList } from "../Stub";

////////////////////////////////////
//   Test - getAllDepartments()
////////////////////////////////////

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

  it("returns empty list of Departments given an empty courses List", () => {
    const expected = [];
    const result = getAllDepartments([]);

    expect(result).toEqual(expected);
  });

  it("returns empty list of Departments given a null courses List", () => {
    const expected = [];
    const result = getAllDepartments(null);

    expect(result).toEqual(expected);
  });

  it("returns empty list of Departments given an undefined courses List", () => {
    const expected = [];
    const result = getAllDepartments(undefined);

    expect(result).toEqual(expected);
  });
});

////////////////////////////////////
//   Test - getAllCoursesForDept()
////////////////////////////////////

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

  it("returns empty list given an empty current Department and empty courses List ", () => {
    const expected = [];
    const result = getAllCoursesForDept("", []);

    expect(result).toEqual(expected);
  });

  it("returns empty list given a null current Department and null courses List ", () => {
    const expected = [];
    const result = getAllCoursesForDept(null, null);

    expect(result).toEqual(expected);
  });

  it("returns empty list given undefined current Department and undefined courses List ", () => {
    const expected = [];
    const result = getAllCoursesForDept(undefined, undefined);

    expect(result).toEqual(expected);
  });

  it("returns empty list given a current Department that doesn't exist", () => {
    const expected = [];
    const result = getAllCoursesForDept(
      "Unknown Department",
      sampleCoursesList
    );

    expect(result).toEqual(expected);
  });

  it("returns a list of all the Courses for a specific Department in mixed cases", () => {
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
    const result = getAllCoursesForDept("cOmPuTer ScIeNcE", sampleCoursesList);

    expect(result).toEqual(expected);
  });

  it("returns a list of all the Courses for a specific Department with whitespace", () => {
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
    const result = getAllCoursesForDept(
      "          Computer Science    ",
      sampleCoursesList
    );

    expect(result).toEqual(expected);
  });
});

////////////////////////////////////
//    Test - courseExists()
////////////////////////////////////

describe("Utils - courseExists", () => {
  it("returns true if user input course id exists in the main course list", () => {
    const expected = true;
    const result = courseExists("MATH 1700", sampleCoursesList);

    expect(result).toEqual(expected);
  });

  it("returns false given a current Course that doesn't exist", () => {
    const expected = false;
    const result = courseExists("UNKNOWN 1010", sampleCoursesList);

    expect(result).toEqual(expected);
  });

  it("returns false for empty current Course and empty Course list", () => {
    const expected = false;
    const result = courseExists("", []);

    expect(result).toEqual(expected);
  });

  it("returns false for null current Course and null Course list", () => {
    const expected = false;
    const result = courseExists(null, null);

    expect(result).toEqual(expected);
  });

  it("returns false for undefined current Course and undefined Course list", () => {
    const expected = false;
    const result = courseExists(undefined, undefined);

    expect(result).toEqual(expected);
  });

  it("returns true given a current Course with mixed cases, when found match", () => {
    const expected = true;
    const result = courseExists("mAtH 1700", sampleCoursesList);

    expect(result).toEqual(expected);
  });

  it("returns true given a current Course with whitespace, when found match", () => {
    const expected = true;
    const result = courseExists("     MATH 1700    ", sampleCoursesList);

    expect(result).toEqual(expected);
  });
});

////////////////////////////////////
//    Test - getCourseInfo()
////////////////////////////////////

describe("Utils - getCourseInfo", () => {
  it("returns a Course object containning all its info for a specific Course", () => {
    const expected = {
      department: "Mathematics",
      difficulty: 6.7,
      difficultyCount: 8,
      id: "MATH 1700",
      name: "Calculus 2",
      sectionRatings: {
        Adele: {
          count: 2,
          rating: 5
        },
        "Justin Timberlake": {
          count: 2,
          rating: 7
        }
      }
    };
    const result = getCourseInfo("MATH 1700", sampleCoursesList);

    expect(result).toEqual(expected);
  });

  it("returns empty list for empty current Course and empty Course list", () => {
    const expected = [];
    const result = getCourseInfo("", []);

    expect(result).toEqual(expected);
  });

  it("returns empty list for null current Course and null Course list", () => {
    const expected = [];
    const result = getCourseInfo(null, null);

    expect(result).toEqual(expected);
  });

  it("returns empty list for undefined current Course and undefined Course list", () => {
    const expected = [];
    const result = getCourseInfo(undefined, undefined);

    expect(result).toEqual(expected);
  });

  it("returns empty list given a current Course that doesn't exist", () => {
    const expected = [];
    const result = getCourseInfo("UNKNOWN 1010", sampleCoursesList);

    expect(result).toEqual(expected);
  });

  it("returns Course object given a current Course with mixed cases", () => {
    const expected = {
      department: "Mathematics",
      difficulty: 6.7,
      difficultyCount: 8,
      id: "MATH 1700",
      name: "Calculus 2",
      sectionRatings: {
        Adele: {
          count: 2,
          rating: 5
        },
        "Justin Timberlake": {
          count: 2,
          rating: 7
        }
      }
    };
    const result = getCourseInfo("mAtH 1700", sampleCoursesList);

    expect(result).toEqual(expected);
  });

  it("returns Course object given a current Course with whitespace", () => {
    const expected = {
      department: "Mathematics",
      difficulty: 6.7,
      difficultyCount: 8,
      id: "MATH 1700",
      name: "Calculus 2",
      sectionRatings: {
        Adele: {
          count: 2,
          rating: 5
        },
        "Justin Timberlake": {
          count: 2,
          rating: 7
        }
      }
    };
    const result = getCourseInfo("     MATH 1700    ", sampleCoursesList);

    expect(result).toEqual(expected);
  });
});

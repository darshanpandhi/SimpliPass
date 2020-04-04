const {
  targetURL,
  departmentSelector,
  departmentSelectorInput,
  courseSelector,
  courseSelectorInput,
  courseViewContainer,
  courseRecommendationsNavItem,
  courseRecommendationsHeader,
  courseRecommendationsContainer,
  reviewCourseNavItem,
  reviewCourseHeader,
  crsCode,
  crsNum,
  crsName,
  crsDept,
  crsDiff,
  instr,
  instrRating,
  submitButton,
  dialogHeader,
  dialogContainer,
} = require("./XPaths");
const assert = require("assert");
const { Builder, Key, By, until } = require("selenium-webdriver");

describe("User Story 1: View a course to know its difficulty level", function () {
  let driver;

  // Setup browser
  before(async function () {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function () {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";

    assert.equal(result, expected);
  });

  it("Select a Department", async function () {
    await driver
      .wait(until.elementLocated(By.xpath(departmentSelector)), 10000)
      .then((el) => {
        return el.click();
      });

    await driver
      .findElement(By.xpath(departmentSelectorInput))
      .sendKeys("Engineering", Key.ENTER);
  });

  it("Select a Course", async function () {
    await driver.findElement(By.xpath(courseSelector)).click();
    await driver
      .findElement(By.xpath(courseSelectorInput))
      .sendKeys("ENG 1450", Key.ENTER);
  });

  it("View Difficulty of a Course", async function () {
    let result = await driver
      .findElement(By.xpath(courseViewContainer))
      .getText();
    result = result.includes("Difficulty Level");
    const expected = true;

    assert.equal(result, expected);
  });

  // Close browser after all tests complete
  after(() => driver && driver.quit());
});

describe("User Story 2: View course-specific instructor ratings", function () {
  let driver;

  before(async function () {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function () {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";
    assert.equal(result, expected);
  });

  it("Select a Department", async function () {
    await driver
      .wait(until.elementLocated(By.xpath(departmentSelector)), 10000)
      .then((el) => {
        return el.click();
      });
    await driver
      .findElement(By.xpath(departmentSelectorInput))
      .sendKeys("Computer Science", Key.ENTER);
  });

  it("Select a Course", async function () {
    await driver.findElement(By.xpath(courseSelector)).click();
    await driver
      .findElement(By.xpath(courseSelectorInput))
      .sendKeys("COMP 1010", Key.ENTER);
  });

  it("View all Instructor Ratings of the Course", async function () {
    let result = await driver
      .findElement(By.xpath(courseViewContainer))
      .getText();
    result = result.includes("Section Ratings");
    const expected = true;

    assert.equal(result, expected);
  });

  after(() => driver && driver.quit());
});

describe("User Story 3: Review a Course and its Section", function () {
  let driver;

  before(async function () {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function () {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";

    assert.equal(result, expected);
  });

  it("Navigate to Review Course and wait for elements to load", async function () {
    await driver.findElement(By.xpath(reviewCourseNavItem)).click();
    await driver.wait(
      until.elementLocated(By.xpath(reviewCourseHeader)),
      10000
    );
  });

  it("Fill Course ID", async function () {
    await driver.findElement(By.xpath(crsCode)).sendKeys("CHEM", Key.ENTER);
    await driver.findElement(By.xpath(crsNum)).sendKeys("1300", Key.ENTER);
  });

  it("Fill Name", async function () {
    await driver
      .findElement(By.xpath(crsName))
      .sendKeys("Structure and Modelling in Chemistry", Key.ENTER);
  });

  it("Fill Department", async function () {
    await driver
      .findElement(By.xpath(crsDept))
      .sendKeys("Chemistry", Key.ENTER);
  });

  it("Select Difficulty Level", async function () {
    await driver.findElement(By.xpath(crsDiff)).sendKeys("9", Key.ENTER);
  });

  it("Fill Instructor", async function () {
    await driver
      .findElement(By.xpath(instr))
      .sendKeys("Taylor Swift", Key.ENTER);
  });

  it("Select Instructor Rating", async function () {
    await driver.findElement(By.xpath(instrRating)).sendKeys("2", Key.ENTER);
  });

  it("Submit Review and wait for confirmation message", async function () {
    await driver.findElement(By.xpath(submitButton)).click();
    await driver.wait(until.elementLocated(By.xpath(dialogHeader)), 10000);

    let result = await driver.findElement(By.xpath(dialogContainer)).getText();
    result = result.includes("Success!");
    const expected = true;

    assert.equal(result, expected);
  });

  after(() => driver && driver.quit());
});

describe("User Story 4: Get recommendations for popular elective courses", function () {
  let driver;

  before(async function () {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function () {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";

    assert.equal(result, expected);
  });

  it("Navigate to Course Recommendations and wait for list to load", async function () {
    await driver.findElement(By.xpath(courseRecommendationsNavItem)).click();
    await driver.wait(
      until.elementLocated(By.xpath(courseRecommendationsHeader)),
      10000
    );
  });

  it("View list of all Recommended Courses", async function () {
    let result = await driver
      .findElement(By.xpath(courseRecommendationsContainer))
      .getText();
    result =
      result.includes("Recommended Popular Courses") &&
      result.includes("Difficulty");
    const expected = true;

    assert.equal(result, expected);
  });

  after(() => driver && driver.quit());
});

describe("Get error message when trying to submit review with empty fields", function () {
  let driver;

  before(async function () {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function () {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";

    assert.equal(result, expected);
  });

  it("Navigate to Review Course and wait for elements to load", async function () {
    await driver.findElement(By.xpath(reviewCourseNavItem)).click();
    await driver.wait(
      until.elementLocated(By.xpath(reviewCourseHeader)),
      10000
    );
  });

  it("Only fill Course ID and leave other fields blank", async function () {
    await driver.findElement(By.xpath(crsCode)).sendKeys("COMP", Key.ENTER);
    await driver.findElement(By.xpath(crsNum)).sendKeys("2140", Key.ENTER);
  });

  it("Try to submit review and wait for error message", async function () {
    await driver.findElement(By.xpath(submitButton)).click();
    await driver.wait(until.elementLocated(By.xpath(dialogHeader)), 10000);

    let result = await driver.findElement(By.xpath(dialogContainer)).getText();
    result = result.includes("Error!");
    const expected = true;

    assert.equal(result, expected);
  });

  after(() => driver && driver.quit());
});

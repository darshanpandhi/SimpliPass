const {
  targetURL,
  departmentSelector,
  departmentSelectorInput,
  courseSelector,
  courseSelectorInput,
  courseViewContainer,
  courseRecommendationsNavItem,
  courseRecommendationsHeader,
  courseRecommendationsContainer
} = require("./XPaths");
const assert = require("assert");
const { Builder, Key, By, until } = require("selenium-webdriver");

describe("User Story 1: View a course to know its difficulty level.", function() {
  let driver;

  // Setup browser
  before(async function() {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function() {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";

    assert.equal(result, expected);
  });

  it("Select a Department", async function() {
    await driver
      .wait(until.elementLocated(By.xpath(departmentSelector)), 10000)
      .then(el => {
        return el.click();
      });

    await driver
      .findElement(By.xpath(departmentSelectorInput))
      .sendKeys("Engineering", Key.ENTER);
  });

  it("Select a Course", async function() {
    await driver.findElement(By.xpath(courseSelector)).click();
    await driver
      .findElement(By.xpath(courseSelectorInput))
      .sendKeys("ENG 1450", Key.ENTER);
  });

  it("View Difficulty of a Course", async function() {
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

describe("User Story 2: View course-specific instructor ratings", function() {
  let driver;

  before(async function() {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function() {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";
    assert.equal(result, expected);
  });

  it("Select a Department", async function() {
    await driver
      .wait(until.elementLocated(By.xpath(departmentSelector)), 10000)
      .then(el => {
        return el.click();
      });
    await driver
      .findElement(By.xpath(departmentSelectorInput))
      .sendKeys("Computer Science", Key.ENTER);
  });

  it("Select a Course", async function() {
    await driver.findElement(By.xpath(courseSelector)).click();
    await driver
      .findElement(By.xpath(courseSelectorInput))
      .sendKeys("COMP 1010", Key.ENTER);
  });

  it("View all Instructor Ratings of the Course", async function() {
    let result = await driver
      .findElement(By.xpath(courseViewContainer))
      .getText();
    result = result.includes("Section Ratings");
    const expected = true;

    assert.equal(result, expected);
  });

  after(() => driver && driver.quit());
});

describe("User Story 4: Get recommendations for popular elective courses", function() {
  let driver;

  before(async function() {
    driver = await new Builder().forBrowser("chrome").build();
  });

  it("Open browser and navigate to SimpliPass website", async function() {
    await driver.get(targetURL);

    const result = await driver.getTitle();
    const expected = "SimpliPass";

    assert.equal(result, expected);
  });

  it("Navigate to Course Recommendations and wait for list to load", async function() {
    await driver.findElement(By.xpath(courseRecommendationsNavItem)).click();
    await driver.wait(
      until.elementLocated(By.xpath(courseRecommendationsHeader)),
      10000
    );
  });

  it("View list of all Recommended Courses", async function() {
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

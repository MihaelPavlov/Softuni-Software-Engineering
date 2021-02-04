const describe = require("mocha").describe;
const assert = require("chai").assert;

function lookupChar(string, index) {
  if (typeof string !== "string" || !Number.isInteger(index)) {
    return undefined;
  }
  if (string.length <= index || index < 0) {
    return "Incorrect index";
  }

  return string.charAt(index);
}
describe("check lookupChar", () => {
  it("Input", () => {
    assert.isUndefined(lookupChar(2, 2), "Input is not string and number");
    assert.isUndefined(
      lookupChar("abv", 1.2),
      "Input is not string and number"
    );
    assert.isUndefined(
      lookupChar("abv", "a"),
      "Input is not string and number"
    );
  });
  it("Is incorrect the index", () => {
    assert.strictEqual(
      lookupChar("Hello", 8),
      "Incorrect index",
      "Incorrect index "
    );
  });
  it("Is char right", () => {
    assert.equal(lookupChar("hello", 1), "e");
  });
  it("Is undefined", () => {
    assert.isUndefined(lookupChar(1, "5"));
  });
  it("Incorect Index", () => {
    assert.equal(lookupChar("", -1), "Incorrect index");
  });
});

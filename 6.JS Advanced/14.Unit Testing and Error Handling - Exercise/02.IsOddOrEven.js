const describe = require("mocha").describe;
const assert = require("chai").assert;

function isOddOrEven(string) {
  if (typeof string !== "string") {
    return undefined;
  }
  if (string.length % 2 === 0) {
    return "even";
  }

  return "odd";
}

describe("check isOddOrEven", () => {
  it("Type is string", () => {
    assert.isUndefined(isOddOrEven(2), "Input is not string");
  });
  it("Is Odd", () => {
    assert.equal(isOddOrEven("2"), "odd");
  });
  it("Is Even", () => {
    assert.equal(isOddOrEven("22"), "even");
  });
});

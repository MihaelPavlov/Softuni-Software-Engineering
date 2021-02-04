const describe = require("mocha").describe;
const assert = require("chai").assert;

let mathEnforcer = {
  addFive: function (num) {
    if (typeof num !== "number") {
      return undefined;
    }
    return num + 5;
  },
  subtractTen: function (num) {
    if (typeof num !== "number") {
      return undefined;
    }
    return num - 10;
  },
  sum: function (num1, num2) {
    if (typeof num1 !== "number" || typeof num2 !== "number") {
      return undefined;
    }
    return num1 + num2;
  },
};

describe("mathEnforcer", function () {
  describe("addFive", function () {
    it("add Number and Floating", () => {
      assert.equal(mathEnforcer.addFive(5), 10);
      assert.equal(mathEnforcer.addFive(5.2), 10.2);
      assert.equal(mathEnforcer.addFive(12.32312), 17.32312);
      assert.equal(mathEnforcer.addFive(-12.32312), -7.323119999999999);
    });
    it("isUndefined", () => {
      assert.isUndefined(mathEnforcer.addFive(""));
      assert.isUndefined(mathEnforcer.addFive(undefined));
    });
  });
  describe("substractTen", function () {
    it("substract", () => {
      assert.equal(mathEnforcer.subtractTen(10), 0);
    });
    it("substract floating", () => {
      assert.equal(mathEnforcer.subtractTen(10.3213), 0.3213000000000008);
      assert.equal(mathEnforcer.subtractTen(10.5), 0.5);
      assert.equal(mathEnforcer.subtractTen(0), -10);
      assert.equal(mathEnforcer.subtractTen(-10.2), -20.2);
    });
    it("isUndefined", () => {
      assert.isUndefined(mathEnforcer.subtractTen(""));
    });
    it("isUndefined2", () => {
      assert.isUndefined(mathEnforcer.subtractTen(undefined));
    });
  });
  describe("sum", function () {
    it("sum", () => {
      assert.equal(mathEnforcer.sum(5, 5), 10);
    });
    it("sum floating", () => {
      assert.equal(mathEnforcer.sum(5.4, 5.6), 11);
    });
    it("isUndefined", () => {
      assert.isUndefined(mathEnforcer.sum("", ""));
    });
    it("isUndefined2", () => {
      assert.isUndefined(mathEnforcer.sum(12, ""));
    });
    it("isUndefined3", () => {
      assert.isUndefined(mathEnforcer.sum("12", 2));
    });
  });
});

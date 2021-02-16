const describe = require("mocha").describe;
const assert = require("chai").assert;
let dealership = {
  newCarCost: function (oldCarModel, newCarPrice) {
    let discountForOldCar = {
      "Audi A4 B8": 15000,
      "Audi A6 4K": 20000,
      "Audi A8 D5": 25000,
      "Audi TT 8J": 14000,
    };

    if (discountForOldCar.hasOwnProperty(oldCarModel)) {
      let discount = discountForOldCar[oldCarModel];
      let finalPrice = newCarPrice - discount;
      return finalPrice;
    } else {
      return newCarPrice;
    }
  },

  carEquipment: function (extrasArr, indexArr) {
    let selectedExtras = [];
    indexArr.forEach((i) => {
      selectedExtras.push(extrasArr[i]);
    });

    return selectedExtras;
  },

  euroCategory: function (category) {
    if (category >= 4) {
      let price = this.newCarCost("Audi A4 B8", 30000);
      let total = price - price * 0.05;
      return `We have added 5% discount to the final price: ${total}.`;
    } else {
      return "Your euro category is low, so there is no discount from the final price!";
    }
  },
};
describe("Tests …", function () {
  describe("return Old Car", function () {
    it("Test is old card return with discount", function () {
      let price = dealership.newCarCost("Audi A4 B8", 30000);
      let price1 = dealership.newCarCost("Audi A6 4K", 20000);
      let price2 = dealership.newCarCost("Audi A8 D5", 25000);
      let price3 = dealership.newCarCost("Audi TT 8J", 14000);
      let price4 = dealership.newCarCost("Audi TT 8J", -100);
      let price5 = dealership.newCarCost("Audi TT 8J", 10.22);

      assert.equal(price, 15000);
      assert.equal(typeof price, "number");
      assert.equal(price1, 0);
      assert.equal(price2, 0);
      assert.equal(price3, 0);
      assert.equal(price4, -14100);
      let ca = dealership.newCarCost(100, -100);
      let ca2 = dealership.newCarCost(100, "das");
      assert.equal(ca, -100);
      assert.equal(ca2, "das");
      assert.equal(price5, -13989.78);
    });
    it("Test if is not old car ", function () {
      let price = dealership.newCarCost("Audi", 30000);
      let price1 = dealership.newCarCost("Audi", 2000);
      let price2 = dealership.newCarCost("Audi", -200);

      assert.equal(price, 30000);
      assert.equal(price1, 2000);
      assert.equal(price2, -200);
    });
    it("Test is function", function () {
      assert.isFunction(dealership.newCarCost);
    });
  });
  describe("carEquipment Tests", function () {
    it("Test First array ", function () {
      let extras = dealership.carEquipment(
        ["heated seats", "sliding roof", "sport rims", "navigation"],
        [1]
      );
      let extras2 = dealership.carEquipment(
        ["heated seats", "sliding roof", "sport rims", "navigation"],
        [1, 2, 0]
      );

      assert.equal(extras[0], "sliding roof");
      assert.equal(extras2[0], "sliding roof");
      assert.equal(extras2[1], "sport rims");
      assert.equal(extras2[2], "heated seats");
    });
    it("Test is function", function () {
      assert.isFunction(dealership.carEquipment);
    });
    it("Test is empty", function () {
      let extras = dealership.carEquipment([], []);
      assert.isEmpty(extras);
    });
  });
  describe("Euro category Tests", function () {
    it("Test ecology", function () {
      let euro = dealership.euroCategory(2);
      let euro2 = dealership.euroCategory(-1);
      let euro3 = dealership.euroCategory(2.321);
      let euro4 = dealership.euroCategory(4);

      assert.equal(
        euro,
        "Your euro category is low, so there is no discount from the final price!"
      );
      assert.equal(
        euro2,
        "Your euro category is low, so there is no discount from the final price!"
      );
      assert.equal(
        euro3,
        "Your euro category is low, so there is no discount from the final price!"
      );
      assert.equal(
        euro4,
        "We have added 5% discount to the final price: 14250."
      );
    });
    it("Test ecology with discount", function () {
      let euro = dealership.euroCategory(5);
      let euro2 = dealership.euroCategory(20);
      let euro3 = dealership.euroCategory(5.5);
      assert.equal(
        euro,
        "We have added 5% discount to the final price: 14250."
      );
      assert.equal(
        euro2,
        "We have added 5% discount to the final price: 14250."
      );
      assert.equal(
        euro3,
        "We have added 5% discount to the final price: 14250."
      );
    });
    it("Test is function", function () {
      assert.isFunction(dealership.euroCategory);
    });
  });
  describe("Object", function () {
    it("Test is object", function () {
      assert.isObject(dealership);
    });
  });
  // TODO: …
});

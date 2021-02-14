const describe = require("mocha").describe;
const assert = require("chai").assert;
let pizzUni = {
  makeAnOrder: function (obj) {
    if (!obj.orderedPizza) {
      throw new Error("You must order at least 1 Pizza to finish the order.");
    } else {
      let result = `You just ordered ${obj.orderedPizza}`;
      if (obj.orderedDrink) {
        result += ` and ${obj.orderedDrink}.`;
      }
      return result;
    }
  },

  getRemainingWork: function (statusArr) {
    const remainingArr = statusArr.filter((s) => s.status != "ready");

    if (remainingArr.length > 0) {
      let pizzaNames = remainingArr.map((p) => p.pizzaName).join(", ");
      let pizzasLeft = `The following pizzas are still preparing: ${pizzaNames}.`;

      return pizzasLeft;
    } else {
      return "All orders are complete!";
    }
  },

  orderType: function (totalSum, typeOfOrder) {
    if (typeOfOrder === "Carry Out") {
      totalSum -= totalSum * 0.1;

      return totalSum;
    } else if (typeOfOrder === "Delivery") {
      return totalSum;
    }
  },
};

describe("pizzaUni", function () {
  describe("makeAnOrder", function () {
    it("Test Full Order With Pizza and Drink", function () {
      let order = pizzUni.makeAnOrder({
        orderedPizza: "Capresse",
        orderedDrink: "Cola",
      });
      assert.equal(order, "You just ordered Capresse and Cola.");
    });
    it("Test Order With Pizza", function () {
      let order = pizzUni.makeAnOrder({
        orderedPizza: "Capresse",
      });
      assert.equal(order, "You just ordered Capresse");
    });
    it("Test throw exception only with ordered Drink", function () {
      assert.throws(() =>
        pizzUni.makeAnOrder({
          orderedDrink: "Cola",
        })
      );
    });
    it("Test throw exception only with other obj", function () {
      assert.throws(() =>
        pizzUni.makeAnOrder({
          Name: "Misho",
          SecondName: "Ivan",
        })
      );
    });
  });

  describe("GetRemainingWork", function () {
    it("Test Pizza should preparing", function () {
      let order = pizzUni.getRemainingWork([
        { pizzaName: "Italiano", status: "preparing" },
      ]);
      assert.equal(
        order,
        `The following pizzas are still preparing: Italiano.`
      );
    });
    it("Test Two Pizzas should preparing", function () {
      let order = pizzUni.getRemainingWork([
        { pizzaName: "Italiano", status: "preparing" },
        { pizzaName: "Caprese", status: "preparing" },
      ]);
      assert.equal(
        order,
        `The following pizzas are still preparing: Italiano, Caprese.`
      );
    });
    it("Test Tready pizzas", function () {
      let order = pizzUni.getRemainingWork([
        { pizzaName: "Italiano", status: "ready" },
        { pizzaName: "Caprese", status: "ready" },
      ]);
      assert.equal(order, `All orders are complete!`);
    });
  });
  describe("orderType", function () {
    it("Test orderType with Carry Out type", function () {
      let order = pizzUni.orderType(100, "Carry Out");
      assert.equal(order, 90);
    });
    it("Test orderType with Delivery type", function () {
      let order = pizzUni.orderType(100, "Delivery");
      assert.equal(order, 100);
    });
    it("Test if order type doesnt exist must return undefined", function () {
      let order = pizzUni.orderType(100, "Test");
      assert.equal(order, undefined);
    });
  });
});

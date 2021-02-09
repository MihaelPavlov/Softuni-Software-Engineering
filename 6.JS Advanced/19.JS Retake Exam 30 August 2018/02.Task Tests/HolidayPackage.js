const describe = require("mocha").describe;
const assert = require("chai").assert;

class HolidayPackage {
  constructor(destination, season) {
    this.vacationers = [];
    this.destination = destination;
    this.season = season;
    this.insuranceIncluded = false; // Default value
  }

  showVacationers() {
    if (this.vacationers.length > 0)
      return "Vacationers:\n" + this.vacationers.join("\n");
    else return "No vacationers are added yet";
  }

  addVacationer(vacationerName) {
    if (typeof vacationerName !== "string" || vacationerName === " ") {
      throw new Error("Vacationer name must be a non-empty string");
    }
    if (vacationerName.split(" ").length !== 2) {
      throw new Error("Name must consist of first name and last name");
    }
    this.vacationers.push(vacationerName);
  }

  get insuranceIncluded() {
    return this._insuranceIncluded;
  }

  set insuranceIncluded(insurance) {
    if (typeof insurance !== "boolean") {
      throw new Error("Insurance status must be a boolean");
    }
    this._insuranceIncluded = insurance;
  }

  generateHolidayPackage() {
    if (this.vacationers.length < 1) {
      throw new Error("There must be at least 1 vacationer added");
    }
    let totalPrice = this.vacationers.length * 400;

    if (this.season === "Summer" || this.season === "Winter") {
      totalPrice += 200;
    }

    totalPrice += this.insuranceIncluded === true ? 100 : 0;

    return (
      "Holiday Package Generated\n" +
      "Destination: " +
      this.destination +
      "\n" +
      this.showVacationers() +
      "\n" +
      "Price: " +
      totalPrice
    );
  }
}
let holidayPackage = new HolidayPackage("Italy", "Summer");

console.log(holidayPackage.showVacationers());

// should throw an error
try {
  holidayPackage.generateHolidayPackage();
} catch (err) {
  console.log("Error: " + err.message);
}

// should throw an error
try {
  holidayPackage.addVacationer(" ");
} catch (err) {
  console.log("Error: " + err.message);
}

// should throw an error
try {
  holidayPackage.addVacationer("Ivan");
} catch (err) {
  console.log("Error: " + err.message);
}

holidayPackage.addVacationer("Ivan Ivanov");
holidayPackage.addVacationer("Petar Petrov");
holidayPackage.addVacationer("Georgi Georgiev");

console.log(holidayPackage.showVacationers());

// should throw an error
try {
  holidayPackage.insuranceIncluded = "true";
} catch (err) {
  console.log("Error: " + err.message);
}

holidayPackage.insuranceIncluded = true;

console.log(holidayPackage.generateHolidayPackage());

describe("check Initalize the class", function () {
  it("generete Holiday Package must throw error", function () {
    assert.throws(() => holiday.generateHolidayPackage(), Error);
  });
  it("is instance right", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");
    assert.equal(holiday.constructor.name, "HolidayPackage");
    assert.instanceOf(holiday, HolidayPackage);
  });
  it("initialize right", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.equal(holiday.destination, "Lovech");
    assert.equal(holiday.season, "Summer");
  });

  it("insuranceIncluded need to be false", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.isFalse(holiday.insuranceIncluded);
  });
  it("showVacationers need to throw message", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.equal(holiday.showVacationers(), "No vacationers are added yet");
  });
  it("AddVacationer need throw Error for not empty string or if input is different then string", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.throws(() => holiday.addVacationer(" "), Error);
  });
  it("AddVacationer need throw Error for not firstName and SecondName", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.throws(() => holiday.addVacationer("Miahel"), Error);
  });
  it("Count of vacationers need to be 2", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    holiday.addVacationer("Mihael Pavlov");
    holiday.addVacationer("Roshko Rsohkov");
    assert.equal(holiday.vacationers.length, 2);
  });
  it("show vacationers", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");
    holiday.addVacationer("Mihael Pavlov");
    holiday.addVacationer("Roshko Rsohkov");
    assert.equal(
      holiday.showVacationers(),
      "Vacationers:\nMihael Pavlov\nRoshko Rsohkov"
    );
  });
  it("change insuranceIncluded to true ", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.isTrue((holiday.insuranceIncluded = true));
  });
  it("change insuranceIncluded to false ", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.isFalse((holiday.insuranceIncluded = false));
  });
  it("change insuranceIncluded to Number  must be throw error ", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");

    assert.throw(() => (holiday.insuranceIncluded = 14));
  });
  it("generateHolidaypackage right", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");
    holiday.addVacationer("Mihael Pavlov");
    holiday.addVacationer("Roshko Rsohkov");
    assert.equal(
      holiday.generateHolidayPackage(),
      "Holiday Package Generated\nDestination: Lovech\nVacationers:\nMihael Pavlov\nRoshko Rsohkov\nPrice: 1000"
    );
  });
  it("generateHolidaypackage if season is not summer or winter price -200", function () {
    let holiday = new HolidayPackage("Lovech", "Summer");
    holiday.addVacationer("Mihael Pavlov");
    holiday.addVacationer("Roshko Rsohkov");
    holiday.season = "Not seasons";
    assert.equal(
      holiday.generateHolidayPackage(),
      "Holiday Package Generated\nDestination: Lovech\nVacationers:\nMihael Pavlov\nRoshko Rsohkov\nPrice: 800"
    );
    assert.equal(holiday.season, "Not seasons");
  });
});

class Vacationer {
  constructor(fullName, creditCard = [1111, "", 111]) {
    this.fullName = fullName;
    this.idNumber = this.generateIDNumber();
    this.creditCard = {
      cardNumber: 1111,
      expirationDate: "",
      securityNumber: 111,
    };

    if (creditCard !== undefined) {
      this.addCreditCardInfo(creditCard);
    }

    this.wishList = [];
  }

  get fullName() {
    return this._fullName;
  }
  set fullName(value) {
    if (value.length !== 3) {
      throw new Error(
        "Name must include first name, middle name and last name"
      );
    }
    const name = `${value[0]} ${value[1]} ${value[2]}`;
    if (!/^[A-Z][a-z]+ [A-Z][a-z]+ [A-Z][a-z]+$/gm.test(name)) {
      throw new Error("Invalid full name");
    }
    this._fullName = {
      firstName: value[0],
      middleName: value[1],
      lastName: value[2],
    };
  }

  generateIDNumber() {
    let fullname = Object.values(this.fullName);
    let generetedNumber =
      231 * fullname[0].charCodeAt(0) + 139 * fullname[1].length;
    let result = "";
    if (
      fullname[2].endsWith("a") ||
      fullname[2].endsWith("e") ||
      fullname[2].endsWith("o") ||
      fullname[2].endsWith("i") ||
      fullname[2].endsWith("u")
    ) {
      result = generetedNumber.toString() + "8";
    } else {
      result = generetedNumber.toString() + "7";
    }
    return result;
  }

  addCreditCardInfo(input) {
    if (input.length !== 3) {
      throw new Error("Missing credit card information");
    }
    if (typeof input[0] !== "number" || typeof input[2] !== "number") {
      throw new Error("Invalid credit card details");
    }

    this.creditCard = {
      cardNumber: input[0],
      expirationDate: input[1],
      securityNumber: input[2],
    };
  }

  addDestinationToWishList(destionation) {
    if (this.wishList.includes(destionation)) {
      throw new Error("Destination already exists in wishlist");
    }
    this.wishList.push(destionation);
    this.wishList.sort((a, b) => a.length - b.length);
  }
  getVacationerInfo() {
    let vacationerInfo = [];
    vacationerInfo.push(
      `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}`
    );
    vacationerInfo.push(`ID Number: ${this.idNumber}`);

    vacationerInfo.push("Wishlist:");
    const destinations =
      this.wishList.length > 0 ? this.wishList.join(", ") : "empty";
    vacationerInfo.push(destinations);

    vacationerInfo.push("Credit Card:");
    vacationerInfo.push(`Card Number: ${this.creditCard.cardNumber}`);
    vacationerInfo.push(`Expiration Date: ${this.creditCard.expirationDate}`);
    vacationerInfo.push(`Security Number: ${this.creditCard.securityNumber}`);

    return vacationerInfo.join("\n");
  }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(
  ["Tania", "Ivanova", "Zhivkova"],
  [123456789, "10/01/2018", 777]
);

// Should throw an error (Invalid full name)
try {
  let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
  console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
  let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
  vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
  console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList("Spain");
vacationer1.addDestinationToWishList("Germany");
vacationer1.addDestinationToWishList("Bali");

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());

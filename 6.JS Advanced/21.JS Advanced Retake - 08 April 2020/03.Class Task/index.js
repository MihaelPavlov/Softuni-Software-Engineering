class Bank {
  constructor(bankName) {
    this.bankName = bankName;
    this.allCustomers = [];
  }

  newCustomer(customer) {
    if (this.allCustomers.find((x) => customer.personalId === x.personalId)) {
      throw new Error(
        `${customer.firstName} ${customer.lastName} is already our customer!`
      );
    }
    this.allCustomers.push(customer);
    return customer;
  }

  depositMoney(personalId, amount) {
    if (this.allCustomers.find((x) => x.personalId === personalId)) {
      let customer = this.allCustomers.find((x) => x.personalId === personalId);
      if (!customer.hasOwnProperty("totalMoney")) {
        customer["totalMoney"] = 0;
      }
      if (!customer.hasOwnProperty("transactions")) {
        customer["transactions"] = [];
      }
      customer.transactions.push(
        `${customer.transactions.length + 1}. ${customer.firstName} ${
          customer.lastName
        } made deposit of ${amount}$!`
      );
      customer["totalMoney"] += amount;
      return customer.totalMoney + "$";
    }
    throw new Error("We have no customer with this ID!");
  }
  withdrawMoney(personalId, amount) {
    if (this.allCustomers.find((x) => x.personalId === personalId)) {
      let customer = this.allCustomers.find((x) => x.personalId === personalId);
      if (customer.totalMoney < amount) {
        throw new Error(
          `${customer.firstName} ${customer.lastName} does not have enough money to withdrew that amount!`
        );
      }
      if (!customer.hasOwnProperty("transactions")) {
        customer["transactions"] = [];
      }
      customer.transactions.push(
        `${customer.transactions.length + 1}. ${customer.firstName} ${
          customer.lastName
        } withdraw ${amount}$!`
      );
      customer["totalMoney"] -= amount;
      return customer.totalMoney + "$";
    }
    throw new Error("We have no customer with this ID!");
  }
  customerInfo(personalId) {
    if (this.allCustomers.find((x) => x.personalId === personalId)) {
      let customer = this.allCustomers.find((x) => x.personalId === personalId);
      let result = [];
      result.push(`Bank name: ${this.bankName}`);
      result.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
      result.push(`Customer ID: ${customer.personalId}`);
      result.push(`Total Money: ${customer.totalMoney}$`);
      result.push("Transactions:");
      customer.transactions.reverse();
      customer.transactions.forEach((element) => {
        result.push(element);
      });
      return result.join("\n");
    }
    throw new Error("We have no customer with this ID!");
  }
}

let bank = new Bank("SoftUni Bank");

console.log(
  bank.newCustomer({
    firstName: "Svetlin",
    lastName: "Nakov",
    personalId: 6233267,
  })
);
console.log(
  bank.newCustomer({
    firstName: "Mihaela",
    lastName: "Mileva",
    personalId: 4151596,
  })
);

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

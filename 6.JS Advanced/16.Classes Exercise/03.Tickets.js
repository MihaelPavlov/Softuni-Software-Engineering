function solve(inputTickets, criteria) {
  class Ticket {
    constructor(destination, price, status) {
      this.destination = destination;
      this.price = price;
      this.status = status;
    }
  }
  let result = [];
  for (let i = 0; i < inputTickets.length; i++) {
    let inputArgs = inputTickets[i].split("|");
    let name = inputArgs[0];
    let price = Number(inputArgs[1]);
    let status = inputArgs[2];

    const ticket = new Ticket(name, Number(price), status);
    result.push(ticket);
  }

  let result2 = sortByCriteria(criteria, result);
  return result2[2];

  function sortByCriteria(name, array) {
    if (name === "destination") {
      return array.sort((a, b) => {
        if (a.destination < b.destination) return -1;
        return a.destination > b.destination ? 1 : 0;
      });
    } else if (name === "price") {
      return array.sort((a, b) => {
        if (a.price < b.price) return -1;
        return a.price > b.price ? 1 : 0;
      });
    } else if (name == "status") {
      return array.sort((a, b) => {
        if (a.status < b.status) return -1;
        return a.status > b.status ? 1 : 0;
      });
    }
  }
}
console.log(
  solve(
    [
      "Philadelphia|94.20|available",
      "New York City|95.99|available",
      "New York City|95.99|sold",
      "Boston|126.20|departed",
    ],
    "destination"
  )
);

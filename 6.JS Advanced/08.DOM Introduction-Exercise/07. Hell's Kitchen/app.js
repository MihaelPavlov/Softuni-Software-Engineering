function solve() {
  document.querySelector("#btnSend").addEventListener("click", onClick);
  let input = document.querySelector("#inputs>textarea");
  const bestRestaurantP = document.querySelector("#bestRestaurant>p");
  const workerP = document.querySelector("#workers>p");
  function onClick() {
    const arr = JSON.parse(input.value);

    const restaurants = {};

    arr.forEach((line) => {
      const tokens = line.split(" - ");

      const name = tokens[0];
      const workersArr = tokens[1].split(", ");
      let workers = [];

      for (const worker of workersArr) {
        let workerTokens = worker.split(" ");
        let workerName = workerTokens[0];
        let workerSalary = workerTokens[1];
        workers.push({
          name: workerName,
          salary: Number(workerSalary),
        });
      }

      if (restaurants[name]) {
        workers = workers.concat(restaurants[name].workers);
      }
      workers.sort((a, b) => b.salary - a.salary);
      let bestSalary = workers[0].salary;
      let averageSalary =
        workers.reduce((sum, worker) => sum + worker.salary, 0) /
        workers.length;

      restaurants[name] = { workers, averageSalary, bestSalary };
    });

    let bestRestaurantSalary = 0;
    let best = undefined;

    for (const name in restaurants) {
      if (restaurants[name].averageSalary > bestRestaurantSalary) {
        best = {
          name,
          workers: restaurants[name].workers,
          bestSalary: restaurants[name].bestSalary,
          averageSalary: restaurants[name].averageSalary,
        };

        bestRestaurantSalary = restaurants[name].averageSalary;
      }
    }
    bestRestaurantP.textContent = `Name: ${
      best.name
    } Average Salary: ${best.averageSalary.toFixed(
      2
    )} Best Salary: ${best.bestSalary.toFixed(2)}`;

    let workersStringResult = [];

    best.workers.forEach((worker) => {
      workersStringResult.push(
        `Name: ${worker.name} With Salary: ${worker.salary}`
      );
    });

    workerP.textContent = workersStringResult.join(" ");
  }
}

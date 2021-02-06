class Company {
  constructor() {
    this.departments = [];
  }

  addEmployee(username, salary, position, department) {
    if (username == "" || salary == "" || position == "" || department == "") {
      console.log("Invalid input!");
      return;
    }
    if (salary < 0) {
      console.log("Invalid input!");
      return;
    }
    this.departments.push({ department, username, salary, position });
    return `New employee is hired. Name: ${username}. Position: ${position}`;
  }

  bestDepartment() {
    this.departments.sort((a, b) => {
      if (a.department < b.department) return -1;
      return a.department > b.department ? 1 : 0;
    });
    let resultSalary = {};

    for (const el of this.departments) {
      if (!resultSalary[el.department]) {
        resultSalary[el.department] = { salary: el.salary, count: 1 };

        continue;
      }
      resultSalary[el.department].salary += el.salary;
      resultSalary[el.department].count++;
    }

    let resultName = ["", 0];
    for (const el in resultSalary) {
      resultSalary[el].salary =
        resultSalary[el].salary / resultSalary[el].count;
      if (resultSalary[el].salary > resultName[1]) {
        resultName[0] = el;
        resultName[1] = Number(resultSalary[el].salary);
      }
    }

    let bestDepartment = this.departments.map(function (x) {
      if (x.department === resultName[0]) {
        return x;
      }
    });

    let filtered = bestDepartment
      .filter(
        (x) =>
          function (x) {
            return x != null;
          }
      )
      .sort((a, b) => b.salary - a.salary || b.username - a.username);

    console.log(`Best department is: ${filtered[0].department}`);
    console.log(`Average salary: ${resultName[1].toFixed(2)}`);
    filtered.forEach((el) => {
      if (el != undefined) {
        console.log(el.username, el.salary, el.position);
      }
    });
  }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

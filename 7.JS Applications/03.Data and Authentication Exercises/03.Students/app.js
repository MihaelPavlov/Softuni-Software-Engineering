function attachEvents() {
  getAllStudents();
  document
    .getElementById("creatForm")
    .addEventListener("submit", createStudent);
}

async function createStudent(e) {
  e.preventDefault();

  const formData = new FormData(e.target);
  let firstName = formData.get("firstName");
  let lastName = formData.get("lastName");
  let facultyNumber = formData.get("facultyNumber");
  let grade = formData.get("grade");
  if (firstName == "" || lastName == "" || facultyNumber == "" || grade == "") {
    return alert("All fields should be filled.");
  }
  const student = {
    firstName,
    lastName,
    facultyNumber,
    grade,
  };

  const url = "http://localhost:3030/jsonstore/collections/students";
  await fetch(url, {
    method: "post",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(student),
  });
  e.target.reset();
  getAllStudents();
}
async function getAllStudents() {
  const url = "http://localhost:3030/jsonstore/collections/students";

  const response = await fetch(url);
  const dataStudents = await response.json();
  console.log(dataStudents);
  console.log(Object.values(dataStudents));
  const rows = Object.values(dataStudents).map(createRow).join("");
  document.querySelector("tbody").innerHTML = rows;
}

function createRow(student) {
  const result = `
  <tr>
  <th>${student.firstName}</th>
  <th>${student.lastName}</th>
  <th>${student.facultyNumber}</th>
  <th>${student.grade}</th>
</tr>
  `;
  return result;
}

attachEvents();

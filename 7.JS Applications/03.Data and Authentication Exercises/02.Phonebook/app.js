function attachEvents() {
  document.getElementById("btnCreate").addEventListener("click", createNewPhone);
  document.getElementById("btnLoad").addEventListener("click", refreshPhones);
    document.getElementById('phonebook').addEventListener('click',deletePhoneById)
}
async function deletePhoneById(e){
    if (e.target.tagName == 'BUTTON' && e.target.textContent=='Delete') {
        const url = "http://localhost:3030/jsonstore/phonebook/"+ e.target.parentElement.id;
        const response = await fetch(url, {
            method: 'delete'
        });
        refreshPhones();
    }
}
async function refreshPhones() {
  const phonebook = document.getElementById("phonebook");
  phonebook.textContent='';
  const url = "http://localhost:3030/jsonstore/phonebook";
  const response = await fetch(url);
  const data = await response.json();
  Object.values(data).forEach((el) => {
    const li = document.createElement("li");
    li.textContent = `${el.person}: ${el.phone}`;
    li.id=el._id;
    const deleteButton = document.createElement("button");
    deleteButton.textContent = "Delete";
    li.appendChild(deleteButton);
    phonebook.appendChild(li);
  });
}
async function createNewPhone() {
  let inputPerson = document.getElementById("person");
  let inputPhone = document.getElementById("phone");
  if (inputPerson.value == "" || inputPhone.value == "") {
    return alert("Person and Phone field need to be filled");
  }
  const data = {
    person: inputPerson.value,
    phone: inputPhone.value,
  };
  const url = "http://localhost:3030/jsonstore/phonebook";
  const response = await fetch(url, {
    method: "post",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(data),
  });
  inputPerson.value='';
  inputPhone.value='';
}
attachEvents();

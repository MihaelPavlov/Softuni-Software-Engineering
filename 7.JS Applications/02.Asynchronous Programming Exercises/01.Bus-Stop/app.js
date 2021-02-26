async function getInfo() {
  const input = document.getElementById("stopId");
  const ulElement = document.getElementById("buses");
  const url = "http://localhost:3030/jsonstore/bus/businfo/" + input.value;
  console.log(url);

  const response = await fetch(url);
  ulElement.innerHTML = "";
  try {
    const data = await response.json();
    document.getElementById("stopName").textContent = data.name;

    Object.entries(data.buses).forEach((key) => {
      let numberOfBus = key[0];
      let timeToArrive = key[1];
      let li = document.createElement("li");
      li.textContent = `Bus ${numberOfBus} arrives in ${timeToArrive} minutes`;
      ulElement.appendChild(li);
    });
    input.value='';
  } catch (error) {
    console.log(error.message);
    document.getElementById("stopName").textContent = "Error";
    return;
  }
}

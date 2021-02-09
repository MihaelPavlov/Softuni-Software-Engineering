function addDestination() {
  //Get data
  const inputData = document.getElementsByClassName("inputData");
  const city = inputData[0];
  const country = inputData[1];
  const season = document.getElementById("seasons");

  //Attach the html elements
  const destinations = document.getElementById("destinationsList");

  if (city.value == "" || country.value == "") {
    return;
  }
  //Create new HTML
  const tr = document.createElement("tr");
  const tdCityAndCountry = document.createElement("td");
  const tdSeason = document.createElement("td");
  tdCityAndCountry.textContent = `${city.value}, ${country.value}`;
  tdSeason.textContent =
    season.value[0].toUpperCase() + season.value.slice(1, season.value.length);
  tr.appendChild(tdCityAndCountry);
  tr.appendChild(tdSeason);
  destinations.appendChild(tr);

  //Count the destinations for 2018
  const summer = document.getElementById("summer");
  const autumn = document.getElementById("autumn");
  const winter = document.getElementById("winter");
  const spring = document.getElementById("spring");
  countTheDestinations(season.value);
  function countTheDestinations(season) {
    if (season === "summer") {
      summer.value++;
    } else if (season === "autumn") {
      autumn.value++;
    } else if (season === "winter") {
      winter.value++;
    } else if (season === "spring") {
      spring.value++;
    }
  }

  //Clear the input boxes
  city.value = "";
  country.value = "";
}

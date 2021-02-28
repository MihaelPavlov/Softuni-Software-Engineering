function attachEvents() {
  document.getElementById("submit").addEventListener("click", shotWeather);

  const divCurrentForecats = document.getElementById("current");
  const divUpcomingForecats = document.getElementById("upcoming");

  async function shotWeather() {
    const input = document.getElementById("location");
    console.log(input.value);
    const url = "http://localhost:3030/jsonstore/forecaster/locations";

    const resposne = await fetch(url);
    const data = await resposne.json();
    const result = data.filter((x) => x.name == input.value)[0];
    console.log(result);

    currentCondition(result.code);
    threeDayForecast(result.code);
  }

  async function currentCondition(code) {
    const url = "http://localhost:3030/jsonstore/forecaster/today/" + code;
    const resposne = await fetch(url);
    const data = await resposne.json();
    console.log(data);
    const div = createElement("div", undefined, ["class=forecasts"]);

    const symbolSpan = createElement("span", "\u2600", ["class=condition"]);
    symbolSpan.classList.add("symbol");

    const spanCondition = createElement("span", undefined, ["class=condition"]);

    const spanDataName = createElement("span", data.name, [
      "class=forecast-data",
    ]);

    const spanWeather = createElement(
      "span",
      `${data.forecast.low}\xB0/${data.forecast.high}\xB0`,
      ["class=forecast-data"]
    );

    const spanDataCondition = createElement("span", data.forecast.condition, [
      "class=forecast-data",
    ]);

    divCurrentForecats.parentElement.style.display = "block";
    div.appendChild(symbolSpan);
    spanCondition.appendChild(spanDataName);
    spanCondition.appendChild(spanWeather);
    spanCondition.appendChild(spanDataCondition);
    div.appendChild(spanCondition);
    divCurrentForecats.appendChild(div);
  }

  async function threeDayForecast(code) {
    const url = "http://localhost:3030/jsonstore/forecaster/upcoming/" + code;
    const resposne = await fetch(url);
    const data = await resposne.json();

    const div = createElement("div", undefined, ["class=forecast-info"]);

    data.forecast.forEach((el) => {
        console.log(el);
      const spanCondition = createElement("span", undefined, [
        "class=upcoming",
      ]);

      const spanSymbol = createElement("span", data.name, [
        "class=forecast-data",
      ]);

      const spanWeather = createElement(
        "span",
        `${el.low}\xB0/${el.high}\xB0`,
        ["class=forecast-data"]
      );

      const spanDataCondition = createElement("span", el.condition, [
        "class=forecast-data",
      ]);

      spanCondition.appendChild(spanSymbol);
      spanCondition.appendChild(spanWeather);
      spanCondition.appendChild(spanDataCondition);
      div.appendChild(spanCondition);
    });
    divUpcomingForecats.appendChild(div)
  }

  function createElement(type, text, attributes = []) {
    let element = document.createElement(type);
    if (text) {
      element.textContent = text;
    }
    attributes
      .map((attr) => attr.split("="))
      .forEach(([name, value]) => {
        element.setAttribute(name, value);
      });

    return element;
  }
}

attachEvents();

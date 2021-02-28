function solve() {

    const departBtn = document.getElementById("depart");
    const arriveBtn = document.getElementById("arrive");
    const banner = document.querySelector("#info span");

    let stop = {
        next:'depot'
    }

  async function depart() {
      console.log(stop);
    const url = "http://localhost:3030/jsonstore/bus/schedule/"+stop.next;
    const response = await fetch(url);
    const data = await response.json();
    banner.textContent= `Next stop ${data.name}`
    departBtn.disabled=true;
    arriveBtn.disabled=false;
    stop=data;
    console.log(stop);
  }

  async function arrive() {
      console.log(stop);
      banner.textContent=`Arriving at ${stop.name}`
    departBtn.disabled=false;
    arriveBtn.disabled=true;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();

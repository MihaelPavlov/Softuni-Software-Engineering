function attachEventsListeners() {
  //get all buttons
  const daysBtn = document.getElementById("daysBtn");
  const hoursBtn = document.getElementById("hoursBtn");
  const minutesBtn = document.getElementById("minutesBtn");
  const secondsBtn = document.getElementById("secondsBtn");
  // add event listener to all buttons

  daysBtn.addEventListener("click", clickTimeConverter);
  hoursBtn.addEventListener("click", clickTimeConverter);
  minutesBtn.addEventListener("click", clickTimeConverter);
  secondsBtn.addEventListener("click", clickTimeConverter);
  // read button when is cleacked

  function clickTimeConverter(event) {
    const inputValue = event.target.parentNode.getElementsByTagName("input")[0]
      .value;

    const inputTime = event.target.parentNode.getElementsByTagName("input")[0];

    let arrResult = [];

    console.log(event.target.parentNode.getElementsByTagName("input")[0]);
  }
  //conver the value to other three time units
}

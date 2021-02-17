function solution() {
  const divContainer = document.getElementsByClassName("container")[0];
  const sections = document.querySelectorAll(".card");
  divContainer.addEventListener("click", checkForButtons);
  let state = [];
  function checkForButtons(e) {
    if (e.target.tagName === "BUTTON") {
      if (e.target.textContent === "Add gift") {
        createGift();
      } else if (e.target.textContent === "Send") {
        sendGift(e);
      } else if (e.target.textContent === "Discard") {
        discardGift(e);
      }
    }
  }

  function createGift(e) {
    const addGiftInput = sections[0].lastElementChild.firstElementChild;
    const listOfGiftsContainer = sections[1].lastElementChild;

    if (addGiftInput == "") {
      return;
    } else {
      const li = document.createElement("li");
      li.classList.add("gift");
      li.textContent = addGiftInput.value;
      const sendButton = document.createElement("button");
      sendButton.id = "sendButton";
      sendButton.textContent = "Send";
      const discardButton = document.createElement("button");
      discardButton.id = "discardButton";
      discardButton.innerHTML = "Discard";
      li.appendChild(sendButton);
      li.appendChild(discardButton);
      state.push({ key: addGiftInput.value, value: li });
      state
        .sort((a, b) => a.key.localeCompare(b.key))
        .forEach((li) => {
          listOfGiftsContainer.appendChild(li.value);
        });
    }

    addGiftInput.value = "";
  }

  function sendGift(e) {
    const sentGifts = sections[2].lastElementChild;
    const giftName = e.target.parentElement.textContent.split("SendDiscard")[0];
    e.target.parentElement.remove();
    const li = document.createElement("li");
    li.textContent = giftName;
    li.classList.add("gift");
    sentGifts.appendChild(li);
    let index = state.findIndex((x) => x.key === giftName);
    state.splice(index, 1);
  }

  function discardGift(e) {
    const discradGifts = sections[3].lastElementChild;
    const giftName = e.target.parentElement.textContent.split("SendDiscard")[0];
    e.target.parentElement.remove();
    const li = document.createElement("li");
    li.classList.add("gift");
    li.textContent = giftName;
    discradGifts.appendChild(li);
    let index = state.findIndex((x) => x.key === giftName);
    state.splice(index, 1);
  }
}

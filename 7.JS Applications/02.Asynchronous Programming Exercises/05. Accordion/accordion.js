async function solution() {
  const url = "http://localhost:3030/jsonstore/advanced/articles/list";

  const response = await fetch(url);
  const data = await response.json();


  for (const [key, value] of Object.entries(data)) {
    const divAccardion = e("div", undefined, ["class=accordion"]);
    const divHead = e("div", undefined, ["class=head"]);
    const span = e("span", value.title);
    const button = e("button", "More", ["class=button"]);
    button.id = value._id;
    const divExtra = e("div", undefined, ["class=extra"]);
    let text = await getMoreData(value._id);
    const p = e("p",text );

    divHead.appendChild(span);
    divHead.appendChild(button);
    divExtra.appendChild(p);
    divAccardion.appendChild(divHead);
    divAccardion.appendChild(divExtra);
    document.getElementById("main").appendChild(divAccardion)
  }
  document.getElementById("main").addEventListener("click", function (e) {
     
    if (e.target.tagName ==('BUTTON') && e.target.parentElement.parentElement.lastChild.style.display =='none') {
        e.target.parentElement.parentElement.lastChild.style.display='block'
     
    }
    else{
        e.target.parentElement.parentElement.lastChild.style.display='none'
    }
  });

  async function getMoreData(id) {
    const url2 =
      "http://localhost:3030/jsonstore/advanced/articles/details/" + id;
    const response = await fetch(url2);
    console.log(response);
    const data = await response.json();
   
    return data.content;
  }
  function e(type, text, attributes = []) {
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

function solve() {
  // get products divs

  const result = [];
  const products = document.getElementsByClassName("add-product");
  const textArea = document.querySelector("textarea");

  //add eventListiner to button add
  const resultName = [];
  let resultPrice = 0;

  for (let i = 0; i < products.length; i++) {
    products[i].addEventListener("click", function (e) {
      const div = e.target.parentElement.parentElement;
      const productName = div.children[1].children[0].textContent;

      const productPrice = div.children[3].textContent;

      let isContains = false;
      for (let i = 0; i < result.length; i++) {
        if (result[i].name == productName) {
          isContains = true;
          result[i].counter++;
          textArea.textContent += `Added ${productName} for ${result[
            i
          ].productPrice.toFixed(2)} to the cart.\n`;
          resultPrice += Number(result[i].productPrice);
          break;
        }
      }
      let product = {};
      if (!isContains) {
        product["name"] = productName;
        product["productPrice"] = Number(productPrice);
        product["counter"] = 1;
        result.push(product);
        textArea.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;
        resultPrice += Number(productPrice);

        resultName.push(productName);
      }
    });
  }

  const checkOut = document.getElementsByClassName("checkout")[0];
  checkOut.addEventListener("click", function (e) {
    textArea.textContent += `You bought ${resultName.join(
      ", "
    )} for ${resultPrice.toFixed(2)}.`;
    for (let i = 0; i < products.length; i++) {
      products[i].disabled = true;
    }
    checkOut.disabled = true;
  });

  // get textArea
  //print the input in textArea // Added {name} for {money:toFixed(2)} to the cart.\n
  //get checkout button
  //add event listiner click
  //when is clicked calculate the total money
  //print the input in the textArea //You bought {list} for {totalPrice}."
  //after add product disabled button , and in the end after checkout disable the chekout button
}

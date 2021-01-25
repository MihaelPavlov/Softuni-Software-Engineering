function search() {
  const lis = document.getElementById("towns").getElementsByTagName("li");

  const match = document.getElementById("searchText").value;
  const result = document.getElementById("result");
  let counter = 0;
  for (let index = 0; index < lis.length; index++) {
    if (lis[index].textContent.includes(match)) {
      lis[index].style.textDecoration = "underline";
      lis[index].style.fontWeight = "bold";
      counter++;
    } else {
      lis[index].style.textDecoration = "";
      lis[index].style.fontWeight = "";
    }
  }

  result.textContent = counter + " matches found";
}

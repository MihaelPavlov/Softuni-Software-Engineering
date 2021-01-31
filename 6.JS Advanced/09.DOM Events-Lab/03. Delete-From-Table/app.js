function deleteByEmail() {
  const text = document.getElementsByName("email")[0].value;
  console.log(text[0].value);
  const tbody = document.querySelectorAll("#customers tr td:nth-child(2)");

  for (const td of tbody) {
    console.log(td.textContent);
    if (td.textContent == text) {
      let row = td.parentNode;
      console.log(row.parentNode.removeChild(row));
    }
  }
}

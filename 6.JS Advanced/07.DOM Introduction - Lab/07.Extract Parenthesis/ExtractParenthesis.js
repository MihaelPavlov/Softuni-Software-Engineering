function extract(content) {
  const text = document.getElementById(content).textContent;

  const regex = /\((.+?)\)/gm;

  let result = [];

  let match = regex.exec(text);

  while (match != null) {
    console.log(match[1]);
    result.push(match[1]);
    match = regex.exec(text);
  }

  return result.join("; ");
}

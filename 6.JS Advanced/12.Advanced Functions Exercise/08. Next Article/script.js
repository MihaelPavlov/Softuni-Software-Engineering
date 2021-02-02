function getArticleGenerator(articles) {
  let stringArray = [];

  return function showNext() {
    const content = document.getElementById("content");

    const article = document.createElement("article");
    article.className += "article";
    for (let i = stringArray.length; i < articles.length; i++) {
      stringArray.push(articles[i]);
      article.textContent = stringArray[i];
      content.appendChild(article);
      break;
    }
  };
}

class Story {
  constructor(title, creator) {
    this.title = title;
    this.creator = creator;
    this._comments = [];
    this._likes = [];
  }

  get likes() {
    if (this._likes.length == 0) {
      return `${this.title} has 0 likes`;
    } else if (this._likes.length == 1) {
      return `${this._likes[0]} likes this story!`;
    } else {
      return `${this._likes[0]} and ${
        this._likes.length - 1
      } others like this story!`;
    }
  }
  like(username) {
    if (this._likes.includes(username)) {
      throw new Error(`You can't like the same story twice!`);
    }
    if (username == this.creator) {
      throw new Error(`You can't like your own story!`);
    }
    this._likes.push(username);
    return `${username} liked ${this.title}!`;
  }
  dislike(username) {
    if (!this._likes.includes(username)) {
      throw new Error(`You can't dislike this story!`);
    }
    let indexToRemove = this._likes.indexOf(username);
    this._likes.splice(indexToRemove, 1);
    return `${username} disliked ${this.title}`;
  }
  comment(username, content, id) {
    if (id == undefined || !this._comments.some((x) => x.Id == id)) {
      let comment = {
        Id: this._comments.length + 1,
        Username: username,
        Content: content,
        Replies: [],
      };
      this._comments.push(comment);
      return `${username} commented on ${this.title}`;
    }

    if (this._comments.some((x) => x.Id == id)) {
      let takeComment = this._comments.filter((x) => x.Id == id)[0];
      let reply = {
        Id: `${takeComment.Id}.${takeComment.Replies.length + 1}`,
        Username: username,
        Content: content,
      };
      takeComment.Replies.push(reply);
      return `You replied successfully`;
    }
  }

  toString(sortingType) {
    if (sortingType == "asc") {
      this._comments.forEach((el) => {
        el.Replies.sort((a, b) => a.Id - b.Id);
      });
      this._comments.sort((a, b) => a.Id - b.Id);

    }
    else if (sortingType == "desc") {
      this._comments.forEach((el) => {
        el.Replies.sort((a, b) => b.Id - a.Id);
      });
      this._comments.sort((a, b) => b.Id - a.Id);

    }
     else if (sortingType == "username") {
      this._comments.forEach((el) => {
        el.Replies.sort((a, b) => a.Username.localeCompare(b.Username));
      });

      this._comments.sort((a, b) => a.Username.localeCompare(b.Username));
    }
    let result = [];
    result.push(`Title: ${this.title}`);
    result.push(`Creator: ${this.creator}`);
    result.push(`Likes: ${this._likes.length}`);
    result.push(`Comments:`);

    this._comments.forEach((el) => {
      result.push(`-- ${el.Id}. ${el.Username}: ${el.Content}`);
      if (el.Replies.length > 0) {
        el.Replies.forEach((el2) => {
          result.push(`--- ${el2.Id}. ${el2.Username}: ${el2.Content}`);
        });
      }
    });
    return result.join("\n");
  }
}
let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));

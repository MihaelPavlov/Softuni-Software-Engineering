const describe = require("mocha").describe;
const assert = require("chai").assert;
class ChristmasMovies {
  constructor() {
    this.movieCollection = [];
    this.watched = {};
    this.actors = [];
  }

  buyMovie(movieName, actors) {
    let movie = this.movieCollection.find((m) => movieName === m.name);
    let uniqueActors = new Set(actors);

    if (movie === undefined) {
      this.movieCollection.push({ name: movieName, actors: [...uniqueActors] });
      let output = [];
      [...uniqueActors].map((actor) => output.push(actor));
      return `You just got ${movieName} to your collection in which ${output.join(
        ", "
      )} are taking part!`;
    } else {
      throw new Error(`You already own ${movieName} in your collection!`);
    }
  }

  discardMovie(movieName) {
    let filtered = this.movieCollection.filter((x) => x.name === movieName);

    if (filtered.length === 0) {
      throw new Error(`${movieName} is not at your collection!`);
    }
    let index = this.movieCollection.findIndex((m) => m.name === movieName);
    this.movieCollection.splice(index, 1);
    let { name, _ } = filtered[0];
    if (this.watched.hasOwnProperty(name)) {
      delete this.watched[name];
      return `You just threw away ${name}!`;
    } else {
      throw new Error(`${movieName} is not watched!`);
    }
  }

  watchMovie(movieName) {
    let movie = this.movieCollection.find((m) => movieName === m.name);
    if (movie) {
      if (!this.watched.hasOwnProperty(movie.name)) {
        this.watched[movie.name] = 1;
      } else {
        this.watched[movie.name]++;
      }
    } else {
      throw new Error("No such movie in your collection!");
    }
  }

  favouriteMovie() {
    let favourite = Object.entries(this.watched).sort((a, b) => b[1] - a[1]);
    if (favourite.length > 0) {
      return `Your favourite movie is ${favourite[0][0]} and you have watched it ${favourite[0][1]} times!`;
    } else {
      throw new Error("You have not watched a movie yet this year!");
    }
  }

  mostStarredActor() {
    let mostStarred = {};
    if (this.movieCollection.length > 0) {
      this.movieCollection.forEach((el) => {
        let { _, actors } = el;
        actors.forEach((actor) => {
          if (mostStarred.hasOwnProperty(actor)) {
            mostStarred[actor]++;
          } else {
            mostStarred[actor] = 1;
          }
        });
      });
      let theActor = Object.entries(mostStarred).sort((a, b) => b[1] - a[1]);
      return `The most starred actor is ${theActor[0][0]} and starred in ${theActor[0][1]} movies!`;
    } else {
      throw new Error("You have not watched a movie yet this year!");
    }
  }
}

describe("Christmas movies", function () {
  describe("Test the class constructor is instantiation right", function () {
    it("Test instantiation", function () {
      let christmas = new ChristmasMovies();

      assert.property(christmas, "actors");
      assert.property(christmas, "watched");
      assert.property(christmas, "movieCollection");
      assert.isArray(christmas.actors);
      assert.isArray(christmas.movieCollection);
      assert.isObject(christmas.watched);
    });
  });
  describe("Test buyMovie function", function () {
    it("Test is Function", function () {
      let christmas = new ChristmasMovies();

      assert.isFunction(christmas.buyMovie);
    });
    it("Test Must throw exception if we try add movie that already have been added", function () {
      let christmas = new ChristmasMovies();

      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      assert.throws(() =>
        christmas.buyMovie("Home Alone", [
          "Macaulay Culkin",
          "Joe Pesci",
          "Daniel Stern",
        ])
      );
    });
    it("Test is right push the new movie", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      christmas.buyMovie("Home", ["Macaulay Culkin", "Joe Pesci"]);

      assert.equal(christmas.movieCollection[0].name, "Home Alone");
      assert.equal(
        christmas.movieCollection[0].actors.join(" "),
        "Macaulay Culkin Joe Pesci Daniel Stern"
      );
      assert.equal(christmas.movieCollection.length, 2);
      assert.equal(christmas.movieCollection[0].actors.length, 3);
      assert.equal(christmas.movieCollection[1].actors.length, 2);
    });
    it("Test if the actors are not unique", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home", ["Joe Pesci", "Joe Pesci", "Daniel Stern"]);

      assert.equal(christmas.movieCollection[0].actors.length, 2);
    });
  });
  describe("Test discardMovie function", function () {
    it("Test is Function", function () {
      let christmas = new ChristmasMovies();
      assert.isFunction(christmas.discardMovie);
    });
    it("Test is movie doesn't contains should throw error", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      assert.throw(() => christmas.discardMovie("Home"));
    });
    it("Test is movie discard should throw exceptio becouse movie is not watched", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      christmas.buyMovie("Home", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      assert.equal(christmas.movieCollection.length, 2);
      assert.throw(() => christmas.discardMovie("Home"));
      assert.equal(christmas.movieCollection.length, 1);
    });
    it("Test is movie and watches discard right", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      christmas.buyMovie("Home", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      christmas.watchMovie("Home");
      assert.equal(Object.keys(christmas.watched).length, 1);
      assert.equal(christmas.movieCollection.length, 2);
      christmas.discardMovie("Home");
      assert.equal(christmas.movieCollection.length, 1);
      assert.equal(Object.keys(christmas.watched).length, 0);
    });
  });
  describe("Test watchMovie function", function () {
    it("Test is watchMovie a Function", function () {
      let christmas = new ChristmasMovies();
      assert.isFunction(christmas.watchMovie);
    });
    it("Test if movie doesn't exist should throw error", function () {
      let christmas = new ChristmasMovies();

      assert.throw(() => christmas.watchMovie("home"));
    });
    it("Test if movie exist should create property in watched", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      assert.notProperty(christmas.watched, "Home Alone");
      assert.equal(Object.keys(christmas.watched).length, 0);
      christmas.watchMovie("Home Alone");
      assert.property(christmas.watched, "Home Alone");
      assert.equal(Object.keys(christmas.watched).length, 1);
      assert.equal(christmas.watched["Home Alone"], 1);
      christmas.watchMovie("Home Alone");
      assert.equal(Object.keys(christmas.watched).length, 1);
      assert.equal(christmas.watched["Home Alone"], 2);
    });
  });
  describe("Test favourireMoview function", function () {
    it("Test is Function", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      assert.isFunction(christmas.favouriteMovie);
    });
    it("Test if watched movies are zero should throw error", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      assert.throw(() => christmas.favouriteMovie());
    });
    it("Test if have watched movies should return message", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      christmas.watchMovie("Home Alone");
      let result = christmas.favouriteMovie();
      assert.equal(
        result,
        "Your favourite movie is Home Alone and you have watched it 1 times!"
      );
      christmas.watchMovie("Home Alone");
      christmas.watchMovie("Home Alone");
      assert.equal(
        christmas.favouriteMovie(),
        "Your favourite movie is Home Alone and you have watched it 3 times!"
      );
    });
  });
  describe("Test is mostStarredActors function", function () {
    it("Test is Function", function () {
      let christmas = new ChristmasMovies();

      assert.isFunction(christmas.mostStarredActor);
    });
    it("Test should throw erro", function () {
      let christmas = new ChristmasMovies();

      assert.throw(() => christmas.mostStarredActor());
    });
    it("Test should throw erro", function () {
      let christmas = new ChristmasMovies();
      christmas.buyMovie("Home Alone", [
        "Macaulay Culkin",
        "Joe Pesci",
        "Daniel Stern",
      ]);
      assert.equal(
        christmas.mostStarredActor(),
        "The most starred actor is Macaulay Culkin and starred in 1 movies!"
      );
      christmas.buyMovie("Alone", ["Macaulay Culkin"]);
      christmas.buyMovie("Home", ["Macaulay Culkin"]);
      assert.equal(
        christmas.mostStarredActor(),
        "The most starred actor is Macaulay Culkin and starred in 3 movies!"
      );
    });
  });
});

// let christmas = new ChristmasMovies();
// christmas.buyMovie("Home Alone", [
//   "Macaulay Culkin",
//   "Joe Pesci",
//   "Daniel Stern",
// ]);
// christmas.buyMovie("Home Alone 2", ["Macaulay Culkin"]);
// christmas.buyMovie("Last Christmas", ["Emilia Clarke", "Henry Golding"]);
// christmas.buyMovie("The Grinch", ["Benedict Cumberbatch", "Pharrell Williams"]);
// christmas.watchMovie("Home Alone");
// christmas.watchMovie("Home Alone");
// christmas.watchMovie("Home Alone");
// christmas.watchMovie("Home Alone 2");
// christmas.watchMovie("The Grinch");
// christmas.watchMovie("Last Christmas");
// christmas.watchMovie("Home Alone 2");
// christmas.watchMovie("Last Christmas");
// christmas.discardMovie("The Grinch");
// christmas.favouriteMovie();
// christmas.mostStarredActor();

//module.exports = ChristmasMovies;

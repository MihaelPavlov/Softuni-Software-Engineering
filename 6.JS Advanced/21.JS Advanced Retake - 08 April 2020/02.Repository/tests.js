const { assert } = require("chai");
let { Repository } = require("./solution.js");

let properties = {
  name: "string",
  age: "number",
  birthday: "object",
};
let current = new Repository(properties);

describe("Tests …", function () {
  describe("Update method", () => {
    it("Should throw error if id is wrong", () => {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let current = new Repository(properties);

      assert.throw(
        () => current.update(0),
        "Entity with id: 0 does not exist!"
      );
      assert.throw(
        () => current.update(-1),
        "Entity with id: -1 does not exist!"
      );
    });

    it("Should update the entity", () => {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let current = new Repository(properties);

      const entity = { name: "Pesho", age: 22, birthday: new Date(1998, 0, 7) };
      current.add(entity);
      const newEntity = {
        name: "Gosho",
        age: 22,
        birthday: new Date(1998, 0, 7),
      };
      current.update(0, newEntity);
      assert.deepEqual(current.getId(0), newEntity);
      assert.deepEqual(current.data.get(0), newEntity);
    });

    it("Should throw error if new entity is not valid", () => {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let current = new Repository(properties);

      const entity = { name: "Pesho", age: 22, birthday: new Date(1998, 0, 7) };
      current.add(entity);
      const entity2 = { name: 11, age: 22, birthday: new Date(1998, 0, 7) };
      assert.throw(
        () => current.update(1, entity2),
        "Entity with id: 1 does not exist!"
      );
      assert.throw(
        () => current.update(0, entity2),
        "Property name is not of correct type!"
      );
      delete entity2.name;
      entity2.name1 = "Gosho";
      assert.throw(
        () => current.update(0, entity2),
        "Property name is missing from the entity!"
      );
      assert.throw(
        () => current.update(0, entity2),
        "Property name is missing from the entity!"
      );
    });
  });

  describe("instantiate right", function () {
    it("is instantiate right", function () {
      let properties = {};
      let repository = new Repository(properties);

      assert.equal(repository.constructor.name, "Repository");
      let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7),
      };

      assert.throw(() => repository._validate(entity));

      let repository2 = new Repository();
      assert.equal(repository2.count, 0);
      assert.throw(() => repository2.add(entity));
      assert.throw(() => repository2.del(1));
      assert.throw(() => repository2.update(1, entity));
    });
  });
  describe("Constructor test", () => {
    it("Should have all props", () => {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let current = new Repository(properties);
      assert.equal(current.props.hasOwnProperty("name"), true);
      assert.equal(current.props.hasOwnProperty("age"), true);
      assert.equal(current.props.hasOwnProperty("birthday"), true);
      assert.equal(typeof current.nextId, "function");
      assert.typeOf(current.props, "object");
    });

    it("It should have empty map", () => {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let current = new Repository(properties);
      assert.equal(current.data instanceof Map, true);
      assert.equal(current.data.size, 0);
    });
  });
  describe("Test Get Count", function () {
    it("Test Count Should return 3", function () {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let repository = new Repository(properties);

      let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7),
      };

      assert.equal(repository.count, 0);
      repository.add(entity);
      repository.add(entity);
      repository.add(entity);
      assert.equal(repository.count, 3);
    });
  });
  describe("Test Add Function", function () {
    it("Test Add", function () {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let repository = new Repository(properties);

      let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7),
      };

      let entity2 = {
        name: "Misho",
        age: 12,
        birthday: new Date(1998, 2, 7),
      };
      repository.add(entity);
      repository.add(entity2);

      let getEntity = repository.getId(0);
      let getEntity2 = repository.getId(1);
      assert.equal(repository.count, 2);
      assert.equal(getEntity.name, "Pesho");
      assert.equal(getEntity2.age, 12);
      let date = getEntity2.birthday;
      assert.equal(getEntity2.birthday, date);

      let entity3 = {
        name: 22,
        age: 12,
        birthday: new Date(1998, 0, 7),
      };
      assert.throw(() => repository.add(entity3));
      let entity4 = {
        name: "Pesho22",
        age: 12,
        birthday: 2,
      };
      assert.throw(() => repository.add(entity4));
      let anotherEntity = {
        name1: "Stamat",
        age: 29,
        birthday: new Date(1991, 0, 21),
      };
      assert.throw(() => repository.add(anotherEntity));

      anotherEntity = {
        name: "Stamat",
        age: 29,
        birthday: 1991,
      };
      assert.throw(() => repository.add(anotherEntity));

      let lastEntity = {
        name: "Stamat",
        age: 29,
        birthday: new Date(1991, 0, 21),
      };
      let id = repository.add(lastEntity);
      assert.equal(id, 2);
    });
  });
  describe("Test GetId Function", function () {
    it("Test GetId Should Throw Exception", function () {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let repository = new Repository(properties);

      let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7),
      };

      let entity2 = {
        name: "Misho",
        age: 12,
        birthday: new Date(1998, 0, 7),
      };
      repository.add(entity);
      repository.add(entity2);

      assert.throw(() => repository.getId(100));
      assert.throw(() => repository.getId(-1));
    });
  });
  describe("Test Update Function", function () {
    it("Test Update", function () {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let repository = new Repository(properties);

      let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7),
      };

      let entity2 = {
        name: "Misho",
        age: 12,
        birthday: new Date(1998, 0, 7),
      };
      repository.add(entity);
      let ent = repository.getId(0);
      assert.equal(ent.name, "Pesho");
      assert.equal(ent.age, 22);
      repository.update(0, entity2);
      let ent2 = repository.getId(0);
      assert.equal(ent2.name, "Misho");
      assert.equal(ent2.age, 12);

      assert.throw(() => repository.update(100, ent));
      assert.throw(() => repository.update(-2, ent));
      let entity3 = {
        name: 22,
        age: 12,
        birthday: new Date(1998, 0, 7),
      };
      assert.throw(() => repository.add(entity3));
    });
  });
  describe("Test Del Function", function () {
    it("Test Del", function () {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let repository = new Repository(properties);

      let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7),
      };

      let entity2 = {
        name: "Misho",
        age: 12,
        birthday: new Date(1998, 0, 7),
      };
      assert.throw(() => repository.del(1));
      repository.add(entity);
      repository.add(entity2);
      repository.del(1);
      assert.equal(repository.count, 1);
      assert.throw(() => repository.del(100));
      assert.throw(() => repository.del(-1));
    });
  });
  describe("Test Validate Function", function () {
    it("Test Validate", function () {
      let properties = {
        name: "string",
        age: "number",
        birthday: "object",
      };
      let repository = new Repository(properties);

      let entity = {
        name: 22,
        age: 22,
        birthday: new Date(1998, 0, 7),
      };

      let entity2 = {
        name: "Misho",
        age: 12,
      };
      let entity3 = {
        name: 22,
        age: "da",
      };
      let entity4 = {};
      assert.throw(() => repository._validate(entity));
      assert.throw(() => repository._validate(entity2));
      assert.throw(() => repository._validate(entity3));
      assert.throw(() => repository._validate(entity4));
    });
  });
});

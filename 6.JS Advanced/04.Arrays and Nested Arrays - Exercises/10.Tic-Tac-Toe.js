function ticTacToe(input) {
  let dashboard = [
    [false, false, false],
    [false, false, false],
    [false, false, false],
  ];

  let win = false;
  let player = "X";
  for (let i = 0; i < input.length; i++) {
    let [row, col] = input[i].split(" ").map((num) => Number(num));
    if (isAllPlacePlayed(dashboard)) {
      break;
    }
    if (!dashboard[row][col]) {
      dashboard[row][col] = player;

      if (checkForWinner(dashboard, player)) {
        win = true;
        break;
      }

      player = player === "X" ? "O" : "X";
    } else {
      console.log("This place is already taken. Please choose another!");
    }
  }

  if (win) {
    console.log(`Player ${player} wins!`);
  } else {
    console.log("The game ended! Nobody wins :(");
  }
  dashboard.forEach((line) => {
    console.log(line.join("\t"));
  });

  function checkForWinner(currentBoard, sign) {
    let isWinner = false;
    for (let i = 0; i < 3; i++) {
      if (
        currentBoard[i][0] === sign &&
        currentBoard[i][1] === sign &&
        currentBoard[i][2] === sign
      ) {
        isWinner = true;
        break;
      }
      if (
        currentBoard[0][i] === sign &&
        currentBoard[1][i] === sign &&
        currentBoard[2][i] === sign
      ) {
        isWinner = true;
        break;
      }
    }
    if (!isWinner) {
      if (
        (currentBoard[0][0] === sign &&
          currentBoard[1][1] === sign &&
          currentBoard[2][2] === sign) ||
        (currentBoard[2][0] === sign &&
          currentBoard[1][1] === sign &&
          currentBoard[0][2] === sign)
      ) {
        isWinner = true;
      }
    }
    return isWinner;
  }

  function isAllPlacePlayed(board) {
    for (let row = 0; row < board.length; row++) {
      for (let col = 0; col < board[row].length; col++) {
        if (board[row][col] === false) {
          return false;
        }
      }
    }
    return true;
  }
}
function solve(matrix) {
  let board = [
    [false, false, false],
    [false, false, false],
    [false, false, false],
  ];

  let countOfDoneTunrs = 1;
  while (matrix.length != 0) {
    let isWinner = isThereAWinner(board);
    if (isWinner[0] === "X") {
      console.log("Player X wins!");
      return printBoard(board);
    } else if (isWinner[0] === "O") {
      console.log("Player O wins!");
      return printBoard(board);
    } else if (isAllPlacePlayed(board) == true) {
      console.log("The game ended! Nobody wins :(");
      return printBoard(board);
    }
    if (countOfDoneTunrs % 2 == 0) {
      let turn = matrix.shift().split(" ");
      let row = Number(turn[0]);
      let col = Number(turn[1]);
      if (checkIsTheSpotClean(board, row, col)) {
        board[row][col] = "O";
        countOfDoneTunrs++;
        continue;
      } else {
        console.log("This place is already taken. Please choose another!");
        continue;
      }
    } else {
      let turn = matrix.shift().split(" ");
      let row = Number(turn[0]);
      let col = Number(turn[1]);
      if (checkIsTheSpotClean(board, row, col)) {
        board[row][col] = "X";
        countOfDoneTunrs++;
        continue;
      } else {
        console.log("This place is already taken. Please choose another!");
        continue;
      }
    }

    countOfDoneTunrs++;
  }
  console.log("The game ended! Nobody wins :(");
  return printBoard(board);

  function isAllPlacePlayed(board) {
    for (let row = 0; row < board.length; row++) {
      for (let col = 0; col < board[row].length; col++) {
        if (board[row][col] === false) {
          return false;
        }
      }
    }
    return true;
  }
  function printBoard(matrix) {
    let result = "";
    for (let row = 0; row < matrix.length; row++) {
      for (let col = 0; col < matrix[row].length; col++) {
        result += matrix[row][col] + "\t";
      }
      result += "\n";
    }

    return result;
  }
  function checkIsTheSpotClean(board, row, col) {
    let play = false;
    if (board[row][col] === false) {
      return (play = true);
    }
    return play;
  }
  function isThereAWinner(board) {
    let firstRow = [0, 1, 2];
    let winner = [];
    if (board[0][0] === "X" && board[0][1] === "X" && board[0][2] === "X") {
      winner[0] = "X";
    } else if (
      board[1][0] === "X" &&
      board[1][1] === "X" &&
      board[1][2] === "X"
    ) {
      winner[0] = "X";
    } else if (
      board[2][0] === "X" &&
      board[2][1] === "X" &&
      board[2][2] === "X"
    ) {
      winner[0] = "X";
    } else if (
      board[0][0] === "X" &&
      board[1][1] === "X" &&
      board[2][2] === "X"
    ) {
      winner[0] = "X";
    } else if (
      board[0][2] === "X" &&
      board[1][1] === "X" &&
      board[2][0] === "X"
    ) {
      winner[0] = "X";
    }

    if (board[0][0] === "O" && board[0][1] === "0" && board[0][2] === "O") {
      winner[0] = "O";
    } else if (
      board[1][0] === "O" &&
      board[1][1] === "O" &&
      board[1][2] === "O"
    ) {
      winner[0] = "O";
    } else if (
      board[2][0] === "O" &&
      board[2][1] === "O" &&
      board[2][2] === "O"
    ) {
      winner[0] = "O";
    } else if (
      board[0][0] === "O" &&
      board[1][1] === "O" &&
      board[2][2] === "O"
    ) {
      winner[0] = "O";
    } else if (
      board[0][2] === "O" &&
      board[1][1] === "O" &&
      board[2][0] === "O"
    ) {
      winner[0] = "O";
    }
    return winner;
  }
}

console.log(
  ticTacToe([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0",
  ])
);
console.log(
  ticTacToe([
    "0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1",
  ])
);

console.log(
  ticTacToe([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0",
  ])
);

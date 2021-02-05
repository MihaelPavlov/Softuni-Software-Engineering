function validate() {
  const submit = document.getElementById("submit");

  const isCompany = document.getElementById("company");

  let isAllValidate = true;
  submit.addEventListener("click", validateStats);
  isCompany.addEventListener("click", companyInfoVisible);
  function companyInfoVisible() {
    const companyInfo = document.getElementById("companyInfo");
    if (isCompany.checked) {
      companyInfo.style.display = "block";
    } else {
      companyInfo.style.display = "none";
    }
  }
  function validateStats(e) {
    e.preventDefault();
    const username = document.getElementById("username");
    const password = document.getElementById("password");
    const confirmPassword = document.getElementById("confirm-password");
    const email = document.getElementById("email");

    const companyNumber = document.getElementById("companyNumber");

    if (/^[A-Za-z0-9]{3,20}$/gm.test(username.value)) {
      username.style.borderColor = "none";
    } else {
      isAllValidate = false;
      username.style.borderColor = "red";
    }

    if (/^[A-Za-z0-9_]{5,15}$/gm.test(password.value)) {
      password.style.borderColor = "none";
    } else {
      isAllValidate = false;
      password.style.borderColor = "red";
    }
    if (password.value === confirmPassword.value) {
      confirmPassword.style.borderColor = "none";
    } else {
      isAllValidate = false;
      confirmPassword.style.borderColor = "red";
      password.style.borderColor = "red";
    }
    if (/^([\w\-.]+)@([a-z]+)(\.[a-z]+)+$/gm.test(email.value)) {
      email.style.borderColor = "none";
    } else {
      isAllValidate = false;
      email.style.borderColor = "red";
    }
    if (isCompany.checked) {
      console.log("ready");
      if (companyNumber.value > 1000 && companyNumber.value < 9999) {
        companyNumber.style.borderColor = "none";
      } else {
        isAllValidate = false;
        companyNumber.style.borderColor = "red";
      }
    }
    const isValid = document.getElementById("valid");
    if (isAllValidate) {
      isValid.style.display = "block";
    }
  }
}

function validate() {
  const username = document.getElementById("username");
  const email = document.getElementById("email");
  const password = document.getElementById("password");
  const confirmPassword = document.getElementById("confirm-password");
  const company = document.getElementById("company");
  const submit = document.getElementById("submit");
  const companyInfo = document.getElementById("companyInfo");
  const companyNumber = document.getElementById("companyNumber");
  const valid = document.getElementById("valid");

  company.addEventListener("change", companyInput);
  function companyInput() {
    company.checked
      ? (companyInfo.style.display = "block")
      : (companyInfo.style.display = "none");
  }

  submit.addEventListener("click", validateInputs);
  function validateInputs(event) {
    event.preventDefault();
    let isValid = true;
    const usernameValidator = /^[A-Za-z0-9]{3,20}$/;
    const passwordValidator = new RegExp(
      `^\w{5,15}$|^${confirmPassword.value}$`
    );
    const emailValidator = /^.*@.*\..*$/;
    const confirmPasswordValidator = new RegExp(`^${password.value}$`);
    const companyValidator = /^[1-9][0-9][0-9][0-9]$/;

    testInput(username, usernameValidator);
    testInput(password, passwordValidator);
    testInput(email, emailValidator);
    testInput(confirmPassword, confirmPasswordValidator);
    if (company.checked) {
      testInput(companyNumber, companyValidator);
      console.log(companyNumber.value);
    }
    if (isValid) {
      valid.style.display = "block";
    } else {
      valid.style.display = "none";
    }
    function testInput(input, validator) {
      if (!validator.test(input.value) || input.value == "") {
        isValid = false;
        input.style.borderColor = "red";
      } else {
        input.style.borderColor = "";
      }
    }
  }
}

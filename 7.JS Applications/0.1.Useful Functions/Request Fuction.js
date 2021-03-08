async function crud(url, options) {
    const response = await fetch(url, options);
    if (response.ok != true) {
        let error= await response.json();
        alert(error.message);
        return;
    }
    const result = await response.json();
    return result;
}

//Example
//Get Request
let data = await crud('http://localhost:3030/data/catches');

//Post Request
const answer = await crud('http://localhost:3030/users/register', {
  method: 'post',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ email, password })
})
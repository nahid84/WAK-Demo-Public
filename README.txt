fetch('http://localhost:8085/api/webapp', {
  method: 'GET',
  headers: {
    'Content-type': 'application/json; charset=UTF-8'
  }
}).then(res => res.json())
  .then(console.log)


fetch('http://localhost:8085/api/webapp', {
  method: 'POST',
  body: JSON.stringify({ name: 'Junaid' }),
  headers: {
    'Content-type': 'application/json; charset=UTF-8'
  }
}).then(res => res.json())
  .then(console.log)



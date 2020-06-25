axios
    .get("/api/v1/book")
    .then(d => console.log(d.data));
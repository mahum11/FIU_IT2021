/*************Things we try to import*****************/ 
const express = require('express');
const bcrypt = require("bcrypt"); // for hashing(provide extra protection to pw) password
// const session = require('express-session');
// MongoDBSession is for passing the session above to the database.
// const MongoDBSession = require("connect-mongodb-session")(session);
// const mongoose = require("mongoose");
// const UserModel = require("./models/userModel");
const passport = require("passport");
const initializePassport = require("./passport-config");

/**************************************************** */

const app = express(); // For initializing node(web) server.
// const mongoURI = "mongodb://localhost:27017/sessions"; // Our database URL(uri)

const users = [] // temperary saving user data into an empty array for now....

// mongoose.connect(mongoURI, {
//     useNewUrlParser: true,
//     useCreateIndex: true,
//     useUnifiedTopology: true
// }).then((res) => {
//     console.log("MongoDB Connected")
// });

// const store = new MongoDBSession({
//   // uri is the database uri/url. collection is where different sessions will be stored.
//     uri: mongoURI,
//     collection: "mySessions",
// });

app.set("view engine", "ejs"); // It is to be able to use ejs files.
app.use(express.urlencoded({ extended: false }));

// 1. Session is a middleware function such that every session is to be passed to the server.
// 2. resave is to make sure that we create new session each time.
// 3. saveUninitialized is to make sure the session is not saved by default. 
// app.use(session({
//     secret: 'key that will be used to sign the cookie',
//     resave: false,
//     saveUninitialized: false,
//     store: store,
// }));

// 1. session object is saved in req.
// 2. isAuth is to change saveUninitialized prop of the session true
//    in order to save a session to cookie.
// 3. If logging "req.session.id", then able to read a copy of the session id saved in cookie.
// app.get('/', (req, res) => {
//   req.session.isAuth = true;
//   res.send('Hello Session!')
// });

// 1. req is an object that containing information of your http request, 
// res is an object that you will be used to send something back to the http response
app.get('/', (req, res) => {
  res.render("landing");
});

app.get("/login", (req,res) => {
  res.render("login");
});

// app.post('/login', (req, res) => {
//   //
// });

app.get('/register', (req, res) => {
  res.render("register");
});

// Async function is to make sure it always return something in the futrure???
// Which IS supposed to be in Fulfilled, Rejected or Pending state
app.post('/register', async (req, res) => {
  try{
    // Await is to make sure the hashing is completed before doing other tasks.
    // means to hash it for 10 times.
    const hashedPassword = await bcrypt.hash(req.body.password, 10) 
    users.push(
      {
        id: Date.now().toString(),
        pid: req.body.pid,
        password: hashedPassword,
      }
    )
    res.redirect("login");
  } catch{
    res.redirect("register");
  }
  console.log(users)
});

app.get('/dashboard', (req, res) => {
  res.render("dashboard");
});

//Setting up the port for our node server.
app.listen(5000, 
  console.log(`Example app listening on port 5000!`)
);

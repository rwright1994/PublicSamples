// require dotenv package for environmental variables for security.
require('dotenv').config();
const path = require('path');
const cors = require('cors');


// create route objects for express.
const loginRoutes = require('./routes/Login');
const logoutRoutes = require('./routes/Logout');
const registerRoutes = require('./routes/Register');
const blogRoutes = require('./routes/Blog');

// import express &express session route management.
const express = require('express');
const session = require('express-session');
// create MongoClient

const MongoStore = require('connect-mongo');
const mongoose = require('mongoose');
const {authenticateUser, loggedStatus} = require('./middleware/AuthMiddleware');
const webApp = express();




// middleware initalization.
webApp.use(express.static(path.join(__dirname, 'public')));
webApp.use(express.json());
webApp.use(express.urlencoded({extended:true}));

// Enable cors.
webApp.use(cors({
    origin: "http://localhost:5173",
    credentials: true,
}));

// Connect to MongoAtlasDB.
mongoose.connect(process.env.MONGOATLASDB_CONNECTION_STRING);

webApp.use(session({
    secret: 'dontforgettoREPLACEme',
    resave: true,
    saveUninitialized: false,
    store: MongoStore.create({
        mongoUrl: process.env.MONGOATLASDB_CONNECTION_STRING,
        ttl: 14 * 24 * 60 * 60 
    }),
    cookie: {
        maxAge: 1000 * 60 * 60 * 24,
        httpOnly: true,
    },
    
}));



// Link routes to expressJS

webApp.use('/login', authenticateUser, loginRoutes);
webApp.use('/logout', logoutRoutes);
webApp.use('/register',registerRoutes);
webApp.use('/blog', loggedStatus, blogRoutes);

// webApp.get('/', (req,res) => {
//     if(req.session && req.session.user){
//         res.send(req.session.user);
//     }else{
//         res.send(null);
//     }
// })

webApp.get('/', (req,res, err) => {
    try{
        res.send({user: "Robbie Wright"});
        console.log("accessed");
    }catch(err){
        console.log(err);
    }
})

// Open port to listen to
webApp.listen(process.env.PORT || PORT, () => {
    console.log(process.env.PORT);
    console.log("Node.js Server is now running for TKI - Website");
})

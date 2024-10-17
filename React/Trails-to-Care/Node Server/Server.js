require('dotenv').config();

// Import required dependencies for the project.
const path = require('path'); 
const cors = require('cors'); //Cross-Origin Request Sharing express middleware
const express = require('express'); // ExpressJS routing dependency
const session = require('express-session'); // Express session management

// MongoDB Dependencies
const MongoStore = require('connect-mongo'); // Connect mongo for session storeage with express.
const mongoose = require('mongoose');

// Express routes.
const registerRoute = require('./routes/Register');

// initalize express.
const WebApp = express();


// initalize middle ware for express.
WebApp.use(express.static(path.join(__dirname, 'public'))); // server static assets from the public directory.
WebApp.use(express.json()); //Use JavaScript-Object notation for parsing.
WebApp.use(express.urlencoded({extended:true}));

// Enable Cross-Origin Resource Sharing
WebApp.use(cors({
    origin: "http://localhost:3000",
    credentials:true,
}));
//Connect to MongoAtlasDB.
const mongoUrl = process.env.MONGOATLASDB_CONNECTION_STRING; // constant connectionURL

mongoose.connect(mongoUrl);

// Setup a session and session store.
WebApp.use(session({
    secret: "dontforgettoREPLACEme",
    resave: true,
    saveUninitialized: false,
    store: MongoStore.create({
        mongoUrl: mongoUrl,
        ttl: 14 * 24 * 60 * 60 // set the expiration date on session to 14 days. Default setting.
    }),
    cookie: {
        maxAge: 1000 * 60 * 60 * 24,
        httpOnly: true
    },
}));


// Link routes to expressJS
WebApp.use('/register', registerRoute);

WebApp.get('/', (req,res) => {
    res.send("success");
    console.log("success");
})

WebApp.listen(process.env.PORT || 3001, () => {
    console.log("Node server is current running on " + process.env.PORT)
})


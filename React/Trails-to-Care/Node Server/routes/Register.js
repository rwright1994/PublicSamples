// Import .env configurations
require('dotenv').config();

// Dependency Imports
const express = require('express'); 
const router = express.Router(); // Create express router object.
const mongoose = require('mongoose');
const User = require('../schema/UserModel');


async function registerUser(regData){

   
    try{
    
        // Check to see if there is a user.
        const foundUser = await User.findOne({  
            email: regData.email
        });

        // If the user already exists in the database.
        if(foundUser){
            console.log("User already registered as : " + foundUser.email);

        // User is no in the database, create new user.
        }else{ 
            const newUser = new User({
                _id: new mongoose.Types.ObjectId(),
                email: regData.email,
                password: regData.password
            });

            // save user to database.
            await newUser.save();
            console.log("User registered! Redirecting...")
        }
    // MongoDB Connection failure error message.
    }catch(err){
        console.log(err);
    }
}

router.post('/', (req,res) => {
    console.log(req.body);
    registerUser(req.body)
})

module.exports = router;
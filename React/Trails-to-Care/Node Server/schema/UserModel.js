const mongoose = require('mongoose');
const {Schema} = mongoose;


// Note: Schema information should be validated before updating.

// Schema for personal information
const personalInfoSchema = new mongoose.Schema({
    personalInfo: {
        firstName: {type: String, required: true},
        middleName: {type: String},
        lastName: {type: String, required: true},
        preferredName:{type: String},
        genderMain: {type: String},
        genderOther:{type: String},
        ethnicityMain: {type: String},
        ethnicityOther: {type: String},
    },
});

//Schema for address information
const addressDetailsSchema = new mongoose.Schema({
    addressDetails: {
        primaryAddress: {type: String, require:true},
        city: {type: String, required:true},
        province: {type: String, required:true},
        postalCode: {type: String, required:true},
        country: {type: String, required:true},
    }
});

// Bare minimum login details. Embedded two schemas for other details.
const userSchema = new mongoose.Schema({
    _id: Schema.Types.ObjectID, // Generate a random objectID
    email: {type: String, required: true, unqiue:true},
    password: {type: String, required:true, unique:true},
    personalInfo : personalInfoSchema, // internal reference
    addressDetails: addressDetailsSchema  // internal reference
});

const User = mongoose.model('User', userSchema);

module.exports = User;




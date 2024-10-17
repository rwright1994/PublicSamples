
//  ------------------------------------------------------------------------------  //
//  ****************************  Dependency Imports  ****************************  //

import { useEffect, useState } from 'react';

//  ------------------------------------------------------------------------------  //
//  ****************************  Component Imports  *****************************  //

import SingleInputField from '../../components/dashboard/SingleInputField';
import DoubleInputField from '../../components/dashboard/DoubleInputField';
import SelectorField from '../../components/dashboard/SelectorField';

//  ------------------------------------------------------------------------------  //
//  ****************************  Dependency Imports  ****************************  //
import '../../styles/DashBoard.css';


const DashboardProfile = () => {

//  ---------------------------------------------------------------------------------  //
//  ****************************  Selection Options  ********************************  //

const genderOptions = ["Select an option...","Male","Female","Non-Binary", "Transgender", "Prefer not to say", "Other"];
const enthnicityOptions = ["Select an option...", "African American", "Asain", "Hispanic", "Caucasian", "Prefer not to say", "Other"];

const provinceOptions = [ "Select a Province...",
    "Alberta",
    "British Columbia",
    "Manitoba",
    "New Brunswick",
    "Newfoundland and Labrador",
    "Northwest Territories",
    "Nova Scotia",
    "Nunavut",
    "Ontario",
    "Prince Edward Island",
    "Quebec",
    "Saskatchewan",
    "Yukon"
];

const countryOptions = ["Canada"]


//  -------------------------------------------------------------------------------  //
//  ****************************  State Variables  ********************************  //

// Creates a react State object that contains all the form .
const [formData,setFormData] = useState({
    personalInfo: {
        firstName: "",
        middleName: "",
        lastName: "",
        preferredName: "",
        genderMain: "Select an option...",
        genderOther: "",
        ethnicityMain: "Select an option...",
        ethnicityOther: ""
    },
    addressDetails: {
        primaryAddress: "",
        city: "",
        province: "Select a Province",
        postalCode:"",
        country: "Canada",
    }
})

// Placeholder use effect to ensure that information is being captured. Will be removed.
useEffect( () => {
    console.log(formData);
},[formData]);

//  ------------------------------------------------------------------------------  //
//  ****************************  Event Handlers  ********************************  //

// Handles all form input data.
const handleInputChange = (event) => {

    // Destructure the target event extracting name and value
    const {name,value} = event.target;
    // Destructures the name from the input to get the group the field belongs to.
    const [group, field] = name.split('.'); 

    setFormData( (prevState) => ({
        ...prevState,
        [group]:{
            ...prevState[group],
            [field]: value // Updates the specific field inside the specified group.
        }
    }));
}

// Conditionally renders the other input fields depending on which selections are made for each input field.

let otherInputFields;

if(formData.personalInfo.genderMain == "Other" && formData.personalInfo.ethnicityMain == "Other"){
    otherInputFields = 
    <DoubleInputField 
        names={{first:"personalInfo.genderOther", second:"personalInfo.ethnicityOther"}}
        labels={{first: "Gender Not Listed", second: "Ethnicity Not Listed"}}
        handleInputChange={handleInputChange}
        placeholders={{first:"Specify Gender...", second:"Specify Ethnicity..."}}
        required={{one:true,second:true}}
        fieldValues={{first:formData.personalInfo.firstName, second:formData.personalInfo.lastName}}
    /> 
}else if(formData.personalInfo.ethnicityMain == "Other"){
    otherInputFields = 
    <div className='flex justify-evenly'>
        <div className='hidden md:block other-spacer'/> {/* Placeholder div to push content to the end with other inputs in the form.*/}
        <SingleInputField
                name="personalInfo.ethnicityOther"
                label="Ethnicity Not Listed"
                placeholder="Ethnicity..."
                fieldValue={formData.personalInfo.primaryAddress}
                handleInputChange={handleInputChange}
                required={true}
                size="short"
                />
    </div>
}else if(formData.personalInfo.genderMain == "Other"){
    otherInputFields = 
    <div className='flex flex-col items-center md:flex-row md:justify-evenly'>
        <SingleInputField
            name="personalInfo.genderOther"
            label="Gender Not Listed"
            placeholder="Address information..."
            fieldValue={formData.personalInfo.primaryAddress}
            handleInputChange={handleInputChange}
            required={true}
            size="short"
        />
        <div className='hidden md:block other-spacer'/> {/* Placeholder to keep content in line with other inputs in the form */}
    </div> 
}

//  ------------------------------------------------------------------------------  //
//  ****************************  React Element  *********************************  //
    return(
        <div>
            <form className="profile-form p-8 lg:mx-auto">
                <section id="personal-info">
                <h1 className="text-3xl text-center my-8">Welcome User to Your Profile Page</h1>
                <div className='flex flex-col justify-center items-center'>
                    <img className="rounded-full p-12 sm:size-1/2 md:p-8 md:size-1/3" src="https://eu.ui-avatars.com/api/?name=John+Doe&size=250"/>
                    <a href="" className='mx-auto pb-8 text-blue-500 underline'>Upload profile</a>
                </div>
                    <h2 className="pb-4 text-xl underline">Personal Information</h2>
                    <h5 className="text-center md:text-none text-slate-400 text-sm pb-4">Please enter or change the required information marked by a * before submitting.</h5>
                    <DoubleInputField 
                        names={{first:"personalInfo.firstName", second:"personalInfo.lastName"}}
                        labels={{first: "First Name", second: "Last Name"}}
                        handleInputChange={handleInputChange}
                        placeholders={{first:"Enter First Name...", second:"Enter Last Name..."}}
                        required={{one:true,second:true}}
                        fieldValues={{first:formData.personalInfo.firstName, second:formData.personalInfo.lastName}}
                        /> 
                    <DoubleInputField 
                        names={{first:"personalInfo.preferredName", second:"personalInfo.middleName"}}
                        labels={{ first:"Preferred Name", second:"Middle Name"}}
                        handleInputChange={handleInputChange}
                        placeholders={{first:"Enter Preferred Name...", second:"Enter Middle Name..."}}
                        required={{second:true}}
                        fieldValues={{first:formData.personalInfo.preferredName,second:formData.personalInfo.middleName}}
                        />
                    <div className="flex flex-col md:flex-row md:justify-evenly md:py-4 text-white">
                        <SelectorField
                            fieldName="personalInfo.genderMain"
                            label="Gender"
                            selectedValue={formData.personalInfo.genderMain}
                            selectionOptions={genderOptions}
                            handleInputChange={handleInputChange}
                            required={true}
                            />
                        <SelectorField 
                            fieldName="personalInfo.ethnicityMain"
                            label="Ethnicity"
                            selectedValue={formData.personalInfo.ethnicityMain}
                            selectionOptions={enthnicityOptions}
                            handleInputChange={handleInputChange}
                            required={true}
                        />
                    </div> 
                    {otherInputFields}                    
                </section>

                <section id="address-info">
                    <div className='flex'>
                        <h2 className='text-xl pb-4 underline'>Address Details</h2>
                    </div>
                    <h3 className='text-lg pb-4'>Primary Address</h3>
                    <h5 className="text-center md:text-none text-slate-400 text-sm pb-4">Please enter or change the required information marked by a * before submitting.</h5>
                        <SingleInputField
                            name="addressDetails.primaryAddress"
                            label="Address"
                            placeholder="Address information..."
                            fieldValue={formData.personalInfo.primaryAddress}
                            handleInputChange={handleInputChange}
                            required={true}
                        />
                    <div className='flex flex-col items-center md:flex-row md:justify-evenly md:py-4 text-white'>
                        <SingleInputField
                            name="addressDetails.city"
                            label="City"
                            placeholder="Enter City Name..."
                            fieldValue={formData.addressDetails.city}
                            handleInputChange={handleInputChange}
                            size="short"
                            required={true}
                            />
                        <SelectorField 
                            fieldName="addressDetails.province"
                            label="Province"
                            selectedValue={formData.addressDetails.province}
                            selectionOptions={provinceOptions}
                            handleInputChange={handleInputChange}
                            required={true}
                            />
                    </div> 
                    <div className='flex flex-col items-center md:flex-row md:justify-evenly text-white'>
                        <SingleInputField
                            name="addressDetails.postalCode"
                            label="Postal Code"
                            placeholder={"A1A 2B2"}
                            fieldValue={formData.personalInfo.primaryAddress}
                            handleInputChange={handleInputChange}
                            required={true}
                            size="short"
                            />        
                          <SelectorField
                            fieldName="personalInfo.genderMain"
                            label="Country"
                            selectedValue={formData.personalInfo.genderMain}
                            selectionOptions={countryOptions}
                            disabled={true}
                            handleInputChange={handleInputChange}
                            required={true}
                            />
                    </div>
                </section>
            </form>
        </div>
    )
}

export default DashboardProfile;
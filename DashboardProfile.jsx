
//  ------------------------------------------------------------------------------  //
//  ****************************  Dependency Imports  ****************************  //

import { useEffect, useState } from 'react';

//  ------------------------------------------------------------------------------  //
//  ****************************  Class Imports  ****************************  //
import User from '../../classes/User';

//  ------------------------------------------------------------------------------  //
//  ****************************  Component Imports  *****************************  //

import DoubleInputField from '../../components/dashboard/DoubleInputField';

//  ------------------------------------------------------------------------------  //
//  ****************************  Dependency Imports  ****************************  //
import '../../styles/DashBoard.css';

const DashboardProfile = () => {

//  -------------------------------------------------------------------------------  //
//  ****************************  State Variables  ********************************  //

// Creates a react State object that contains all the form .
const [formData,setFormData] = useState({
    personalInfo: {
        firstName: "",
        middleName: "",
        lastName: "",
        preferredName: "",
        gender: "Select an option...",
        ethnicity: "Prefer not to answer"
    },
    addressDetails: {
        primaryAddress: "",
        city: "",
        province: "",
        postalCode:"",
        country: "Canada",
    }
})


const [user,setUser] = useState();

useEffect( () => {
    console.log(formData);
},[formData]);

// useEffect(() => {
//     const userData = new User("robert","wright","Jan 17 94", "robbie.wright@example.com");
//     setUser(userData);
// },[])

// useEffect(() => {
//     console.log(user);
// },[user])
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


//  ------------------------------------------------------------------------------  //
//  ****************************  React Element  *********************************  //
    return(
        <div>
            <h1 className="text-3xl text-center mt-8">Profile</h1>
            <form id="profile-form" className='p-8 lg:mx-auto'>
                <section id="personal-info">
                    <h2 className="pb-4 text-xl underline">Personal Information</h2>

                     <DoubleInputField 
                        handleInputChange={handleInputChange}
                        fieldOnePlaceHolder="Enter First Name..."
                        fieldTwoPlaceHolder="Enter Last Name..."
                        fieldOneValue={formData.personalInfo.firstName}
                        fieldTwoValue={formData.personalInfo.lastName}
                        /> 

                    <DoubleInputField 
                        handleInputChange={handleInputChange}
                        fieldOnePlaceHolder="Enter Preferred Name..."
                        fieldTwoPlaceHolder="Enter Middle Name..."
                        fieldOneValue={formData.personalInfo.preferredName}
                        fieldTwoValue={formData.personalInfo.middleName}
                     />


                    <div className="flex justify-evenly py-4 text-white">
                        <div className="flex">
                            <label className="bg-amber-700 rounded-s-lg p-1 w-40">Gender:</label>
                            <select name="personalInfo.gender" 
                                    defaultValue="Select an option..."
                                    value={formData.personalInfo.gender}
                                    onChange={handleInputChange}
                                    className='text-black border w-48 ps-1'>
                                <option>Select an option...</option>
                                <option>Male</option>
                                <option>Female</option>
                                <option>Transgender</option>
                                <option>Non-binary</option>
                                <option>Prefer not to answer</option>
                            </select>
                        </div>
                        <div className="flex">
                            <label className="bg-amber-700 rounded-s-lg p-1 w-40">Example:</label>
                            <input type="text" placeholder="Race..."className="border w-48 ps-1"></input>
                        </div>
                    </div>
                </section>

                <section>
                        <h2 className='text-xl pb-4 underline'>Address Details</h2>
                        <h3 className='text-lg pb-4'>Primary Address</h3>
                        <div className='flex py-4'>
                            <label className="bg-amber-700 rounded-s-lg p-1 w-40 text-white">Address:</label>
                            <input type="text" 
                                    name="addressDetails.primaryAddress"
                                    value={formData.addressDetails.primaryAddress}
                                    onChange={handleInputChange}
                                    placeholder="Enter Middle Name..." 
                                    className="border w-full ps-1"></input>
                        </div>
                        <div className='flex justify-evenly py-4'>

                        <div className='flex'>
                            <label className="bg-amber-700 rounded-s-lg p-1 w-40 text-white">City:</label>
                            <input type="text" 
                                    name="addressDetails.primaryAddress"
                                    value={formData.addressDetails.primaryAddress}
                                    onChange={handleInputChange}
                                    placeholder="Enter Middle Name..." 
                                    className="border w-48 ps-1"></input>
                        </div>

                        <div className='flex'>
                            <label className="bg-amber-700 rounded-s-lg p-1 w-40 text-white">Province:</label>
                            <input type="text" 
                                    name="addressDetails.primaryAddress"
                                    value={formData.addressDetails.primaryAddress}
                                    onChange={handleInputChange}
                                    placeholder="Enter Middle Name..." 
                                    className="border w-48 ps-1"></input>
                        </div>
                        
                        

                        </div>
                        <div className='flex justify-evenly py-4 text-white'>
                        <div className="flex">
                            <label className="bg-amber-700 rounded-s-lg p-1 w-40">Postal Code:</label>
                            <input type="text" 
                                   name="personalInfo.preferredName"
                                   value={formData.personalInfo.preferredName}
                                   onChange={handleInputChange}
                                   placeholder="Enter Preferred Name..."
                                   className="border w-48 ps-1"></input>
                        </div>
                        <div className="flex">
                            <label className="bg-amber-700 rounded-s-lg p-1 w-40">Country:</label>
                            <input type="text" 
                                   name="personalInfo.middleName"
                                   value={formData.personalInfo.middleName}
                                   onChange={handleInputChange}
                                   placeholder="Enter Middle Name..." 
                                   className="border w-48 ps-1"></input>
                        </div>
                    </div>

                       

            
                </section>
            </form>
        </div>
    )
}

export default DashboardProfile;
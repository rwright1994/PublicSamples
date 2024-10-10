//  ------------------------------------------------------------------------------  //
//  ****************************  Dependency Imports  ****************************  //
import { useEffect, useState } from 'react';
import { Outlet } from "react-router-dom";
import DashboardSideNav from "../../components/navigation/DashboardSideNav";

const DashBoard = () => {

const [user, setUser] = useState("User");
const [activeNav,setActiveNav] = useState(false);

// Handler that manages the toggling of the side navigation menu. 
// Note: This is probably going to get moved to the main App component
// and accessed via context.
const sideNavTogglerHandler = (event) =>{
    setActiveNav(!activeNav);
}

// useEffect will be called anytime the data that is passed into the array []
// changes. Note: Will be removed since it is only used for testing purpose, but
// useEffect can be used on anything we pass to the array to perform an action.
useEffect( () => {
    console.log(activeNav);
},[activeNav]);

//  ------------------------------------------------------------------------------  //
//  ****************************  React Element  *********************************  //
    
    return(
        <div className="h-screen">
                    <DashboardSideNav activeNav={activeNav} sideNavTogglerHandler={sideNavTogglerHandler}/>
                    <Outlet context={[user,activeNav, sideNavTogglerHandler]}/>
        </div>
    )
}

export default DashBoard;
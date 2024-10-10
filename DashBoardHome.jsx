//  ------------------------------------------------------------------------------  //
//  ****************************  Dependency Imports  ****************************  //
import {useOutletContext } from "react-router-dom";
import '../../styles/Dashboard.css';
import MedicalHistoryItem from "../../components/dashboard/MedicalHistoryItem";

const DashBoardHome = () => {

// Get the context infomation from the context provided to the outlet.
// Context allows access to variables in multiple react components with
// having to pass it via props everytime.
const [user, activeNav,navToggle] = useOutletContext();


// A simple placeholder list that is used to test the overflow on the UI container that holds the
// each medical item.
const placeHolderList = [
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"},
    {date: "Oct 1", superScript: "st", visitInfo: "Stomach Ache" , visitDuration: "10 Minutes"}
]

//  ------------------------------------------------------------------------------  //
//  ****************************  React Element  *********************************  //
    
    return(
        <div className="flex flex-col">
            <div className="flex">
                <div className={`absolute top-0 ${activeNav ? "hidden" : ""}`}><i className={`fa-solid fa-bars fa-2xl m-8 hover:text-red-500`} onClick={navToggle}></i></div>
                <div className="m-auto text-3xl pt-8">
                    Welcome {user} to your medical dashboard!
                </div>
            </div>

            <div className="flex flex-col">
            <div id="medical-info-option-bar" className="rounded-t-md h-12 bg-slate-200/75 shadow ">

            </div>
                <div id="medical-info-list" >
                    <ul>

                        {/* This maps each item from the placeHolderList object into a react component
                        and provides it with a key required by React by using an index.  It also passes the
                        object data from the placeHolderList via props.*/}
                        {placeHolderList.map((item,index) => 
                            <MedicalHistoryItem 
                            key={index}
                            date={item.date}
                            superScript={item.superScript}
                            visitInfo={item.visitInfo}
                            visitDuration={item.visitDuration}/>
                        )}
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default DashBoardHome;
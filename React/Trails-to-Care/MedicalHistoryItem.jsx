
// Receives props data from where ever we pass from, in this case
// we pass it in the DashboardHome component. 

const MedicalHistoryItem = (props) => {

//  ------------------------------------------------------------------------------  //
//  ****************************  React Element  *********************************  //
    return(
    <li>
        <div className="flex mb-2">
            <div className="flex">
                <div className="flex flex-col bg-slate-200 border rounded text-center p-2 h-24 w-24 my-auto ">
                <h4 className="w-16 h-10 text-lg mx-auto">{props.date} <sup>{props.superScript}</sup></h4>
                <p className="text-sm">Time: 10:30am</p>
                </div>
            </div>
            <div className="grow my-auto">
                <p className="text-center">
                 Nature of visit: {props.visitInfo}. Watch out for the overflow though!
                 </p>
            </div>
            <div>
            <div className="flex flex-col bg-slate-200 border rounded text-center p-2 w-36  ">
                <h4>Duration:</h4>
                <p className="text-xl">{props.visitDuration}</p>
                <h5><a href="#" className="underline text-blue-900">Details</a></h5>
                </div>
            </div>
        </div>
    </li>
    )
}

export default MedicalHistoryItem;
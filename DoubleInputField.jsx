/**
* A simple service card component.
*
* @component
* @param {Object} props - The component accepts a service name and list of serivce list.
* @param {string} props.fieldOneValue - 
* @param {array} props.serviceList - A simple list that displays the serivces offered for the given type, e.g. consult,basic.
* @returns {JSX.Element} The service card.
*
* @example
* // Render a service card object with a provided heading a list of services provided with it.
* <ComponentName/>
*/

const DoubleInputField = ({fieldOneValue, fieldTwoValue, handleInputChange, inputType = 'text',
                    fieldOnePlaceHolder, fieldTwoPlaceHolder}) => {

    const type = inputType == 'text' ? 'text' : inputType ; 


    return(
        <div className="flex justify-evenly text-white py-4">
            <div className="flex">
                <label className="bg-amber-700 rounded-s-lg p-1 w-40">First Name:</label>
                <input type="text"
                    name="personalInfo.firstName" 
                    value={fieldOneValue} 
                    onChange={handleInputChange}
                    placeholder={fieldOnePlaceHolder}
                    className="border w-48 ps-1"/>
            </div>
            <div className="flex">
                <label className="bg-amber-700 rounded-s-lg p-1 w-40">Last Name:</label>
                <input type="text" 
                    name="personalInfo.lastName" 
                    value={fieldTwoValue}
                    onChange={handleInputChange}
                    placeholder={fieldTwoPlaceHolder}
                    className="border w-48 ps-1"></input>
            </div>
        </div>
    )
}

export default DoubleInputField;
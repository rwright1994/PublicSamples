/**
* A simple service card component.
*
* @component
* @param {string} fieldOneValue - The value passed into the first input field to display current inputs state. 
* @param {function} handleInputChange - Input change handler used to update each inputs state.
* @param {string} fieldOnePlaceholder - The value passed into the first input field to display current inputs state. 
* @param {function} handleInputChange - Input change handler used to update each inputs state.
* @param {string}  inputType - The input type for any given field. Has default value of text if it is not passed in.
* 
* @example
* // Render a service card object with a provided heading a list of services provided with it.
* <ComponentName/>
*/

const DoubleInputField = ({fieldValues, labels={first: "", second:""}, names, handleInputChange, placeholders, required={first:false,second:false}}) => {
 

    return(
        <div className="flex flex-col items-center md:flex-row md:justify-evenly md:py-4 text-white">
            <div className="flex py-4 md:py-0 md:max-h-8">
                <label className="bg-amber-700 rounded-s-lg p-1 w-40">{required.first ? <sup>*</sup>:""}{labels.first}</label>
                <input type="text"
                    name={names.first}
                    value={fieldValues.first} 
                    onChange={handleInputChange}
                    placeholder={placeholders.first}
                    defaultValue={placeholders.first}
                    className="border w-60 md:w-48 ps-1"/>
            </div>
            <div className="flex py-4 md:py-0 md:max-h-8">
                <label className="bg-amber-700 rounded-s-lg p-1 w-40">{required.second ? <sup>*</sup>:""}{labels.second}</label>
                <input type="text" 
                    name={names.second}
                    value={fieldValues.second}
                    onChange={handleInputChange}
                    placeholder={placeholders.second}
                    defaultValue={placeholders.second}
                    className="border w-60 md:w-48 ps-1"></input>
            </div>
        </div>
    )
}

export default DoubleInputField;
const SelectorField = ({fieldName, label,selectedValue, selectionOptions, disabled=null,required=false, handleInputChange}) => {

    


    return(
     <div className="flex justify-center py-4 md:py-0 md:max-h-8">
        <label className="bg-amber-700 rounded-s-lg p-1 w-40">{required?<sup>*</sup>:""}{label}</label>
        <select name={fieldName}
                value={selectedValue}
                disabled={disabled}
                onChange={handleInputChange}
                className='border w-60 md:w-48 ps-1'>
                    {selectionOptions.map((selectionItem,index) => 
                    <option key={index} value={selectionItem}> {selectionItem}</option>)}
        </select>
        {/* Conditioanlly render div if other is selected and on a mobile device. */}
    </div>
    )
}

export default SelectorField;
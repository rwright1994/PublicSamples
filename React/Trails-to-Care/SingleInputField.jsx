const SingleInputField = ({ name, label, placeholder, fieldValue,
                       handleInputChange, required=false, size=null, disabled=false}) => {

    // As per tailwindCSS need to use complete class names to avoid errors.

    const inputStyle = size == "short" ? "border w-60 md:w-48 ps-1" : "border flex-1 ps-1";


    return(
    <div className='flex py-4 md:py-0  md:max-h-8'>
        <label className="bg-amber-700 rounded-s-lg p-1 w-40 text-white">{required ? <sup>*</sup>:""}{label}</label>
        <input  className={inputStyle}
                type="text" 
                name={name}
                placeholder={placeholder}
                value={fieldValue}
                onChange={handleInputChange}
                disabled={disabled}
            
               ></input>
    </div>
    )
}

export default SingleInputField;
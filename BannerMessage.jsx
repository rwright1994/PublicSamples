

const BannerMessage = () => {

    //  ------------------------------------------------------------------------------  //
    //  ****************************  React Element  *********************************  //
    return(
    <div className="relative w-full flex justify-center items-center text-white opacity-0 transition-opacity transition-duration-700 sm:transition-duration-1000">
        <div className="msg-banner p-5 me-5 ms-10 relative -translate-x-40 transition-transform duration-700 bg-slate-100 rounded-sm shadow-sm shadow-slate-500 bg-opacity-20">
            <h1 className="text-3xl text-center mb-5">Website Management that sparks real growth!</h1>
            <p className="text-center text-lg italic">Put your clients first! Not your web page!</p>
        </div>  
    </div>
    )
}

export default BannerMessage;
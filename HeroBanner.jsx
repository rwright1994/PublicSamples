//  ------------------------------------------------------------------------------  //
//  ****************************  Component Imports  *****************************  //
import Bar from '../Bar';
import BannerMessage from "./BannerMessage";

const HeroBanner = () => {

//  ------------------------------------------------------------------------------  //
//  ****************************  Data Objects  *****************************  //

// Cannot dyanmically create calles using tailwind css
const bars = [
    {id:0, barClass: "bg-red-500 h-4"},
    {id:1, barClass: "bg-red-400 h-8"},
    {id:2, barClass: "bg-orange-500 h-16"},
    {id:3, barClass: "bg-orange-400 h-24"},
    {id:4, barClass: "bg-amber-300 h-36"},
    {id:5, barClass: "bg-amber-400 h-48"},
    {id:6, barClass: "bg-yellow-300 h-60"},
    {id:7, barClass: "bg-yellow-400 h-72"},
    {id:8, barClass: "bg-lime-400 h-80"},
    {id:9, barClass: "bg-green-400 h-96" }
]






//  ------------------------------------------------------------------------------  //
//  ****************************  React Element  *********************************  //
    return(
    <div className="flex w-full h-full justify-between bg-slate-900">
        <BannerMessage/>
        <div className="flex pt-20">
            <div className="flex items-end">
                {/*  
            {/* ==================  Hero Bar  ================== */}
                {bars.map((bar) => <Bar key={bar.id}
                                            barClass={bar.barClass} />
            )}
           
            </div>
        </div>
    </div>
    )
}

export default HeroBanner;
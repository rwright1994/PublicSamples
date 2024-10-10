//  ------------------------------------------------------------------------------  //
//  ****************************  Dependency Imports  ****************************  //
import { useEffect } from "react";


//  ------------------------------------------------------------------------------  //
//  ****************************  Component Imports  *****************************  //
import HeroBanner from "../components/home/HeroBanner";
import ProfilePicRounded from "../components/global/ProfilePicRounded";

const Home = () => {



/*==================  Functions  ==================*/

// Calls useEffect when component mounts to animate bars with
// a growing effect.
const animateBars = () =>{
    useEffect( () => {
        const bars = document.querySelectorAll('.bar');
        bars.forEach((bar) => {
            
            setTimeout( () => {
                bar.classList.remove('scale-y-0');
            },100)            
        });
    },[])
}

// Calls useEffect when compoent mounts to animate the message
// banner.
const animateBanner = () => {
    useEffect( () => {
        const banner = document.querySelector('.msg-banner');
        setTimeout( () => {
            banner.classList.remove('-translate-x-40');
            banner.parentElement.classList.remove('opacity-0');
        },100)
    },[]);
}

animateBars();
animateBanner();

//  ------------------------------------------------------------------------------  //
//  ****************************  React Element  *********************************  //

    return (
        <div>
            <HeroBanner/>
            <div className="flex flex-col justify-center items-center bg-zinc-100 pt-20">
                <h2 className="text-2xl">How Our Process Works</h2>
                <div className="w-full flex flex-col">
                    <div className="w-full flex justify-between items-center p-10 ">
                        <div className="flex flex-col items-center w-3/4">
                      
                            <i className="fa-solid fa-magnifying-glass-chart fa-8x py-4"></i>
                        <h4 className="text-lg py-5">1. Discovery Phase</h4>
                        </div>    
                    <div className="w-full">
                        <p className="text-center">Finding the best fit of services for your small business matters to use. It's important
                            not to over spend on services that other companies try to sell you.</p>
                    </div>
                    </div>
                </div>

            </div>
            <div className="bg-zinc-100 w-full flex h-96">
                <div className="flex justify-center items-center w-1/2">
                    <p className="text-center">After thoughly discussing the right solution(s) that best suits your need, we'll get stright
                      to work doing what we do best.</p>
                </div>
                <div className="flex flex-col justify-center items-center w-1/2">
                    <i className="fa-solid fa-file-code fa-6x py-6"></i>
                    <h4 className="text-lg">2. Building the Services </h4>
                </div>
            </div>
            <div className="bg-zinc-100 w-full flex h-96">
                <div className="flex flex-col justify-center items-center w-1/2">
                    <i className="fa-solid fa-ranking-star fa-6x py-6"></i>
                    <h4 className="text-lg">3.Exception Customer Service</h4>
                </div>
                <div className="flex justify-center items-center w-1/2">
                    <p></p>
                </div>
            </div>
            <div className="flex flex-col bg-zinc-100">
                <h2 className="text-2xl text-center my-10"><u>Our Team</u> <br/> Experience you can trust!</h2>
                <div className="flex justify-between bg-slate-800">
                    <ProfilePicRounded width='1/2'/>
                </div>
            </div>
            <div className="bg-zinc-100 w-full flex h-96">
                <div className="flex flex-col items-center justfy-center mx-10">
                    <h1 className="py-10 text-2xl">Other Specialized Cybersecurity Services</h1>
                    <p className="text-center">Almost everyday we're exposed the potential to have our information stolen digitally and we don't even think much of it.
                        Until it happens. That's why we want to offer a specialized set of services dedicated to cyber security. </p>
                        <div className="flex text-red-600">
                            <div>
                                <i className="fa-solid fa-bug fa-3x mx-4 py-6 transform transition-transform duration-300 hover:scale-150"/>
                                <p className="text-center">Bugs</p>
                            </div>
                            <div>
                                <i className="fa-solid fa-virus fa-3x mx-4 py-6 transform transition-transform duration-300 hover:scale-150"/>
                                <p className="text-center"> Viruses</p>
                            </div>
                            <div>
                                <i className="fa-solid fa-bullseye fa-3x mx-4 py-6"/>
                                <p className="text-center"></p>
                            </div>
                            <div>
                                <i className="fa-solid fa-network-wired fa-3x mx-4 py-6 transform transition-transform duration-300 hover:scale-150"/>
                                <p className="text-center">Network</p>
                            </div>
                            <div>
                                <i className="fa-regular fa-credit-card fa-3x mx-4 py-6 transform transition-transform duration-300 hover:scale-150"/>
                                <p className="text-center">Information</p>
                            </div>
                        </div>
                        <p className="text-center">It's important to ensure that your network is secured with the proper technologies, regular network monitoring and
                            analysis of your systems security takes place. </p>
                </div>
            </div>
            <div>

            </div>
        </div>
    )
}

export default Home;
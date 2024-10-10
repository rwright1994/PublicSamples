

const Navbar = () => {

    //  ------------------------------------------------------------------------------  //
    //  ****************************  React Element  *********************************  //

    return(
        <nav id="navbar" className="h-20 text-black">
            <i></i>
            <ul id="nav-links" className="flex justify-center h-full text align-center shadow-md">
                <li><a>Home</a></li>
                <li><a>About</a></li>
                <li><a>Features</a></li>
                <li><a>Demo</a></li>
            </ul>
        </nav>
    )
}

export default Navbar;

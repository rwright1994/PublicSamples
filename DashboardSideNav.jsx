
import '../../styles/Navigation.css';

/**
 * A simple button component.
 *
 * @component
 * @param {Object} props - The props for the button.
 * @returns {JSX.Element} The rendered button.
 */


const DashboardSideNav = (props) => {

    

    return(
        <div className={`${props.activeNav ? 'flex flex-col bg-slate-900 text-white absolute top-0 h-full' : 'flex flex-col bg-slate-900 text-white absolute top-0 h-full hidden'}`}>
            <div id="close-btn-container" className={'p-4 flex justify-end'}>
                <i className="fa-solid fa-x fa-lg py-2 hover:text-red-400" onClick={props.sideNavTogglerHandler}></i>
            </div>
            <ul id="dashboard-side-nav" className="flex flex-col h-full">
                <li>Home</li>
                <li>Dashboard</li>
                <li><a href="/dashboard/profile">Profile</a></li>
                <li>Medical Notes</li>
            </ul>
        </div>
    )
}

export default DashboardSideNav;
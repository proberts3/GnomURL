import { Outlet } from "react-router-dom";
import NavBar from "./NavBar";
import Gnome from "../assets/Gardengnome.png";

export default function Layout() {
    return <div>
        <NavBar />
        <main className="container-fluid">
            <img src={Gnome} alt=""
                style={{ height: 200, width: 'auto', position: 'absolute', right: 20, top: 20 }}
             ></img>
            <Outlet />
        </main>
    </div>
}
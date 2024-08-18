import { Outlet } from "react-router-dom";
import NavBar from "./NavBar";

export default function Layout() {
    return <div>
        <NavBar />
        <main className="container-fluid">
            <Outlet />
        </main>
    </div>
}
import { Link } from "react-router-dom";

export default function NavBar() {
    return <header className="container grid" style={{ marginBottom: 32 }}>
        <Link to={"/"}>Home</Link>
        <Link to={"/view-url"}> View URL Info</Link>
        <Link to={"/info"}>Info</Link>
    </header>
}
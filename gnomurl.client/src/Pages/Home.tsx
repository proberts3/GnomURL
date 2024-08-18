import { FormEvent, useState } from "react";
import { PostGenerateURL } from "../Utils/API";
import ErrorBanner from "../Components/Error";
export default function Home() {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const [long, setLong] = useState('');
    const [short, setShort] = useState('');

    async function requestGURL(e: FormEvent) {
        if (e) { e.preventDefault(); }

        const result = await PostGenerateURL(long as URL, short);

        if (result.error) {
            setError(result.error);
        }

        setData(result.data);
    }

    function reset() {
        setData(null);
        setError(null);
        setLong('');
        setShort('');
    }

    if (data) {
        return <div className="container">
            <h1>URL Successful</h1>
            <p>Your short url is: <a href={`https://localhost:5173/${data}`}>https://localhost:5173/{data}</a></p>
            <p>For the url: {long}</p>
            <hr />
            <p>Note, this only works while the development server is active and will be destroyed when turned off.</p>
            <hr />
            <button onClick={reset}>Make another one!</button>
         </div>
    }

    return <div className="container">
        <h1>GnomURL</h1>
        {error && <ErrorBanner message={error} /> }
        <p>Shorten a URL</p>
        <div>
            <form onSubmit={e => requestGURL(e)}>
                <label>
                    Long URL
                    <input name="long" value={long} onChange={e => setLong(e.target.value)}/>
                </label>
                <hr />
                <label>
                    Custom Short URL
                    <input name="short" value={short} onChange={e => setShort(e.target.value)} />
                </label>

                <button disabled={long.length === 0} type="submit">Gnomify!</button>
            </form>
        </div>
    </div>;
}
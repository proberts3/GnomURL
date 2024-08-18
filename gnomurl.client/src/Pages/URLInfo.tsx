import { useState } from "react";
import { DeleteShortURL, GetURL } from "../Utils/API";
import ErrorBanner from "../Components/Error";

export default function URLInfo() {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const [urlData, setURL] = useState('');
    const [isDeleted, setIsDeleted] = useState('');

    async function deleteURL() {
        const result = await DeleteShortURL(data.shortURL);
        if (result.error) {
            setError(result.error)
        }

        setIsDeleted(data.shortURL);
        reset();
    }
    async function getURL() {
        let url;
        try { // This is mainly to catch invalid URLs
            url = new URL(urlData).pathname.split('/G/')[1]; // remove the '/G/'
            console.log(url)
        } catch (error) {
            setError('invalid URL');
            return;
        }
        const result = await GetURL(url);

        if (result.error) {
            setError(result.error.title);
        } else {
            setData(result.data)
        }

    }

    function reset() {
        setData(null);
        setError(null);
        setURL('');
    }

    if (data) {
        const { shortURL, longURL, count } = data;
        return <div>
            <h1>Info for: {shortURL}</h1>
            <p>short URL: https://localhost:5173/G/{shortURL}</p>
            <p>long URL: {longURL}</p>
            <p>Times redirected: {count}</p>

            <hr />
            <h2>Delete this URL?</h2>
            <button onClick={deleteURL}>Delete</button>
            <hr />
            <button onClick={() => reset()}>Reset</button>
        </div>
    }

    return <div>
        <h1>Redirect Info Page</h1>
        {error && <ErrorBanner message={error} />}
        {isDeleted && <div style={{ background: 'green', color: 'white', padding: 16 }}>{isDeleted} was deleted.</div>}
        <p>This contains info about the url that was redirected.</p>
        <p>This could be some kind of dashboard for a user.</p>
        <label>
            URL to find. This must include the https://localhost:5173/G/
            <input value={urlData} onChange={e => setURL(e.target.value)} />
        </label>
        <button onClick={getURL}> Get URL Details</button>
    </div>
}
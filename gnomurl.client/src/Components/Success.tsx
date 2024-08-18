import GnomURL from "../Types/GnomURL";

export default function Success({ ShortURL, LongURL, Count }: GnomURL) {
    return <div>
        <h1>Your URL was created!</h1>
        <p>ShortURL: { ShortURL }</p>
        <p>LongURL: { LongURL }</p>
        <p>Times Used: { Count }</p>
    </div>
}
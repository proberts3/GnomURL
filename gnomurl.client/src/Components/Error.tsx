export default function Error({ message }: { message: string }) {
    return <div className="container-fluid" style={{ background: 'red' }} role="alert">
        <h2 style={{ color: "white", fontWeight: 'bold' }}>There was an error:</h2>
        <p style={{ color: "white", fontWeight: 'bold' }}>{ message }</p>
    </div>
}
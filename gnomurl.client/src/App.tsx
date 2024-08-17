import { useState } from 'react';
import './App.css';

function App() {
    const [exdata, setData] = useState();

    return (
        <div>
            <h1 id="tableLabel">Home Page</h1>
            {exdata}
        </div>
    );

    async function getData() {
        const response = await fetch('exampleEndpoint');
        const data = await response.json();
        setData(data);
    }
}

export default App;
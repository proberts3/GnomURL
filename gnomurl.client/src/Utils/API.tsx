const headers = {
    'Content-Type': 'application/json'
}

export async function GetURL(shortURL: string) {
    try {
        const response = await fetch('URLGenerator?shortURL=' + shortURL);
        if (!response.ok) {
            throw (response)
        }
        console.log(response)

        const data = await response.json();
        console.log(data)

        return { response, data };

    } catch (error) {
        console.log(error)
        const msg = await error.json()
        console.log(msg)

        return { response: error, error: msg };
    }
}

export async function PostGenerateURL(longURL: URL, suggestedShortURL: string) {
    try {
        const body = JSON.stringify({
            longURL,
            suggestedShortURL
        });
        const response = await fetch('URLGenerator', {
            headers,
            method: 'POST',
            body
        });


        if (!response.ok) {
            throw (response)
        }

        const data = await response.json();

        return { response, data };

    } catch (error) {
        const msg = await error.text()
        return { response: error, error: msg };
    }
}

export async function DeleteShortURL(shortURL: string) {
    try {
        const body = JSON.stringify({
            shortURL
        });
        const response = await fetch('URLGenerator', {
            headers,
            method: 'DELETE',
            body
        });

        if (!response.ok) {
            throw (response)
        }

        return { response };

    } catch (error) {
        return { response: error, error: 'Unknown error' };
    }
}

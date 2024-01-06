const postAsync = (payload, url) => {
    return new Promise( async (resolve, reject) => {
        const response = await fetch(url,
            {
                method: 'POST',
                body: JSON.stringify(payload),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            }
        );
        if (!response.ok) {
            console.log(response)
            reject(`HTTP error! status: ${response.status}`)
        }
        const data = await response.json();
        resolve(data)
    })
}
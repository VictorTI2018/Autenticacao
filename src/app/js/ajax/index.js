const postAsync = (payload, url) => {
    return new Promise( async (resolve, reject) => {

        let token = ""
        if (JSON.parse(localStorage.getItem("token"))){
            token = JSON.parse(localStorage.getItem("token")).token
        }

        const response = await fetch(url,
            {
                method: 'POST',
                body: JSON.stringify(payload),
                headers: {
                    "Content-type": "application/json; charset=UTF-8",
                    "Authorization": `Bearer ${token}`
                }
            }
        );
        if (!response.ok) {
            reject(`HTTP error! status: ${response.status}`)
        }
        const data = await response.json();
        resolve(data)
    })
}
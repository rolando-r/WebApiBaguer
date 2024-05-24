
export class Fetch 
{
    constructor(){}

    async fetch(url, options) 
    {
        return fetch(`${url}`, options)
        .then(res => res.json())
        .catch(err => console.log(err))
    }
}
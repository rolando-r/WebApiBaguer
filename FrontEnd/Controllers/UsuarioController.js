import { Fetch } from "./Fetch.js"

export class UsuarioController extends Fetch
{
    constructor()
    {
        super()
    }

    controllerUsuarioToken(data)
    {
        let url = "http://localhost:5000/api/Usuarios/Token"
        let options = 
        {
            method : "POST",
            headers : new Headers
            ({
                "Content-Type":"application/json"
            }),
            body : JSON.stringify(data)
        }
        return this.fetch(url, options) 
    }


}
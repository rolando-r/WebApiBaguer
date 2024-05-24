


const opcEmpleado =
{
    "GET":() => GetEmpleado(),
    "GETBYID": (id) => GetById(id),
    "POST":(data) => PostEmpleado(data),
    "PUT":(id,data)=> UpdateEmpleado(id,data),
    "DELETE": (id) => DeleteEmpleado(id)
}

const URL_API = 'http://localhost:5000/api/Empleado';

   const Header= 
   {
       headers: new Headers
       ({
           "Content-Type" :"application/json"
       }),

   }


let GetEmpleado = async()=>
{   
    const config =
    {
        method :"GET",
        headers :Header.headers
    };
    
    

    try
    {   
        let res = await fetch(`${URL_API}`,config);

        if(res.status == 200)
        {
            console.log("Exito en la consulta");
            return await res.json()
        }
        else if(res.status == 404)
        {
            return console.log("No hay registros en la base de datos")
           
        }
        else
        {
           console.log("Error en el servidor");
           return null;
        }

    }catch(error)
    {
        console.error(error)
    }
}



let PostEmpleado = async (data) =>
{ 

    let datos = JSON.stringify(data);
    console.log(data);
    const config =
    {
        method :"POST",
        headers :Header.headers,
        body :datos
    };
    try
    {

        let res = await fetch(`${URL_API}`,config);
    
        if(res.status == 201)
        {
            console.log("Registro Exitoso");

            return await res.json();
        }
        else
        {
            return await res.json();
        }
    }catch(error)
    {
        console.error(error);
    }

}


    let DeleteEmpleado = async(id) =>
    {
           
    const config =
    {
        method :"DELETE",
        headers :Header.headers,
       
    };

        try
        {
            let response = await fetch(`${URL_API}/${id}`,config)

            if(response.status == 200)
            {
                console.log("Registro eliminado con exito");
                return response;
            }

        }catch(error)
        {
            console.error(error)
        }

    }

 let UpdateEmpleado = async (id,data) =>
 {  
    const config =
    {
        method :"PUT",
        headers :Header.headers,
       
    };
     try
     { 
        let datos = JSON.stringify(data);
        config.body = datos;
        let response = await fetch(`${URL_API}?id=${id}`,config)
    
        if(response.status == 200)  
            {
                console.log('Registro actualizado con exito');
                return response;
            }

        else
        {
            return `Error en la consulta ${response.status}`;
        }

     }catch(error)
     {
        console.log(error);
     }


   
    
 }
export 
{
    opcEmpleado

}
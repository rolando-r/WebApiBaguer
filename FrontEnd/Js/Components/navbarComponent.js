
import { EmpleadoController } from "../../Controllers/empleado-controller.js";

class NavBarContent extends HTMLElement
{
    constructor()
    {
        super();
        this.render();
        this.eventoMostrarNavBar();
        this.selectConsultasEmpleado()
        this._empleadoController = new EmpleadoController();
    }

    render = ()=>
    {
       this.innerHTML = /*html*/ `

      <div id="navEmpleado" >
          <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container-fluid">
              
              <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
                  <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                          <a class="nav-link navEmpleado "    data-hideformempleado='[["#divEmpleado","#frmRegEmpleado","#frmEmpleado"],["#listarEmpleados"]]' aria-current="page" href="#">Registrar Empleado</a>
                        </li>
                        <li class="nav-item">
                          <a class="nav-link  navEmpleado"  data-hideformempleado='[["#divEmpleado","#frmRegEmpleado","#listarEmpleados"],["#frmEmpleado"]]' href="#">Listar Empleado</a>
                        </li>
                      
                        
                        </ul>
                        <select id="selectConsultasEmpleado" class="form-select" aria-label="Default select example">
                            <option selected></option>
                            <option value="1">Mostrar Nacionalidad</option>
                        </select>
                    <form class="d-flex">
                      <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                      <button class="btn btn-outline-success" type="submit">Search</button>
                    </form>
                  </div>
            </div>
        </nav>
      </diV>
        `
    }


eventoMostrarNavBar = ()=> 
{
    
    document.querySelectorAll(".entidades").forEach((val,id)=>
    {
        val.addEventListener("click",(e)=>
        {
            let datosVerOcultar = JSON.parse(e.target.dataset.verocultar);
            console.log(datosVerOcultar[0]);
            console.log(datosVerOcultar[1]);

           datosVerOcultar[0].forEach(opcionVer =>
            {
               let datosVer = document.querySelector(opcionVer);

               datosVer.style.display ='block';

              



            })
           

            datosVerOcultar[1].forEach(opcion =>
                {
                   
                    let divOcultar = document.querySelector(opcion);
                    divOcultar.style.display = 'none';
                })
            
        })
    })
}

  selectConsultasEmpleado()
  {
    let select = document.querySelector("#selectConsultasEmpleado")
    
    select.addEventListener("change", event => 
    {
      let option = select.value
    
      switch (option) 
      {
        case "1":
          this.MostrarNacionalidad()
          break;
        default:
          console.log("sin opcion");  
          break;
      }
    })
  }
}

customElements.define('navbar-menu',NavBarContent);
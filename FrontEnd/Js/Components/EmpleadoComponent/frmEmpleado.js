import { EmpleadoController } from "../../../Controllers/empleado-controller.js";
class EmpleadoComponent extends HTMLElement
{
    constructor()
    {
        super();
        this.render();
        this.eventoMostrarEmpleadoFormularios();
        this.guardarDataOrUpdate();
        this._empleadoController = new EmpleadoController();
    }

    render = () => 
    {
        this.innerHTML= /* html */ 
        `
            <div class="card-header" id="frmRegEmpleado" style="margin: 50px; display: none;"  > 
                <form  class="row g-3" id="frmEmpleado" style="display:none" >
                <div class="col-md-4">	
                    <label for="inputState" class="form-label">Cargo</label>
                        <select id="cargoSelect" class="form-select">
                            <option selected>Selecciona...</option>
                        </select>
                    </div>
                <div class="col-md-8">
                    <label for="inputEmail4" class="form-label">Nombre</label>
                    <input type="text" class="form-control" id="nombreEmpleado" required>
                </div>
                <div class="col-md-4">
                    <label for="inputEmail4" class="form-label">Telefono</label>
                    <input type="text" class="form-control" id="telefonoEmpleado"required>
                </div>
                <div class="col-8">
                    <label for="inputAddress" class="form-label">Direccion</label>
                    <input type="text" class="form-control" id="direccionEmpleado" placeholder="1234 Main St"required>
                </div>
                <div class="col-4">
                    <label for="inputAddress2" class="form-label">Fecha Contratacion</label>
                    <input type="date" class="form-control" id="fechaContratacionEmpleado" placeholder="Apartment, studio, or floor"required>
                </div>
                <div class="col-md-4">	
                    <label for="inputState" class="form-label">Ciudad</label>
                        <select id="ciudadSelect" class="form-select">
                            <option selected>Selecciona...</option>
                    
                        </select>
                    </div>
                <div class="col-12">
                    <button type="button"  data-action="save" class="btn btn-primary" id="guardarDataEmpleado">Guardar Informacion</button>
                </div>
            </form>




            <div class="row"  id="listarEmpleados" style="display:none">
                
            </div>
        </div> 

        
        `
    } 


    eventoMostrarEmpleadoFormularios = () =>
    {
            document.querySelectorAll(".navEmpleado").forEach((val,id) =>
            {
                val.addEventListener("click",(e)=>
                {
                    let datosVerOcultar = JSON.parse(e.target.dataset.hideformempleado);
                    datosVerOcultar[0].forEach(opcion => 
                        {
                            let divVer = document.querySelector(opcion);
                            divVer.style.display ='flex';
                            console.log(divVer.style.display);
                            if(opcion.includes("listarEmpleado"))
                             {   
                                this._empleadoController.GetEmpleado();
                                this._empleadoController.DeleteEmpleado();
                             }
                             if(opcion.includes("frmEmpleado"))
                             {
                                this._empleadoController.cargaSelectEmpleado();
                             }


                        })
                    let divOcultar = document.querySelector(datosVerOcultar[1]);
                    divOcultar.style.display = 'none';
                })
            })
    }
    guardarDataOrUpdate = async () => 
    {
        let buttonFormRegEmpleado = document.querySelector("#guardarDataEmpleado");
        buttonFormRegEmpleado.addEventListener("click", (e) =>
        { 
            let datasetButtonFormRegister = buttonFormRegEmpleado.dataset.action;
            console.log(datasetButtonFormRegister);
            let frmEmpleado = document.forms['frmEmpleado'];
            let Nombre =frmEmpleado['nombreEmpleado'];
            let Telefono = frmEmpleado['telefonoEmpleado'];
            let Direccion = frmEmpleado['direccionEmpleado'];
            let FechaContratacion = frmEmpleado['fechaContratacionEmpleado'];
            let Ciudad = frmEmpleado['ciudadSelect'];
            let Cargo = frmEmpleado['cargoSelect'];
           
            let   Empleado = 
            {
               empleadoId : 0,
               nombres : Nombre.value,
               direccion : Direccion.value,
               telefono : Telefono.value,
               fechaContratacion : FechaContratacion.value,
               cargoId: parseInt(Cargo.value),
               ciudadId : parseInt(Ciudad.value)
              
            };
           if(datasetButtonFormRegister =="save")
           {
              
                this._empleadoController.PostEmpleado(Empleado);
           }
           else if(datasetButtonFormRegister =="update")
           {   
                let idDelRegistro = parseInt(buttonFormRegEmpleado.value);
                Empleado.empleadoId= idDelRegistro;
                this._empleadoController.PutEmpleado(idDelRegistro,Empleado); 
                buttonFormRegEmpleado.dataset.action="save"; 
               
           }
           buttonFormRegEmpleado.innerHTML ="Guardar Informacion";
           Nombre.value = "";           
           Apellido.value = "";
           Direccion.value = "";
           Telefono.value = "";
           FechaContratacion.value = "";
           Cargo.selectedIndex =0;
           Ciudad .selectedIndex =0;

          
       
    
        })
    
    }


}
customElements.define("frm-reglist-empleado",EmpleadoComponent);
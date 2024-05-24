import  '../Components/navbarComponent.js';
import '../Components/EmpleadoComponent/frmEmpleado.js'

if (!localStorage.getItem('token')) 
{
  window.location.href = 'index.html';
}

import '../Components/UsuarioComponent/Usuario.js'
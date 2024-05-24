using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Core.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsuariosController: ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    public UsuariosController(IUserService userService)
    {
        _userService = userService;
    }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterDto model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(LoginDto model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }


  
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleDto model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }
        private void SetRefreshTokenInCookie(string refreshToken)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(10),
                };
                Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
            }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            var entities4 = await _unitOfWork.Usuarios.GetAll();
            return _mapper.Map<List<UsuarioDto>>(entities4);
        }
        [HttpGet("Pager")]
        [Authorize]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<UsuarioDto>>> Get11([FromQuery] Params usuarioParams)
        {
            var usuario = await _unitOfWork.Usuarios.GetAllAsync(usuarioParams.PageIndex,usuarioParams.PageSize,usuarioParams.Search);
            var lstUsuariosDto = _mapper.Map<List<UsuarioDto>>(usuario.registros);
            return new Pager<UsuarioDto>(lstUsuariosDto,usuarioParams.Search,usuario.totalRegistros,usuarioParams.PageIndex,usuarioParams.PageSize);
        }
        
        [HttpPut]
    // [Authorize(Roles="")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Update(int id, [FromBody]UsuarioDto UsuarioDto)
        {
            if(UsuarioDto == null) return BadRequest();
            Usuario Usuario =  await _unitOfWork.Usuarios.GetById(id);
            _mapper.Map(UsuarioDto,Usuario);
            _unitOfWork.Usuarios.Update(Usuario);
            int numeroCambios = await _unitOfWork.SaveAsync();
            if(numeroCambios == 0 ) return BadRequest();
            return Ok("Registro actualizado con exito");
        } 
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id){
                var usuario = await _unitOfWork.Usuarios.GetById(id);
                if(usuario == null){
                    return NotFound();
                }
                _unitOfWork.Usuarios.Remove(usuario);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
}
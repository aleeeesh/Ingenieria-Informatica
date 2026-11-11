using APILogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultas.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly ArchivoContext _context;

        public UsuarioController(ArchivoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/ListadoUsuarios")]
        public IActionResult ListadoUsuarios()
        {
            try
            {
                List<UsuarioPersona> listado = new List<UsuarioPersona>();

                var query = from U in _context.Usuarios
                            join P in _context.Personas on U.IdPersona equals P.IdPersona
                            join E in _context.Estados on U.IdEstado equals E.IdEstado
                            select new
                            {
                                U.NomUsuario,
                                P.NomPersona,
                                P.ApePersona,
                                P.Edad,
                                E.NomEstado
                            };

                foreach (var item in query)
                {
                    listado.Add(new UsuarioPersona
                    {
                        NomUsuario = item.NomUsuario,
                        NombreApellido = $"{item.NomPersona} {item.ApePersona}",
                        Edad = item.Edad,
                        NomEstado = item.NomEstado
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                   new
                   {
                       exito = true,
                       mensaje = "Cargado correctamente",
                       datos = listado
                   });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        exito = false,
                        mensaje = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("api/InsertarUsuario")]
        public IActionResult InsertarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                bool existeUsuario = _context.Usuarios.Any(x => x.NomUsuario == usuario.NomUsuario);

                if (!existeUsuario)
                {
                    bool existePersona = _context.Personas.Any(x => x.IdPersona == usuario.IdPersona);

                    if (!existePersona)
                    {
                        return StatusCode(StatusCodes.Status404NotFound,
                        new
                        {
                            respuesta = "ERROR",
                            mensaje = "Persona no se encuentra en el sistema"
                        });
                    }
                    else
                    {
                        Usuario insertar = new Usuario();
                        insertar.NomUsuario = usuario.NomUsuario;
                        insertar.IdPersona = usuario.IdPersona;
                        insertar.IdEstado = usuario.IdEstado;

                        _context.Usuarios.Add(insertar);
                        _context.SaveChanges();

                        return StatusCode(StatusCodes.Status201Created,
                           new
                           {
                               exito = true,
                               mensaje = "Usuario insertado correctamente"
                           });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                    new
                    {
                        exito = false,
                        mensaje = "Usuario ya se encuentra en el sistema"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        exito = false,
                        mensaje = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("api/BuscarUsuario")]
        public IActionResult BuscarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioBuscar = _context.Usuarios.Where(u => u.NomUsuario == usuario.NomUsuario).FirstOrDefault();

                if (usuarioBuscar == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new
                        {
                            exito = false,
                            mensaje = "Usuario no se encuentra en el sistema"
                        });
                }
                else
                {
                    int estado = usuarioBuscar.IdEstado;

                    return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            exito = true,
                            mensaje = estado == 1 ? "Usuario habilitado" : "Usuario deshabilitado"
                        });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        exito = false,
                        mensaje = ex.Message
                    });
            }
        }
    }
}

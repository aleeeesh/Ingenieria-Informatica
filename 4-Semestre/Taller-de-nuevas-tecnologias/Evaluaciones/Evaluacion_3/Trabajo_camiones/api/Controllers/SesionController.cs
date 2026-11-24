using API_CAMIONES.Filtros;
using API_CAMIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CAMIONES.Controllers
{
    [Route("api/sesion")]
    [ApiController]
    public class SesionController(Evaluacion3Context context) : ControllerBase
    {
        private readonly Evaluacion3Context _context = context;
        public static Usuario? usuarioActual = null;

        [HttpGet]
        public IActionResult ObtenerSesion()
        {
            if (usuarioActual == null)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    exito = false,
                    mensaje = "No hay una sesión activa."
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                exito = true,
                usuario = usuarioActual.Usuario1,
                nombre = usuarioActual.NomPersona
            });
        }

        [HttpPost("iniciarSesion")]
        public IActionResult IniciarSesion([FromBody] ObtenerSesion usuario)
        {
            try
            {
                if (usuarioActual != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        exito = false,
                        mensaje = "Ya hay una sesión activa."
                    });
                }

                string nomUsuario = usuario.Usuario.Trim();
                string contrasena = usuario.Contrasena.Trim();

                if (string.IsNullOrWhiteSpace(nomUsuario))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar el nombre de usuario."
                    });
                }
                else if (nomUsuario.Length > 20)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "El nombre de usuario supera la longitud permitida."
                    });
                }

                if (string.IsNullOrWhiteSpace(contrasena))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar la contraseña."
                    });
                }
                else if (contrasena.Length > 20)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "La contraseña supera la longitud permitida."
                    });
                }

                var sesion = _context.Usuarios.FirstOrDefault(u => u.Usuario1 == nomUsuario && u.Password == contrasena);

                if (sesion == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Las credenciales son incorrectas."
                    });
                }

                if (sesion.IdEstado == 2) // 2 = Usuario inactivo
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Este usuario no se encuentra activo."
                    });
                }

                usuarioActual = sesion;

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = $"Bienvenido, {sesion.NomPersona}"
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

        [HttpPost("cerrarSesion")]
        public IActionResult CerrarSesion()
        {
            try
            {
                if (usuarioActual == null)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        exito = false,
                        mensaje = "No hay una sesión activa."
                    });
                }


                usuarioActual = null;

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Sesion cerrada"
                    });
            } catch (Exception ex)
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
using API_CAMIONES.Filtros;
using API_CAMIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CAMIONES.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController(Evaluacion3Context context) : ControllerBase
    {
        private readonly Evaluacion3Context _context = context;

        [HttpGet]
        public IActionResult CargarUsuarios()
        {
            List<ObtenerUsuarios> listaUsuarios = new List<ObtenerUsuarios>();

            try
            {
                var query = from u in _context.Usuarios
                            join e in _context.Estados on u.IdEstado equals e.IdEstado
                            where u.Usuario1 != "ADMIN"
                            select new
                            {
                                u.Usuario1,
                                u.NomPersona,
                                e.NomEstado
                            };


                foreach (var usuario in query)
                {
                    listaUsuarios.Add(new ObtenerUsuarios
                    {
                        Usuario = usuario.Usuario1,
                        NombreCompleto = usuario.NomPersona,
                        Estado = usuario.NomEstado
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Usuarios cargados exitosamente.",
                        datos = listaUsuarios
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
        public IActionResult RegistrarUsuario([FromBody] CrearUsuario usuario)
        {
            try
            {
                string nomUsuario = usuario.Usuario.Trim();
                string nombre = usuario.NombreCompleto.Trim();
                string contrasena = usuario.Contrasena.Trim();

                if (string.IsNullOrWhiteSpace(nomUsuario))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar el nombre de usuario."
                    });
                } else if (nomUsuario.Length > 20)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "El nombre de usuario supera la longitud permitida."
                    });
                }

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar el nombre."
                    });
                } else if (nombre.Length > 50)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "El nombre supera la longitud permitida"
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
                } else if (contrasena.Length > 20)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "La contraseña supera la longitud permitida"
                    });
                }

                var existeUsuario = _context.Usuarios.Any(u => u.Usuario1 == nomUsuario);

                if (existeUsuario)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Este usuario ya existe."
                    });
                }

                var nuevoUsuario = new Usuario
                {
                    Usuario1 = nomUsuario,
                    NomPersona = nombre,
                    Password = contrasena,
                    IdEstado = 1
                };

                _context.Usuarios.Add(nuevoUsuario);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                   new
                   {
                       exito = true,
                       mensaje = "Usuario registrado exitosamente",
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

        [HttpPut]
        public IActionResult AlternarEstado([FromBody] EstadoUsuario usuario)
        {
            try
            {
                var editarUsuario = _context.Usuarios.FirstOrDefault(u => u.Usuario1 == usuario.Usuario);

                if (editarUsuario == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Este usuario no existe."
                    });
                }

                editarUsuario.IdEstado = (editarUsuario.IdEstado == 1) ? 2 : 1; // Intercambio entre 1 = HABILITADO y 2 = DESHABILITADO

                _context.Usuarios.Update(editarUsuario);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Estado cambiado exitosamente"
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
    }
}

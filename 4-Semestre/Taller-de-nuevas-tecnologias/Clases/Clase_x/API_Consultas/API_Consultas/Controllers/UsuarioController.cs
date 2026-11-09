using APILogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultas.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        [Route("ListadoUsuarios")]
        public IActionResult ListadoUsuarios()
        {
            try
            {
                List<UsuarioPersona> listado = new List<UsuarioPersona>();
                using (var db = new ArchivoContext())
                {
                    var query = from U in db.Usuarios
                                join P in db.Personas on U.IdPersona equals P.IdPersona
                                join E in db.Estados on U.IdEstado equals E.IdEstado
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
                            Nom_estado = item.NomEstado
                        });
                    }
                }
                return StatusCode(StatusCodes.Status200OK,
                   new
                   {
                       respuesta = "OK",
                       mensaje = "Cargado correctamente",
                       lista = listado
                   });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        respuesta = "ERROR",
                        mensaje = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("InsertarUsuario")]
        public IActionResult InsertarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    bool existeUsuario = db.Usuarios.Any(x => x.NomUsuario == usuario.NomUsuario);

                    if (!existeUsuario)
                    {
                        bool existePersona = db.Personas.Any(x => x.IdPersona == usuario.IdPersona);

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

                            db.Usuarios.Add(insertar);
                            db.SaveChanges();

                            return StatusCode(StatusCodes.Status200OK,
                               new
                               {
                                   respuesta = "ERROR",
                                   mensaje = "Usuario insertado correctamente"
                               });
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status409Conflict,
                        new
                        {
                            respuesta = "ERROR",
                            mensaje = "Usuario ya se encuentra en el sistema"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        respuesta = "ERROR",
                        mensaje = ex.Message
                    });
            }
        }
    }
}

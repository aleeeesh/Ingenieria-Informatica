using APILogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace APILogin.Controllers
{
    public class UsuariosController : Controller
    {
        [HttpGet("ConsultarUsuarios")]
        public IActionResult ListadoUsuarios()
        {
            List<UsuarioPersona> listado = new List<UsuarioPersona>();

            try
            {
                using (var db = new ArchivoContext())
                {
                    var query = from u in db.Usuarios
                                join p in db.Personas on u.IdPersona equals p.IdPersona
                                join e in db.Estados on u.IdEstado equals e.IdEstado
                                select new
                                {
                                    u.NomUsuario,
                                    p.NomPersona,
                                    p.ApePersona,
                                    p.Edad,
                                    e.NomEstado
                                };

                    foreach (var item in query)
                    {
                        listado.Add(new UsuarioPersona()
                        {
                            NomUsuario = item.NomUsuario,
                            NombreCompleto = $"{item.NomPersona} {item.ApePersona}",
                            Edad = item.Edad,
                            NomEstado = item.NomEstado
                        });
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = "Cargado correctamente",
                    lista = listado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message,
                    lista = listado
                });
            }
        }

        [HttpPost("InsertarUsuario")]
        public IActionResult InsertarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var usuarioExistente = db.Usuarios.Where(u => u.NomUsuario == usuario.NomUsuario).FirstOrDefault();

                    if (usuarioExistente != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            respuesta = "Error",
                            mensaje = "Usuario ya existe"
                        });
                    } else
                    {
                        var personaExistente = db.Personas.Where(p => p.IdPersona == usuario.IdPersona).FirstOrDefault();

                        if (personaExistente == null)
                        {
                            return StatusCode(StatusCodes.Status200OK, new
                            {
                                respuesta = "Error",
                                mensaje = "Persona no encontrada"
                            });
                        } else
                        {
                            db.Usuarios.Add(new Usuario()
                            {
                                NomUsuario = usuario.NomUsuario,
                                IdPersona = usuario.IdPersona,
                            });

                            db.SaveChanges();

                            return StatusCode(StatusCodes.Status200OK, new
                            {
                                respuesta = "OK",
                                mensaje = "Usuario insertado correctamente"
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message
                });
            }
        }

        [HttpPut("EditarUsuario")]
        public IActionResult EditarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var usuarioExistente = db.Usuarios.Where(p => p.NomUsuario == usuario.NomUsuario).FirstOrDefault();

                    if (usuarioExistente == null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            respuesta = "Error",
                            mensaje = "Usuario no encontrado"
                        });
                    }
                    else
                    {
                        usuarioExistente.NomUsuario = usuario.NomUsuario;
                        usuarioExistente.IdPersona = usuario.IdPersona;
                        usuarioExistente.IdEstado = usuario.IdEstado;

                        db.SaveChanges();

                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            respuesta = "OK",
                            mensaje = "Persona actualizada correctamente"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message
                });
            }
        }

        [HttpDelete("EliminarUsuario")]
        public IActionResult EliminarPersona(string NomUsuario)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var usuarioExistente = db.Usuarios.Where(p => p.NomUsuario == NomUsuario).FirstOrDefault();

                    if (usuarioExistente == null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            respuesta = "Error",
                            mensaje = "Usuario no encontrado"
                        });
                    }
                    else
                    {
                        db.Usuarios.Remove(usuarioExistente);
                        db.SaveChanges();

                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            respuesta = "OK",
                            mensaje = "Eliminado correctamente"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message
                });
            }
        }
    }
}

using APILogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultas.Controllers
{
     public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("ListadoPersonas")]
        public IActionResult ListadoPersonas()
        {
            List<Persona> listado = new List<Persona>();
            try
            {
                using (var db = new ArchivoContext())
                {
                    var consulta = db.Personas.ToList();

                    foreach (var item in consulta)
                    {
                        listado.Add(new Persona()
                        {
                            IdPersona = item.IdPersona,
                            NomPersona = item.NomPersona,
                            ApePersona = item.ApePersona,
                            Edad = item.Edad
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
                        mensaje = ex.Message,
                        lista = listado
                    });
            }
        }

        [HttpPost]
        [Route("InsertarPersona")]
        public IActionResult InsertarPersona([FromBody] Persona persona)
        {
            try
            {

                using (var db = new ArchivoContext())
                {
                    Persona insertar = new Persona();
                    insertar.NomPersona = persona.NomPersona;
                    insertar.ApePersona = persona.ApePersona;
                    insertar.Edad = persona.Edad;

                    db.Personas.Add(insertar);
                    db.SaveChanges();
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        respuesta = "OK",
                        mensaje = "Insertado correctamente"
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
        [Route("EditarPersona")]
        public IActionResult EditarPersona([FromBody] Persona persona)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var contador = db.Personas.Where(x => x.IdPersona == persona.IdPersona);
                    if (contador.Count() == 0)
                    {
                        //no existe
                        return StatusCode(StatusCodes.Status200OK,
                           new
                           {
                               respuesta = "ERROR",
                               mensaje = "Persona no se encuentra"
                           });
                    }
                    else
                    {
                        contador.First().NomPersona = persona.NomPersona;
                        contador.First().ApePersona = persona.ApePersona;
                        contador.First().Edad = persona.Edad;

                        db.SaveChanges();
                        return StatusCode(StatusCodes.Status200OK,
                           new
                           {
                               respuesta = "OK",
                               mensaje = "Editado correctamente"
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

        [HttpDelete]
        [Route("EliminarPersona")]
        public IActionResult EliminarPersona([FromBody] Persona persona)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var contador = db.Personas.Where(x => x.IdPersona == persona.IdPersona);
                    if (contador.Count() == 0)
                    {
                        //no existe
                        return StatusCode(StatusCodes.Status200OK,
                           new
                           {
                               respuesta = "ERROR",
                               mensaje = "Persona no se encuentra"
                           });
                    }
                    else
                    {
                        db.Personas.Remove(contador.First());
                        db.SaveChanges();
                        return StatusCode(StatusCodes.Status200OK,
                           new
                           {
                               respuesta = "OK",
                               mensaje = "Persona eliminada correctamente"
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

        [HttpPost]
        [Route("InsertarUsuario")]
        public IActionResult InsertarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var existeUsr = db.Usuarios.Where(x => x.NomUsuario == usuario.NomUsuario);
                    if (existeUsr.Count() == 0)//insertar nuevo
                    {
                        var existePer = db.Personas.Where(x => x.IdPersona == x.IdPersona);
                        if (existePer.Count() == 0)//no existe la persona
                        {
                            return StatusCode(StatusCodes.Status200OK,
                            new
                            {
                                respuesta = "ERROR",
                                mensaje = "Persona no se encuentra en el sistema"
                            });
                        }
                        else
                        {
                            //insertamos usuario
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
                        return StatusCode(StatusCodes.Status200OK,
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

        [HttpGet]
        [Route("ListadoUsuario")]
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
                            NombreApellido = item.NomPersona + " " + item.ApePersona,
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
    }
}
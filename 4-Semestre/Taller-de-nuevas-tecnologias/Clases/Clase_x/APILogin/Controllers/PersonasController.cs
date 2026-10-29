using Microsoft.AspNetCore.Mvc;
using APILogin.Models;


namespace APILogin.Controllers
{
    public class PersonasController : Controller
    {
        [HttpGet("ConsultarPersonas")]
        public IActionResult ListadoPersonas()
        {
            List<Persona> listado = new List<Persona>();

            try
            {
                using(var db = new ArchivoContext())
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
                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = "Cargado correctamente",
                    lista = listado
                });
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message,
                    lista = listado
                });
            }
        }

        [HttpPost("InsertarPersona")]
        public IActionResult InsertarPersona([FromBody] Persona persona)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    db.Personas.Add(new Persona()
                    {
                        NomPersona = persona.NomPersona,
                        ApePersona = persona.ApePersona,
                        Edad = persona.Edad
                    });

                    db.SaveChanges();
                }

                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = "Persona insertada correctamente"
                });
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

        [HttpPut("EditarPersona")]
        public IActionResult EditarPersona(int IdPersona,  [FromBody] Persona persona)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var personaExistente = db.Personas.Where(p => p.IdPersona == IdPersona).FirstOrDefault();

                    if (personaExistente == null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            respuesta = "Error",
                            mensaje = "Persona no encontrada"
                        });
                    } else
                    {
                        personaExistente.NomPersona = persona.NomPersona;
                        personaExistente.ApePersona = persona.ApePersona;
                        personaExistente.Edad = persona.Edad;

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

        [HttpDelete("EliminarPersona")]
        public IActionResult EliminarPersona(int idPersona)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var personaExistente = db.Personas.Where(p => p.IdPersona == idPersona).FirstOrDefault();

                    if (personaExistente == null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            respuesta = "Error",
                            mensaje = "Persona no encontrada"
                        });
                    } else
                    {
                        db.Personas.Remove(personaExistente);
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

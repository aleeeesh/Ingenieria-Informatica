using APILogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultas.Controllers
{
     public class PersonaController : ControllerBase
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

                return StatusCode(StatusCodes.Status201Created,
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

        [HttpPut]
        [Route("EditarPersona")]
        public IActionResult EditarPersona([FromBody] Persona persona)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var persona_ = db.Personas.FirstOrDefault(x => x.IdPersona == persona.IdPersona);

                    if (persona_ == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound,
                           new
                           {
                               respuesta = "ERROR",
                               mensaje = "Persona no se encuentra"
                           });
                    }
                    else
                    {
                        persona_.NomPersona = persona.NomPersona;
                        persona_.ApePersona = persona.ApePersona;
                        persona_.Edad = persona.Edad;

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
                    var persona_ = db.Personas.FirstOrDefault(x => x.IdPersona == persona.IdPersona);

                    if (persona_ == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound,
                           new
                           {
                               respuesta = "ERROR",
                               mensaje = "Persona no se encuentra"
                           });
                    }
                    else
                    {
                        db.Personas.Remove(persona_);
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
    }
}
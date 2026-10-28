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
                    mensaje = $"Persona insertada correctamente"
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
                    var consulta = db.Personas.Where(p => p.IdPersona == IdPersona).First();

                    consulta.NomPersona = persona.NomPersona;
                    consulta.ApePersona = persona.ApePersona;
                    consulta.Edad = persona.Edad;

                    db.SaveChanges();
                }

                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = $"Persona actualizada correctamente"
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

        [HttpDelete("EliminarPersona")]
        public IActionResult EliminarPersona(int idPersona)
        {
            try
            {
                using (var db = new ArchivoContext())
                {
                    var consulta = db.Personas.Where(p => p.IdPersona == idPersona).First();
                    
                    db.Personas.Remove(consulta);
                    db.SaveChanges();
                }

                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = "eliminado correctamente"
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
    }
}

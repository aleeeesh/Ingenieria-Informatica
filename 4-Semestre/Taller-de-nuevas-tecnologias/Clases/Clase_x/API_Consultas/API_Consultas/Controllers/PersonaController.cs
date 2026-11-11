using APILogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultas.Controllers
{
     public class PersonaController : ControllerBase
    {
        private readonly ArchivoContext _context;

        public PersonaController(ArchivoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/ListadoPersonas")]
        public IActionResult ListadoPersonas()
        {
            List<Persona> listado = new List<Persona>();
            try
            {
                var consulta = _context.Personas.ToList();

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
        [Route("api/InsertarPersona")]
        public IActionResult InsertarPersona([FromBody] Persona persona)
        {
            try
            {

                Persona insertar = new Persona();
                insertar.NomPersona = persona.NomPersona;
                insertar.ApePersona = persona.ApePersona;
                insertar.Edad = persona.Edad;

                _context.Personas.Add(insertar);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created,
                    new
                    {
                        exito = true,
                        mensaje = "Insertado correctamente"
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
        [Route("api/EditarPersona")]
        public IActionResult EditarPersona([FromBody] Persona persona)
        {
            try
            {
                var persona_ = _context.Personas.FirstOrDefault(x => x.IdPersona == persona.IdPersona);

                if (persona_ == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                       new
                       {
                           exito = false,
                           mensaje = "Persona no encontrada"
                       });
                }
                else
                {
                    persona_.NomPersona = persona.NomPersona;
                    persona_.ApePersona = persona.ApePersona;
                    persona_.Edad = persona.Edad;

                    _context.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK,
                       new
                       {
                           exito = true,
                           mensaje = $"Persona ID #{persona_.IdPersona} editada correctamente"
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

        [HttpDelete]
        [Route("api/EliminarPersona")]
        public IActionResult EliminarPersona([FromBody] Persona persona)
        {
            try
            {
                var persona_ = _context.Personas.FirstOrDefault(x => x.IdPersona == persona.IdPersona);

                if (persona_ == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                       new
                       {
                           exito = false,
                           mensaje = "Persona no se encuentra"
                       });
                }
                else
                {
                    _context.Personas.Remove(persona_);
                    _context.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK,
                       new
                       {
                           exito = true,
                           mensaje = "Persona eliminada correctamente"
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
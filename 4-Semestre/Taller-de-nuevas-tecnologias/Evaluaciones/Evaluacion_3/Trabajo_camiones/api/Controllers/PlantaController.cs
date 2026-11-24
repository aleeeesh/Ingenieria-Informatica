using API_CAMIONES.Filtros;
using API_CAMIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CAMIONES.Controllers
{
    [Route("api/plantas")]
    [ApiController]
    public class PlantaController(Evaluacion3Context context) : ControllerBase
    {
        private readonly Evaluacion3Context _context = context;

        [HttpGet]
        public IActionResult CargarPlantas()
        {
            List<ObtenerPlantas> listaPlantas = new List<ObtenerPlantas>();

            try
            {
                var query = from c in _context.Planta
                            select new
                            {
                                c.IdPlanta,
                                c.NomPlanta
                            };


                foreach (var planta in query)
                {
                    listaPlantas.Add(new ObtenerPlantas
                    {
                        IdPlanta = planta.IdPlanta,
                        Nombre = planta.NomPlanta
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Plantas cargadas exitosamente",
                        datos = listaPlantas
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
        public IActionResult RegistrarPlanta([FromBody] CreaPlanta planta)
        {
            try
            {
                string nombre = planta.Nombre.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar el nombre de la planta."
                    });
                } else if (nombre.Length > 50)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "El nombre de la planta supera la longitud permitida."
                    });
                }

                var nuevaPlanta = new Plantum
                {
                    NomPlanta = planta.Nombre
                };

                _context.Planta.Add(nuevaPlanta);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Planta registrada exitosamente"
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

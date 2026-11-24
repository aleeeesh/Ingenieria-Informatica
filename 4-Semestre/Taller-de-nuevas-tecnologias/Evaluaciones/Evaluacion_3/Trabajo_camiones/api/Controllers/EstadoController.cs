using API_CAMIONES.Filtros;
using API_CAMIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CAMIONES.Controllers
{
    [Route("api/estados")]
    [ApiController]
    public class EstadoController(Evaluacion3Context context) : ControllerBase
    {
        private readonly Evaluacion3Context _context = context;

        [HttpGet]
        public IActionResult CargarEstados()
        {
            List<ObtenerEstados> listaEstados = new List<ObtenerEstados>();
            try
            {
                var query = from e in _context.Estados
                            select new
                            {
                                e.IdEstado,
                                e.NomEstado
                            };


                foreach (var estado in query)
                {
                    listaEstados.Add(new ObtenerEstados
                    {
                        IdEstado = estado.IdEstado,
                        Nombre = estado.NomEstado
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Estados cargados exitosamente",
                        datos = listaEstados
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

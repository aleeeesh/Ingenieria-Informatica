/*using APILogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultas.Controllers
{
    public class EstadoController : ControllerBase
    {
        [HttpGet]
        [Route("ListadoEstados")]
        public IActionResult ListadoEstados()
        {
            List<Estado> listado = new List<Estado>();
            try
            {
                using (var db = new ArchivoContext())
                {
                    var consulta = db.Estados.ToList();

                    foreach (var item in consulta)
                    {
                        listado.Add(new Estado()
                        {
                            IdEstado = item.IdEstado,
                            NomEstado = item.NomEstado,
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
    }
}*/
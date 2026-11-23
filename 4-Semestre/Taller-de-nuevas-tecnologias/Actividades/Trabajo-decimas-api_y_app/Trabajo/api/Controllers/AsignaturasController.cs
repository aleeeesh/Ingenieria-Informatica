using API_NOTAS.DTOs;
using API_NOTAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_NOTAS.Controllers
{
    [Route("api/asignaturas")]
    [ApiController]
    public class AsignaturasController : ControllerBase
    {
        private readonly AlumnosContext _context;

        public AsignaturasController(AlumnosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListadoAsignaturas()
        {
            List<AsignaturaDTO> listado = new List<AsignaturaDTO>();

            try
            {
                var asignaturas = _context.Asignaturas.ToList();

                foreach (var asignatura in asignaturas)
                {
                    listado.Add(new AsignaturaDTO()
                    {
                        idAsignatura = asignatura.IdAsignatura,
                        nombre = asignatura.NomAsignatura
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
        public IActionResult InsertarAsignatura([FromBody] CrearAsignaturaDTO asignatura)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(asignatura.nombre))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Ingrese el nombre de la asignatura"
                    });
                }

                Asignatura nuevaAsignatura = new Asignatura
                {
                    NomAsignatura = asignatura.nombre
                };

                _context.Asignaturas.Add(nuevaAsignatura);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Asignatura insertada correctamente",
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

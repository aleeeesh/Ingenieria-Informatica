using API_NOTAS.Models;
using API_NOTAS.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_NOTAS.Controllers
{
    [Route("api/alumnos")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnosContext _context;

        public AlumnosController(AlumnosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListadoAlumnos()
        {
            List<AlumnoDTO> listado = new List<AlumnoDTO>();

            try
            {
                var alumnos = _context.Alumnos.ToList();

                foreach (var alumno in alumnos)
                {
                    listado.Add(new AlumnoDTO()
                    {
                        idAlumno = alumno.CodAlumno,
                        nombres = alumno.Nombres,
                        apellidos = alumno.Apellidos
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
        public IActionResult InsertarAlumno([FromBody] AlumnoDTO alumno)
        {
            try
            {
                if (alumno.idAlumno < 0) {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Ingrese un ID válido",
                    });
                }

                var alumnoExiste = _context.Alumnos.Any(a => a.CodAlumno == alumno.idAlumno);

                if (alumnoExiste)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Ya existe un alumno con esa ID",
                    });
                }

                if (string.IsNullOrWhiteSpace(alumno.nombres))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Ingrese los nombres del alumno",
                    });
                }

                if (string.IsNullOrWhiteSpace(alumno.apellidos))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Ingrese los apellidos del alumno",
                    });
                }

                Alumno nuevoAlumno = new Alumno
                {
                    CodAlumno = alumno.idAlumno,
                    Nombres = alumno.nombres,
                    Apellidos = alumno.apellidos
                };

                _context.Alumnos.Add(nuevoAlumno);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Alumno insertado correctamente",
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

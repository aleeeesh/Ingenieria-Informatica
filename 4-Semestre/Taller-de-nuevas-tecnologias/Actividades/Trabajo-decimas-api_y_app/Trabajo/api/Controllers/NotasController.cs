using API_NOTAS.DTOs;
using API_NOTAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_NOTAS.Controllers
{
    [Route("api/notas")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly AlumnosContext _context;

        public NotasController(AlumnosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListadoNotas()
        {
            List<NotaDTO> listado = new List<NotaDTO>();

            try
            {
                var notas = _context.Notas.ToList();

                foreach (var nota in notas)
                {
                    listado.Add(new NotaDTO()
                    {
                        nota = nota.Nota1,
                        numNota = nota.NNota,
                        idAlumno = nota.CodAlumno,
                        idAsignatura = nota.IdAsignatura
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
        public IActionResult InsertarNota([FromBody] NotaDTO nota)
        {
            try
            {
                if (nota.nota < 1 || nota.nota > 7)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Nota fuera del rango permitido"
                    });
                }
               
                if (nota.numNota < 1 || nota.numNota > 3)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "N° de nota fuera del rango permitido"
                    });
                }

                var existeAlumno = _context.Alumnos.Any(a => a.CodAlumno == nota.idAlumno);

                if (!existeAlumno)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Alumno no encontrado"
                    });
                }

                var existeAsignatura = _context.Asignaturas.Any(a => a.IdAsignatura == nota.idAsignatura);

                if (!existeAsignatura)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Asignatura no encontrada"
                    });
                }

                var existeNota = _context.Notas.Any(n => n.CodAlumno == nota.idAlumno && n.IdAsignatura == nota.idAsignatura && n.NNota == nota.numNota);

                if (existeNota)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "La nota ingresada ya existe"
                    });
                }

                Nota nuevaNota = new Nota
                {
                    Nota1 = nota.nota,
                    NNota = nota.numNota,
                    CodAlumno = nota.idAlumno,
                    IdAsignatura = nota.idAsignatura
                };

                _context.Notas.Add(nuevaNota);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Nota insertada correctamente",
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
        public IActionResult EditarNota([FromBody] NotaDTO nota)
        {
            try
            {
                if (nota.nota < 1 || nota.nota > 7)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Nota fuera del rango permitido"
                    });
                }

                if (nota.numNota < 1 || nota.numNota > 3)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "N° de nota fuera del rango permitido"
                    });
                }

                var existeNota = _context.Notas.FirstOrDefault(n => n.CodAlumno == nota.idAlumno && n.IdAsignatura == nota.idAsignatura && n.NNota == nota.numNota);

                if (existeNota == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "La nota ingresada no existe"
                    });
                }

                existeNota.Nota1 = nota.nota;

                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Nota actualizada correctamente",
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
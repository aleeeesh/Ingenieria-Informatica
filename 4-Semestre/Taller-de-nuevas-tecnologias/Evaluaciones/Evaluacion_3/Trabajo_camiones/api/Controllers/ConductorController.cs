using API_CAMIONES.Filtros;
using API_CAMIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CAMIONES.Controllers
{
    [Route("api/conductores")]
    [ApiController]
    public class ConductorController(Evaluacion3Context context) : ControllerBase
    {
        private readonly Evaluacion3Context _context = context;

        [HttpGet]
        public IActionResult CargarConductores()
        {
            List<ObtenerConductores> listaConductores = new List<ObtenerConductores>();

            try
            {
                var query = from c in _context.Chofers
                            join e in _context.Estados on c.IdEstado equals e.IdEstado
                            select new
                            {
                                c.IdChofer,
                                c.NomChofer,
                                e.NomEstado
                            };


                foreach (var conductor in query)
                {
                    listaConductores.Add(new ObtenerConductores
                    {
                        IdConductor = conductor.IdChofer,
                        NombreCompleto = conductor.NomChofer,
                        Estado = conductor.NomEstado
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Conductores cargados exitosamente",
                        datos = listaConductores
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

        [HttpGet("filtrarConductores")]
        public IActionResult FiltrarConductores()
        {
            List<ObtenerConductores> listaConductores = new List<ObtenerConductores>();

            try
            {
                var query = from c in _context.Chofers
                            join e in _context.Estados on c.IdEstado equals e.IdEstado
                            join s in _context.Salida.Where(x => x.IdEstadoSalida == 1)
                                on c.IdChofer equals s.IdChofer into grp
                            from sa in grp.DefaultIfEmpty()
                            where c.IdEstado == 1 && sa == null
                            select new
                            {
                                c.IdChofer,
                                c.NomChofer,
                                e.NomEstado
                            };


                foreach (var conductor in query)
                {
                    listaConductores.Add(new ObtenerConductores
                    {
                        IdConductor = conductor.IdChofer,
                        NombreCompleto = conductor.NomChofer,
                        Estado = conductor.NomEstado
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Conductores filtrados exitosamente",
                        datos = listaConductores
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
        public IActionResult RegistrarConductor([FromBody] CrearConductor conductor)
        {
            try
            {
                string nombre = conductor.NombreCompleto.Trim();
                int idEstado = conductor.IdEstado;

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar el nombre del conductor."
                    });
                } else if (nombre.Length > 50)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "El nombre del conductor supera la longitud permitida"
                    });
                }

                if (idEstado != 1 && idEstado != 2)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar un estado válido"
                    });
                }

                var nuevoConductor = new Chofer
                {
                    NomChofer = conductor.NombreCompleto,
                    IdEstado = conductor.IdEstado
                };

                _context.Chofers.Add(nuevoConductor);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Conductor registrado exitosamente"
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
        public IActionResult AlternarEstado([FromBody] EstadoConductor conductor)
        {
            try
            {
                var editarConductor = _context.Chofers.FirstOrDefault(c => c.IdChofer == conductor.IdConductor);

                if (editarConductor == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Este conductor no existe."
                    });
                }

                editarConductor.IdEstado = (editarConductor.IdEstado == 1) ? 2 : 1; // Intercambio entre 1 = HABILITADO y 2 = DESHABILITADO

                _context.Chofers.Update(editarConductor);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Estado cambiado exitosamente"
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

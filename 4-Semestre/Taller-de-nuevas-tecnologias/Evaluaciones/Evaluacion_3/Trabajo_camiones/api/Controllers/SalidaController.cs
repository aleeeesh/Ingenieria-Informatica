using API_CAMIONES.Filtros;
using API_CAMIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CAMIONES.Controllers
{
    [Route("api/salidas")]
    [ApiController]
    public class SalidaController(Evaluacion3Context context) : ControllerBase
    {
        private readonly Evaluacion3Context _context = context;

        [HttpGet]
        public IActionResult CargarSalidas()
        {
            List<ObtenerSalidas> listaSalidas = new List<ObtenerSalidas>();

            try
            {
                var query = from u in _context.Usuarios
                            join s in _context.Salida on u.Usuario1 equals s.Usuario
                            join c in _context.Camions on s.CodCamion equals c.CodCamion
                            join p in _context.Planta on c.IdPlanta equals p.IdPlanta
                            join cf in _context.Chofers on s.IdChofer equals cf.IdChofer
                            join e in _context.EstadoSalida on s.IdEstadoSalida equals e.IdEstadoSalida
                            select new
                            {
                                s.IdSalida,
                                s.FechaSalida,
                                p.NomPlanta,
                                c.CodCamion,
                                cf.NomChofer,
                                e.NomEstadoSalida,
                                u.NomPersona
                            };


                foreach (var salida in query)
                {
                    listaSalidas.Add(new ObtenerSalidas
                    {
                        IdSalida = salida.IdSalida,
                        Fecha = salida.FechaSalida,
                        Planta = salida.NomPlanta,
                        Camion = salida.CodCamion,
                        Conductor = salida.NomChofer,
                        Estado = salida.NomEstadoSalida,
                        Usuario = salida.NomPersona
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Salidas cargadas exitosamente",
                        datos = listaSalidas
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
        public IActionResult RegistrarSalida([FromBody] RegistrarSalida salida)
        {
            try
            {
                DateOnly fecha = salida.Fecha;
                int idPlanta = salida.IdPlanta;
                string codCamion = salida.Camion.Trim();
                int idConductor = salida.IdConductor;

                if (SesionController.usuarioActual == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            exito = false,
                            mensaje = "Debes iniciar sesión."
                        });
                }

                if (fecha == default)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            exito = false,
                            mensaje = "Debes ingresar la fecha de salida."
                        });
                }

                if (idPlanta <= 0)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            exito = false,
                            mensaje = "Debes ingresar la planta."
                        });
                }

                if (string.IsNullOrWhiteSpace(salida.Camion))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            exito = false,
                            mensaje = "Debes ingresar el código del camión."
                        });
                }

                if (idConductor <= 0)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            exito = false,
                            mensaje = "Debes ingresar el conductor."
                        });
                }

                var camion = _context.Camions.FirstOrDefault(c => c.CodCamion == codCamion);

                if (camion == null || camion.IdEstado == 2)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        exito = false,
                        mensaje = "Este camión no existe o se encuentra inactivo."
                    });
                }

                var conductor = _context.Chofers.FirstOrDefault(c => c.IdChofer == idConductor);
                if (conductor == null || conductor.IdEstado == 2)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        exito = false,
                        mensaje = "Este conductor no existe o se encuentra inactivo."
                    });
                }   

                var nuevaSalida = new Salidum
                {
                    FechaSalida = fecha,
                    IdPlanta = idPlanta,
                    CodCamion = codCamion,
                    IdChofer = idConductor,
                    IdEstadoSalida = 1,
                    Usuario = SesionController.usuarioActual.Usuario1
                };

                _context.Salida.Add(nuevaSalida);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Salida registrada exitosamente"
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
        public IActionResult Retornar([FromBody] RetornarSalida salida)
        {
            try
            {
                int idSalida = salida.IdSalida;

                if (idSalida <= 0)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar el Id de Salida."
                    });
                }

                var estadoSalida = _context.Salida.FirstOrDefault(s => s.IdSalida == idSalida);

                if (estadoSalida == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "No existe esta salida."
                    });
                }

                if (estadoSalida.IdEstadoSalida != 1)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            exito = false,
                            mensaje = "Solo puedes retornar salidas en estado EN RUTA."
                        });
                }

             

                estadoSalida.IdEstadoSalida = 2;

                _context.Salida.Update(estadoSalida);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Salida retornada exitosamente"
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

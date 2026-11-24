using API_CAMIONES.Filtros;
using API_CAMIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CAMIONES.Controllers
{
    [Route("api/camiones")]
    [ApiController]
    public class CamionController(Evaluacion3Context context) : ControllerBase
    {
        private readonly Evaluacion3Context _context = context;

        [HttpGet]
        public IActionResult CargarCamiones()
        {
            List<ObtenerCamiones> listaCamiones = new List<ObtenerCamiones>();

            try
            {
                var query = from c in _context.Camions
                            join e in _context.Estados on c.IdEstado equals e.IdEstado
                            join p in _context.Planta on c.IdPlanta equals p.IdPlanta
                            select new
                            {
                                c.CodCamion,
                                p.NomPlanta,
                                e.NomEstado
                            };


                foreach (var camion in query)
                {
                    listaCamiones.Add(new ObtenerCamiones
                    {
                        CodCamion = camion.CodCamion,
                        Planta = camion.NomPlanta,
                        Estado = camion.NomEstado
                    });
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Camiones cargados exitosamente",
                        datos = listaCamiones
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

        [HttpPost("filtrarCamiones")]
        public IActionResult FiltrarCamiones([FromBody] CamionPlanta camion)
        {
            List<ObtenerCamiones> listaCamiones = new List<ObtenerCamiones>();

            try
            {
                var query = from c in _context.Camions
                            join e in _context.Estados on c.IdEstado equals e.IdEstado
                            join p in _context.Planta on c.IdPlanta equals p.IdPlanta
                            join s in _context.Salida.Where(x => x.IdEstadoSalida == 1)
                                on c.CodCamion equals s.CodCamion into grp
                            from sa in grp.DefaultIfEmpty()
                            where c.IdEstado == 1 && c.IdPlanta == camion.IdPlanta && sa == null
                            select new
                            {
                                c.CodCamion,
                                p.NomPlanta,
                                e.NomEstado
                            };


                foreach (var _camion in query)
                {
                    var camionesEnRuta = _context.Salida.FirstOrDefault(s => s.CodCamion == _camion.CodCamion && s.IdEstadoSalida == 1);

                    if (camionesEnRuta == null)
                    {
                        listaCamiones.Add(new ObtenerCamiones
                        {
                            CodCamion = _camion.CodCamion,
                            Planta = _camion.NomPlanta,
                            Estado = _camion.NomEstado
                        });
                    }
                }

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Camiones filtrados exitosamente",
                        datos = listaCamiones
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
        public IActionResult RegistrarCamion([FromBody] CrearCamion camion)
        {
            try
            {
                string codCamion = camion.CodCamion;
                int idPlanta = camion.IdPlanta;
                int idEstado = camion.IdEstado;

                if (string.IsNullOrWhiteSpace(codCamion))
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar el código del camión."
                    });
                }
                else if (codCamion.Length > 10)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "El código supera la longitud permitida."
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

                if (idEstado != 1 && idEstado != 2)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Debes ingresar un estado válido."
                    });
                }

                var camionExiste = _context.Camions.FirstOrDefault(c => c.CodCamion == camion.CodCamion);

                if (camionExiste != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Este camión ya existe."
                    });
                }

                var nuevoCamion = new Camion
                {
                    CodCamion = camion.CodCamion,
                    IdPlanta = camion.IdPlanta,
                    IdEstado = camion.IdEstado
                };

                _context.Camions.Add(nuevoCamion);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = true,
                        mensaje = "Camión registrado exitosamente"
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
        public IActionResult AlternarEstado([FromBody] EstadoCamion camion)
        {
            try
            {
                var editarCamion = _context.Camions.FirstOrDefault(c => c.CodCamion == camion.CodCamion);

                if (editarCamion == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        exito = false,
                        mensaje = "Este código no existe."
                    });
                }

                editarCamion.IdEstado = (editarCamion.IdEstado == 1) ? 2 : 1; // Intercambio entre 1 = HABILITADO y 2 = DESHABILITADO

                _context.Camions.Update(editarCamion);
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

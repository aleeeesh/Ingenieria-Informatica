using Microsoft.AspNetCore.Mvc;

namespace APILogin.Controllers
{
    public class PersonasController : Controller
    {
        [HttpGet("personas")]
        public IActionResult ListadoPersonas()
        {
            List<string> listado = new List<string>();

            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = "Cargado correctamente",
                    lista = listado
                });
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message,
                    lista = listado
                });
            }
        }

        public class Per
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int edad { get; set; }
        }


        [HttpPost("insertarPersona")]
        public IActionResult insertarPersona([FromBody] Per persona)
        {
            var nombreCompleto = $"{persona.nombre} {persona.apellido}";
            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = $"insertado correctamente: {nombreCompleto}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message
                });
            }
        }

        /*[HttpDelete("eliminarPersona")]
        public IActionResult eliminarPersona(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = "eliminado correctamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message
                });
            }
        }

        [HttpDelete("eliminarPersona")]
        public IActionResult eliminarPersona(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    respuesta = "OK",
                    mensaje = "eliminado correctamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    respuesta = "Error",
                    mensaje = ex.Message
                });
            }
        }*/
    }
}

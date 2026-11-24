package cl.virginiogomez.app_camiones.clases

data class RegistrarSalida(
    val fecha: String,
    val idPlanta: Int,
    val camion: String,
    val idConductor: Int
)

data class ObtenerSalidas(
    val idSalida: Int,
    val fecha: String,
    val planta: String,
    val camion: String,
    val conductor: String,
    val idEstado: Int,
    val estado: String,
    val usuario: String
)

data class RetornarSalida(
    val idSalida: Int
)

data class DatosSalida(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<ObtenerSalidas>
)
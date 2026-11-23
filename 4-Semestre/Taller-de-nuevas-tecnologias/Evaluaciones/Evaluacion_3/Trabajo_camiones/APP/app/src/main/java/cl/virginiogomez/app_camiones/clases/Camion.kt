package cl.virginiogomez.app_camiones.clases

data class Camion(
    val patente: String,
    val idPlanta: Int,
    val idEstado: Int
)

data class CamionPlanta(
    val idPlanta: Int
)

data class CambiarEstadoCamion(
    val patente: String,
    val idEstado: Int
)

data class DatosCamion(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<Camion>
)
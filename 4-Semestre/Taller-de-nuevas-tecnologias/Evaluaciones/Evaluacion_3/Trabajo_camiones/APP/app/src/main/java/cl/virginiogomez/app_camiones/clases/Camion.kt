package cl.virginiogomez.app_camiones.clases

data class CrearCamion(
    val codCamion: String,
    val idPlanta: Int,
    val idEstado: Int
)
data class ObtenerCamiones(
    val codCamion: String,
    val planta: String,
    val estado: String
) {
    override fun toString(): String = codCamion
}

data class CamionPlanta(
    val idPlanta: Int
)

data class EstadoCamion(
    val codCamion: String
)

data class DatosCamion(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<ObtenerCamiones>
)
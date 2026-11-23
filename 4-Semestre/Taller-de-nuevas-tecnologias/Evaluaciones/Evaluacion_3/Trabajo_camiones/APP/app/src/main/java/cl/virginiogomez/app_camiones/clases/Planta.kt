package cl.virginiogomez.app_camiones.clases

data class Planta(
    val idPlanta: Int,
    val nombre: String
)

data class RegistrarPlanta(
    val nombre: String
)

data class DatosPlanta(
    val exito: Boolean,
    val mensaje: String,
    val datos: List<Planta>
)
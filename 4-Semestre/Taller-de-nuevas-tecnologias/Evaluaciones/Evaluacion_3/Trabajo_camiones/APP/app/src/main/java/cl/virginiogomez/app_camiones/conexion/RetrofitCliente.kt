package cl.virginiogomez.app_camiones.conexion

import cl.virginiogomez.app_camiones.interfaz.Endpoints
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitCliente {
    const val DIRECCION = "192.168.1.15"
    const val PUERTO = "5017"

    val api: Endpoints = Retrofit.Builder()
        .baseUrl("http://$DIRECCION:$PUERTO/api/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Endpoints::class.java)
}
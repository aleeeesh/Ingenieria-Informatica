package com.josue.apilogin.conexion

import com.josue.apilogin.interfaz.Funciones
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitCliente {
    val direccion = ""
    val puerto = "5004"

    val ruta = Retrofit.Builder()
        .baseUrl("http://$direccion:$puerto/ListadoPersonas/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Funciones::class.java)
}
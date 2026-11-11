package com.alumnos.composeapi.conexion

import com.alumnos.composeapi.interfaz.Funciones
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitCliente {
    var DIRECCION: String = "192.168.56.1"
    private const val PUERTO = "5017"

    var api: Funciones = Retrofit.Builder()
        .baseUrl("http://$DIRECCION:$PUERTO/api/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Funciones::class.java)
}
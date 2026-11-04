package com.josue.apilogin.conexion

import com.josue.apilogin.interfaz.Funciones
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitCliente {
    val direccion = "192.168.56.1"
    val puerto = "5017"

    val ruta = Retrofit.Builder()
        .baseUrl("http://$direccion:$puerto/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Funciones::class.java)
}
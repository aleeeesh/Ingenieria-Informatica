package com.example.appeditarnotas.conexion

import com.example.appeditarnotas.interfaz.Funciones
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitCliente {
    const val DIRECCION = "192.168.56.1"
    const val PUERTO = "5017"

    val api: Funciones = Retrofit.Builder()
        .baseUrl("http://$DIRECCION:$PUERTO/api/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Funciones::class.java)
}
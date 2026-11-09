package com.example.appapilogin.conexion

import com.example.appapilogin.interfaz.Funciones

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitCliente {
    private const val DIRECCION = "192.168.1.10" //"192.168.56.1"
    private const val PUERTO = "5017"

    var ruta: Funciones = Retrofit.Builder()
        .baseUrl("http://$DIRECCION:$PUERTO/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Funciones::class.java)
}
package com.example.appapilogin.conexion

import com.example.appapilogin.interfaz.Funciones

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitCliente {
    //var localhost = "10.0.2.2"
    var localhost = "192.168.56.1"
    var puerto = "5017"

    var ruta = Retrofit.Builder()
        .baseUrl("http://$localhost:$puerto/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Funciones::class.java)
}
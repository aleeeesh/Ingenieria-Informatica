package com.example.appapilogin

import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.Spinner
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.appapilogin.clases.Datos
import com.example.appapilogin.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class IngresarUsuario : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_ingresar_usuario)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        var btnVolver = findViewById<Button>(R.id.btnIUVolver)
        var cmbPersonas = findViewById<Spinner>(R.id.cmbPersonas)

        btnVolver.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
            finish()
        }

        cargaPersonas(cmbPersonas)
    }
    fun cargaPersonas(cmbPersonas : Spinner){
        CoroutineScope(Dispatchers.IO).launch {
            try {
                val llamada = RetrofitCliente.ruta.ListadoPersonas()

                if(llamada.isSuccessful){
                    val cuerpo : Datos? = llamada.body()

                    withContext(Dispatchers.Main){
                        val mensaje = cuerpo?.mensaje
                        val respuesta = cuerpo?.respuesta
                        val lista = cuerpo?.lista

                        val listadoArr = ArrayList<String>()

                        lista?.forEach { item ->
                            listadoArr.add("[${item.idPersona}] ${item.nomPersona} ${item.apePersona}")
                        }

                        val adaptador = ArrayAdapter(this@IngresarUsuario,
                            android.R.layout.simple_spinner_dropdown_item,
                            listadoArr)

                        cmbPersonas.adapter = adaptador
                    }
                }
            }catch (ex : Exception){

            }
        }
    }
}
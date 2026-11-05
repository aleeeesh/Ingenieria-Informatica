package com.josue.apilogin.activities.usuarios

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.ListView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.josue.apilogin.MainActivity
import com.josue.apilogin.R
import com.josue.apilogin.clases.DatosPersonas
import com.josue.apilogin.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class ListadoUsuariosActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_listado_usuarios)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btnVolver = findViewById<Button>(R.id.btnLUVolver)
        val listadoUsuarios = findViewById<ListView>(R.id.lstListadoUsuarios)

        btnVolver.setOnClickListener {
            startActivity(Intent(this, MainActivity::class.java))
            finish()
        }

        cargarUsuarios(listadoUsuarios)
    }

    fun cargarUsuarios(listado: ListView) {
        CoroutineScope(Dispatchers.IO).launch {
            try {
                val llamada = RetrofitCliente.ruta.ListadoPersonas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosPersonas? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val respuesta = cuerpo?.respuesta
                        val mensaje = cuerpo?.mensaje
                        val lista = cuerpo?.lista

                        lista?.forEach { persona ->
                            val id = persona.idPersona
                            val nombre = persona.nomPersona
                            val apellido = persona.apePersona
                            val edac = persona.edad
                        }
                    }
                }
            } catch (ex: Exception) {

            }
        }
    }
}
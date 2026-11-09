package com.example.appapilogin

import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ListView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.appapilogin.clases.usuarios.DatosUsuario
import com.example.appapilogin.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class ListadoUsuarios : AppCompatActivity() {
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
        val listadoUsuarios = findViewById<ListView>(R.id.lvListadoUsuarios)

        btnVolver.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
            finish()
        }

        cargaDatos(listadoUsuarios)

        listadoUsuarios.setOnItemClickListener{ parent, view, position, id ->
            val elemento = parent.getItemAtPosition(position)

            Toast.makeText(this, "Elemento: $elemento", Toast.LENGTH_SHORT).show()
        }
    }
    fun cargaDatos(listview : ListView){
        var adaptador: ArrayAdapter<*>
        val arregloListado = ArrayList<String>()

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val llamada = RetrofitCliente.ruta.listadoUsuarios()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosUsuario? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val lista = cuerpo?.lista

                        lista?.forEach { item ->
                            val usuario = item.nomUsuario
                            val nombreCompleto = item.nombreCompleto
                            val edad = item.edad
                            val estado = item.nomEstado

                            arregloListado.add("$nombreCompleto ($usuario) - $edad años\nSe encuentra ${estado.lowercase()}")
                        }

                        adaptador = ArrayAdapter(
                            this@ListadoUsuarios,
                            android.R.layout.simple_list_item_1,
                            arregloListado
                        )

                        listview.adapter = adaptador
                    }
                }
            } catch (ex: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@ListadoUsuarios, "Error: ${ex.message}", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }
}
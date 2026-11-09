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
import com.example.appapilogin.clases.personas.DatosPersona
import com.example.appapilogin.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class ListadoPersonas : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_listado_personas)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btnVolver = findViewById<Button>(R.id.btnLPVolver)
        val listadoPersonas = findViewById<ListView>(R.id.lvListadoPersonas)

        btnVolver.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
            finish()
        }

        cargaDatos(listadoPersonas)

        listadoPersonas.setOnItemClickListener{ parent, view, position, id ->
            val elemento = parent.getItemAtPosition(position)

            Toast.makeText(this, "Elemento: $elemento", Toast.LENGTH_SHORT).show()
        }
    }
    fun cargaDatos(listview : ListView){
        var adaptatador: ArrayAdapter<*>
        val arregloListado = ArrayList<String>()

        CoroutineScope(Dispatchers.IO).launch {
            try {
                val llamada = RetrofitCliente.ruta.listadoPersonas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosPersona? = llamada.body()

                    withContext(Dispatchers.Main){
                        val lista = cuerpo?.lista

                        lista?.forEach { item ->
                            val id = item.idPersona
                            val nombre = item.nomPersona
                            val apellido = item.apePersona
                            val edad = item.edad

                            arregloListado.add("[$id] $nombre $apellido\n$edad años")
                        }
                        adaptatador = ArrayAdapter(this@ListadoPersonas,
                            android.R.layout.simple_list_item_1,
                            arregloListado)
                        listview.adapter = adaptatador
                    }
                }
            } catch (ex: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@ListadoPersonas, "Error: ${ex.message}", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }
}
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
import com.example.appapilogin.clases.Datos
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
        var btnVolver = findViewById<Button>(R.id.btnLPVolver)
        var listview = findViewById<ListView>(R.id.lvListadoPersonas)

        btnVolver.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
            finish()
        }

        cargaDatos(listview)

        listview.setOnItemClickListener{ parent, view, position, id ->
            var elemento = parent.getItemAtPosition(position)
            Toast.makeText(this, "Elemento: $elemento", Toast.LENGTH_SHORT).show()
        }
    }
    fun cargaDatos(listview : ListView){
        var adaptatador: ArrayAdapter<*>
        var arregloListado = ArrayList<String>()

        CoroutineScope(Dispatchers.IO).launch {
            try{
                var llamada = RetrofitCliente.ruta.ListadoPersonas()
                if(llamada.isSuccessful){
                    var respuesta: Datos? = llamada.body()
                    withContext(Dispatchers.Main){
                        var r = respuesta?.respuesta
                        var m = respuesta?.mensaje
                        var l = respuesta?.lista

                        l?.forEach { item ->
                            var id = item.idPersona
                            var nombre = item.nomPersona
                            var apellido = item.apePersona
                            var edad = item.edad
                            arregloListado.add("ID:$id - Nombre:$nombre  - Apellido:$apellido\nEdad:$edad")
                        }
                        adaptatador = ArrayAdapter(this@ListadoPersonas,
                            android.R.layout.simple_list_item_1,
                            arregloListado)
                        listview.adapter = adaptatador
                    }
                }
            }catch (ex: Exception){
                var cosa = ex.toString()
                var asasd = 1
            }
        }
    }
}
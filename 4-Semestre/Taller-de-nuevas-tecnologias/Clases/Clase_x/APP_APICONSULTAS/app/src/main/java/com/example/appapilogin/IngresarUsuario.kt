package com.example.appapilogin

import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.Spinner
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.appapilogin.clases.estados.DatosEstado
import com.example.appapilogin.clases.personas.DatosPersona
import com.example.appapilogin.clases.personas.Persona
import com.example.appapilogin.clases.usuarios.DatosUsuario
import com.example.appapilogin.clases.usuarios.Usuario
import com.example.appapilogin.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.util.Locale

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

        val btnVolver = findViewById<Button>(R.id.btnIUVolver)

        val txtNomUsuario = findViewById<EditText>(R.id.txtNomUsuario)

        val cmbPersona = findViewById<Spinner>(R.id.cmbPersonas)
        val cmbEstado = findViewById<Spinner>(R.id.cmbEstado)

        val btnLimpiar = findViewById<Button>(R.id.btnLimpiarUsuario)
        val btnGuardar = findViewById<Button>(R.id.btnGuardarUsuario)

        btnVolver.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
            finish()
        }

        cargarPersonas(cmbPersona)
        cargarEstados(cmbEstado)

        btnLimpiar.setOnClickListener {
            txtNomUsuario.text.clear()
            cmbPersona.setSelection(-1)
            cmbEstado.setSelection(-1)
        }

        btnGuardar.setOnClickListener {
            val nombreUsuario = txtNomUsuario.text.toString().trim()
            val persona = cmbPersona.selectedItem.toString().substringAfter("[").substringBefore("]").toIntOrNull() ?: -1
            val estado = cmbEstado.selectedItem.toString().substringAfter("[").substringBefore("]").toIntOrNull() ?: -1

            var mensaje = "Debe ingresar: \n"

            if (nombreUsuario.isEmpty()) {
                mensaje += "- nombre de usuario\n"
            }

            if (persona == -1) {
                mensaje += "- seleccionar persona\n"
            }

            if (estado == -1) {
                mensaje += "- seleccionar estado\n"
            }

            if (mensaje == "Debe ingresar: \n") {
                insertarUsuario(nombreUsuario, persona, estado)
            } else {
                AlertDialog.Builder(this)
                    .setTitle("Faltan datos por ingresar")
                    .setMessage(mensaje)
                    .setNeutralButton("OK") { dialog, id ->
                        dialog.dismiss()
                    }
                    .create()
                    .show()
            }
        }
    }

    fun insertarUsuario(
        usuario : String,
        idPersona: Int,
        idEstado: Int
    ){
        CoroutineScope(Dispatchers.IO).launch {
            try {
                val usuario = Usuario(
                    0,
                    usuario,
                    idPersona,
                    idEstado
                )

                val llamada = RetrofitCliente.ruta.insertarUsuario(usuario)

                if (llamada.isSuccessful) {
                    val cuerpo: DatosUsuario? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val mensaje = cuerpo?.mensaje
                        val respuesta = cuerpo?.respuesta

                        Toast.makeText(this@IngresarUsuario, "$respuesta: $mensaje", Toast.LENGTH_SHORT).show()
                    }
                }
            } catch (ex: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@IngresarUsuario, "Error: ${ex.message}", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    fun cargarPersonas(cmbPersonas : Spinner){
        CoroutineScope(Dispatchers.IO).launch {
            try {
                val api = RetrofitCliente.ruta.listadoPersonas()

                if (api.isSuccessful) {
                    val cuerpo : DatosPersona? = api.body()

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

                        Toast.makeText(this@IngresarUsuario, "$respuesta: $mensaje", Toast.LENGTH_SHORT).show()
                    }
                }
            } catch (ex : Exception){
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@IngresarUsuario, "Error: ${ex.message}", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    fun cargarEstados(cmbEstados : Spinner){
        CoroutineScope(Dispatchers.IO).launch {
            try {
                val api = RetrofitCliente.ruta.listadoEstados()

                if (api.isSuccessful) {
                    val cuerpo : DatosEstado? = api.body()

                    withContext(Dispatchers.Main){
                        val mensaje = cuerpo?.mensaje
                        val respuesta = cuerpo?.respuesta
                        val lista = cuerpo?.lista

                        val listadoArr = ArrayList<String>()

                        lista?.forEach { item ->
                            listadoArr.add("[${item.idEstado}] ${item.nomEstado.lowercase()}")
                        }

                        val adaptador = ArrayAdapter(this@IngresarUsuario,
                            android.R.layout.simple_spinner_dropdown_item,
                            listadoArr)

                        cmbEstados.adapter = adaptador

                        Toast.makeText(this@IngresarUsuario, "$respuesta: $mensaje", Toast.LENGTH_SHORT).show()
                    }
                }
            } catch (ex : Exception){
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@IngresarUsuario, "Error: ${ex.message}", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }
}
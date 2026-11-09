package com.example.appapilogin

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.appapilogin.clases.personas.DatosPersona
import com.example.appapilogin.clases.personas.Persona
import com.example.appapilogin.conexion.RetrofitCliente
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class IngresarPersona : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_ingresar_persona)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btnVolver = findViewById<Button>(R.id.btnIPVolver)
        val btnLimpiar = findViewById<Button>(R.id.btnLimpiarPersona)
        val btnGuardar = findViewById<Button>(R.id.btnGuardarPersona)

        val txtNombres = findViewById<EditText>(R.id.txtNombres)
        val txtApellidos = findViewById<EditText>(R.id.txtApellidos)
        val txtEdad = findViewById<EditText>(R.id.txtEdad)

        btnVolver.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
            finish()
        }

        btnLimpiar.setOnClickListener {
            txtNombres.text.clear()
            txtApellidos.text.clear()
            txtEdad.text.clear()
        }

        btnGuardar.setOnClickListener {
            val nombre = txtNombres.text.toString().trim()
            val apellido = txtApellidos.text.toString().trim()
            val edad = txtEdad.text.toString().toIntOrNull() ?: -1

            var mensaje = "Debe ingresar: \n"

            if (nombre.isEmpty()) {
                mensaje += "- nombres\n"
            }

            if (apellido.isEmpty()) {
                mensaje += "- apellidos\n"
            }

            if (edad == -1) {
                mensaje += "- edad\n"
            }

            if (mensaje == "Debe ingresar: \n") {
                insertarPersona(
                    nombre,
                    apellido,
                    edad
                )
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
    fun insertarPersona(
        txtNombres : String,
        txtApellidos: String,
        txtEdad: Int
    ){
        CoroutineScope(Dispatchers.IO).launch {
            try {
                val persona = Persona(
                    0,
                    txtNombres,
                    txtApellidos,
                    txtEdad
                )

                val llamada = RetrofitCliente.ruta.insertarPersona(persona)

                if (llamada.isSuccessful) {
                    val cuerpo: DatosPersona? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val mensaje = cuerpo?.mensaje
                        val respuesta = cuerpo?.respuesta

                        Toast.makeText(this@IngresarPersona, "$respuesta: $mensaje", Toast.LENGTH_SHORT).show()
                    }
                }
            } catch (ex: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@IngresarPersona, "Error: ${ex.message}", Toast.LENGTH_SHORT).show()
                }
            }
         }
    }
}
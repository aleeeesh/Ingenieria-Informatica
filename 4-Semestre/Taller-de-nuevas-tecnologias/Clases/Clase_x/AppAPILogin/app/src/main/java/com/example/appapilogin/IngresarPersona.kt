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
import com.example.appapilogin.clases.Datos
import com.example.appapilogin.clases.Persona
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
        var btnVolver = findViewById<Button>(R.id.btnIPVolver)
        var btnLimpiar = findViewById<Button>(R.id.btnLimpiarPersona)
        var btnIngresar = findViewById<Button>(R.id.btnGuardarPersona)
        var txtNombres = findViewById<EditText>(R.id.txtNombres)
        var txtApellidos = findViewById<EditText>(R.id.txtApellidos)
        var txtEdad = findViewById<EditText>(R.id.txtEdad)

        btnVolver.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
            finish()
        }

        btnLimpiar.setOnClickListener {
            txtNombres.text.clear()
            txtApellidos.text.clear()
            txtEdad.text.clear()
        }

        btnIngresar.setOnClickListener {
            var mensaje = "Debe ingresar: \n"

            if (txtNombres.text.isEmpty()) {
                mensaje += "- nombres\n"
            }

            if (txtApellidos.text.isEmpty()) {
                mensaje += "- apellidos\n"
            }

            if (txtEdad.text.isEmpty()) {
                mensaje += "- edad\n"
            }

            if (mensaje == "Debe ingresar: \n") {
                insertarPersona(
                    txtNombres.text.toString(),
                    txtApellidos.text.toString(),
                    txtEdad.text.toString().toInt()
                )
            } else {
                AlertDialog.Builder(this)
                    .setTitle("Faltan datos por ingresar")
                    .setMessage(mensaje)
                    .create().show()
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

                val llamada = RetrofitCliente.ruta.InsertarPersona(persona)

                if (llamada.isSuccessful) {
                    val cuerpo: Datos? = llamada.body()

                    withContext(Dispatchers.Main) {
                        val mensaje = cuerpo?.mensaje
                        val respuesta = cuerpo?.respuesta

                        Toast.makeText(this@IngresarPersona, "$respuesta: $mensaje", Toast.LENGTH_SHORT).show()
                    }
                }
            }catch (ex: Exception){

            }
         }
    }
}
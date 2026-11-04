package com.josue.apilogin

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.josue.apilogin.activities.personas.InsertarPersonaActivity
import com.josue.apilogin.activities.personas.ListadoPersonasActivity
import com.josue.apilogin.activities.usuarios.InsertarUsuarioActivity
import com.josue.apilogin.activities.usuarios.ListadoUsuariosActivity

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btnListadoPersonas = findViewById<Button>(R.id.btnPersonas)
        val btnInsertarPersona = findViewById<Button>(R.id.btnInsertarPersona)

        val btnListadoUsuarios = findViewById<Button>(R.id.btnUsuarios)
        val btnInsertarUsuario = findViewById<Button>(R.id.btnInsertarUsuario)

        btnListadoPersonas.setOnClickListener {
            startActivity(Intent(this, ListadoPersonasActivity::class.java))
        }

        btnInsertarPersona.setOnClickListener {
            startActivity(Intent(this, InsertarPersonaActivity::class.java))
        }

        btnListadoUsuarios.setOnClickListener {
            startActivity(Intent(this, ListadoUsuariosActivity::class.java))
        }

        btnInsertarUsuario.setOnClickListener {
            startActivity(Intent(this, InsertarUsuarioActivity::class.java))
        }
    }
}
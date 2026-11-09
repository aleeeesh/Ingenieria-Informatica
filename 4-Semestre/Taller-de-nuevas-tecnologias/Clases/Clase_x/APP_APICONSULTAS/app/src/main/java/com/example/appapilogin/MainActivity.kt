package com.example.appapilogin

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

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
        var btnListadoPersonas = findViewById<Button>(R.id.btnPersonas)
        var btnListadoUsuarios = findViewById<Button>(R.id.btnUsuarios)
        var btnInsertarPersonas = findViewById<Button>(R.id.btnIngresarPersona)
        var btnInsertarUsuarios = findViewById<Button>(R.id.btnIngresarUsuario)
        var btnLogin = findViewById<Button>(R.id.btnLogin)

        btnListadoPersonas.setOnClickListener {
            startActivity(Intent(this,
                ListadoPersonas::class.java))
            finish()
        }
        btnListadoUsuarios.setOnClickListener {
            startActivity(Intent(this,
                ListadoUsuarios::class.java))
            finish()
        }
        btnInsertarPersonas.setOnClickListener {
            startActivity(Intent(this,
                IngresarPersona::class.java))
            finish()
        }
        btnInsertarUsuarios.setOnClickListener {
            startActivity(Intent(this,
                IngresarUsuario::class.java))
            finish()
        }
        btnLogin.setOnClickListener {
            startActivity(Intent(this,
                Login::class.java))
            finish()
        }
    }
}
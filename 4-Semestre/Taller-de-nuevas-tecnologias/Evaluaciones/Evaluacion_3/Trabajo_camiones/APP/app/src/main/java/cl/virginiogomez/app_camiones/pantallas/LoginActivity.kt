package cl.virginiogomez.app_camiones.pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.widget.doAfterTextChanged
import androidx.lifecycle.lifecycleScope
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.DatosSesion
import kotlinx.coroutines.launch
import cl.virginiogomez.app_camiones.clases.Sesion
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.databinding.ActivityLoginBinding

class LoginActivity : AppCompatActivity() {
    private lateinit var binding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()

        binding = ActivityLoginBinding.inflate(layoutInflater)

        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        binding.btnLimpiar.setOnClickListener {
            val usuario = binding.txtUsuario.text
            val contrasena = binding.txtContrasena.text

            if (usuario?.isEmpty() == false && contrasena?.isEmpty() == false) {
                usuario.clear()
                contrasena.clear()
                binding.txtUsuarioLayout.requestFocus()
            }
        }

        binding.btnLogin.setOnClickListener {
            if (!binding.btnLogin.isEnabled) return@setOnClickListener
            
            val usuario = binding.txtUsuario.text.toString().trim()
            val contrasena = binding.txtContrasena.text.toString().trim()

            if (usuario.isEmpty()) {
                AlertDialog.Builder(this)
                    .setTitle(getString(R.string.texto_aviso))
                    .setMessage(getString(R.string.error_usuario_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (contrasena.isEmpty()) {
                AlertDialog.Builder(this)
                    .setTitle(getString(R.string.texto_aviso))
                    .setMessage(getString(R.string.error_contrasena_vacia))
                    .create()
                    .show()
                return@setOnClickListener
            }

            binding.btnLogin.isEnabled = false

            lifecycleScope.launch {
                try {
                    val sesion = Sesion(usuario, contrasena)
                    val llamada = RetrofitCliente.api.iniciarSesion(sesion)

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosSesion? = llamada.body()

                        if (cuerpo?.exito == true) {
                            startActivity(Intent(this@LoginActivity, MainActivity::class.java))
                            finish()
                        } else {
                            val mensaje = cuerpo?.mensaje

                            AlertDialog.Builder(this@LoginActivity)
                                .setTitle(getString(R.string.texto_aviso))
                                .setMessage(mensaje)
                                .create()
                                .show()
                        }
                    }
                } catch (e: Exception) {
                    Log.d("[Login] Exception", e.toString())

                    if (e.toString().contains("failed to connect")) {
                        AlertDialog.Builder(this@LoginActivity)
                            .setTitle(getString(R.string.texto_error))
                            .setMessage(getString(R.string.error_conexion))
                            .create()
                            .show()
                    } else {
                        AlertDialog.Builder(this@LoginActivity)
                            .setTitle(getString(R.string.texto_error))
                            .setMessage(getString(R.string.error_inesperado))
                            .create()
                            .show()
                    }
                } finally {
                    binding.btnLogin.isEnabled = true
                }
            }
        }

        lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.obtenerSesion()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosSesion? = llamada.body()

                    if (cuerpo?.exito == true) {
                        startActivity(Intent(this@LoginActivity, MainActivity::class.java))
                        finish()
                    }
                }
            }
            catch (e: Exception) {
                Log.d("[Obtener sesión] Exception", e.toString())

                if (e.toString().contains("failed to connect")) {
                    AlertDialog.Builder(this@LoginActivity)
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_conexion))
                        .create()
                        .show()
                } else {
                    AlertDialog.Builder(this@LoginActivity)
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_inesperado))
                        .create()
                        .show()
                }
            }
        }
    }
}
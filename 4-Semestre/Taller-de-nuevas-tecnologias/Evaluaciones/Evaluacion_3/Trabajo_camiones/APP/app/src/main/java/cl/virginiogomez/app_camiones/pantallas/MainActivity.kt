package cl.virginiogomez.app_camiones.pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.lifecycle.lifecycleScope
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.DatosSesion
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.databinding.ActivityMainBinding
import cl.virginiogomez.app_camiones.pantallas.camiones.CamionesFragment
import cl.virginiogomez.app_camiones.pantallas.conductores.ConductoresFragment
import cl.virginiogomez.app_camiones.pantallas.plantas.PlantasFragment
import cl.virginiogomez.app_camiones.pantallas.salidas.SalidasFragment
import cl.virginiogomez.app_camiones.pantallas.usuarios.UsuariosFragment
import kotlinx.coroutines.launch

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        binding = ActivityMainBinding.inflate(layoutInflater)

        setContentView(binding.root)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        binding.btnCerrarSesion.setOnClickListener {
            AlertDialog.Builder(this@MainActivity)
                .setTitle(getString(R.string.texto_aviso))
                .setMessage(getString(R.string.texto_cerrar_sesion))
                .setPositiveButton(getString(R.string.action_si)) { dialog, _ ->
                    lifecycleScope.launch {
                        try {
                            val llamada = RetrofitCliente.api.cerrarSesion()

                            if (llamada.isSuccessful) {
                                startActivity(Intent(this@MainActivity, LoginActivity::class.java))
                                finish()
                            }
                        } catch (e: Exception) {
                            Log.d("[Cerrar sesión] Exception", e.toString())

                            if (e.toString().contains("failed to connect")) {
                                AlertDialog.Builder(this@MainActivity)
                                    .setTitle(getString(R.string.texto_error))
                                    .setMessage(getString(R.string.error_conexion))
                                    .create()
                                    .show()
                            } else {
                                AlertDialog.Builder(this@MainActivity)
                                    .setTitle(getString(R.string.texto_error))
                                    .setMessage(getString(R.string.error_inesperado))
                                    .create()
                                    .show()
                            }
                        } finally {
                            dialog.dismiss()
                        }
                    }
                }
                .setNegativeButton(R.string.action_no, null)
                .create()
                .show()
        }

        binding.bottomNav.setOnItemSelectedListener { item ->
            when (item.itemId) {
                R.id.nav_usuarios -> {
                    supportFragmentManager.beginTransaction().replace(
                        R.id.fragmentContainer,
                        UsuariosFragment()
                    ).commit()
                }
                R.id.nav_conductores -> {
                    supportFragmentManager.beginTransaction().replace(
                        R.id.fragmentContainer,
                        ConductoresFragment()
                    ).commit()
                }
                R.id.nav_camiones -> {
                    supportFragmentManager.beginTransaction().replace(
                        R.id.fragmentContainer,
                        CamionesFragment()
                    ).commit()
                }
                R.id.nav_plantas -> {
                    supportFragmentManager.beginTransaction().replace(
                        R.id.fragmentContainer,
                        PlantasFragment()
                    ).commit()
                }
                R.id.nav_salidas -> {
                    supportFragmentManager.beginTransaction().replace(
                        R.id.fragmentContainer,
                        SalidasFragment()
                    ).commit()
                }
            }
            true
        }

        // Obtiene la sesión del usuario para mostrar el nombre en la bienvenida.
        lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.obtenerSesion()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosSesion? = llamada.body()
                    val nombre = cuerpo?.nombre ?: "Usuario"

                    binding.lblBienvenida.text = getString(R.string.label_bienvenida, nombre)
                }
            } catch (e: Exception) {
                Log.d("[Bienvenida] Exception", e.toString())

                if (e.toString().contains("failed to connect")) {
                    AlertDialog.Builder(this@MainActivity)
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_conexion))
                        .create()
                        .show()
                } else {
                    AlertDialog.Builder(this@MainActivity)
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_inesperado))
                        .create()
                        .show()
                }
            }
        }
    }
}
package cl.virginiogomez.app_camiones.pantallas.usuarios

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.CrearUsuario
import cl.virginiogomez.app_camiones.clases.DatosUsuario
import cl.virginiogomez.app_camiones.clases.EstadoUsuario
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.databinding.FragmentUsuariosBinding
import kotlinx.coroutines.launch

class UsuariosFragment : Fragment() {
    private lateinit var binding: FragmentUsuariosBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        binding = FragmentUsuariosBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.btnAgregarUsuario.setOnClickListener {
            if (!binding.btnAgregarUsuario.isEnabled) return@setOnClickListener

            val usuario = binding.txtUsuario.text.toString().trim()
            val nombre = binding.txtNomUsuario.text.toString().trim()
            val contrasena = binding.txtContrasenaUsuario.text.toString().trim()

            if (usuario.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_usuario_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (nombre.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_nombre_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (contrasena.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_contrasena_vacia))
                    .create()
                    .show()
                return@setOnClickListener
            }

            binding.btnAgregarUsuario.isEnabled = false

            viewLifecycleOwner.lifecycleScope.launch {
                try {
                    val nuevoUsuario = CrearUsuario(usuario, nombre, contrasena)

                    val llamada = RetrofitCliente.api.registrarUsuario(nuevoUsuario)

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosUsuario? = llamada.body()
                        val mensaje = cuerpo?.mensaje

                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_aviso))
                            .setMessage(mensaje)
                            .create()
                            .show()

                        if (cuerpo?.exito == true) {
                            binding.txtUsuario.text?.clear()
                            binding.txtNomUsuario.text?.clear()
                            binding.txtContrasenaUsuario.text?.clear()

                            cargarUsuarios(binding.lstUsuarios)
                        }
                    }
                } catch (e: Exception) {
                    Log.d("[Usuarios] Exception", e.toString())

                    if (e.toString().contains("failed to connect")) {
                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_error))
                            .setMessage(getString(R.string.error_conexion))
                            .create()
                            .show()
                    } else {
                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_error))
                            .setMessage(getString(R.string.error_inesperado))
                            .create()
                            .show()
                    }
                } finally {
                    binding.btnAgregarUsuario.isEnabled = true
                }
            }
        }

        cargarUsuarios(binding.lstUsuarios)
    }

    private var adaptador: AdaptadorUsuarios? = null

    fun cargarUsuarios(lista: RecyclerView) {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val cargaUsuario = RetrofitCliente.api.cargarUsuarios()

                if (cargaUsuario.isSuccessful) {
                    val cuerpo: DatosUsuario? = cargaUsuario.body()

                    if (cuerpo?.exito == true) {
                        adaptador = AdaptadorUsuarios(cuerpo.datos.toMutableList()) { usuario, _ ->
                            viewLifecycleOwner.lifecycleScope.launch {
                                val estado = EstadoUsuario(usuario.usuario)
                                val cambioEstado = RetrofitCliente.api.alternarEstadoUsuario(estado)

                                if (cambioEstado.isSuccessful && cambioEstado.body()?.exito == true) {
                                    cargarUsuarios(lista)
                                }
                            }
                        }

                        if (lista.layoutManager == null) {
                            lista.layoutManager = LinearLayoutManager(requireContext())
                        }

                        lista.adapter = adaptador
                    }
                }
            } catch (e: Exception) {
                Log.d("[Cargar usuarios] Exception", e.toString())

                if (e.toString().contains("failed to connect")) {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_conexion))
                        .create()
                        .show()
                } else {
                    AlertDialog.Builder(requireContext())
                        .setTitle(getString(R.string.texto_error))
                        .setMessage(getString(R.string.error_inesperado))
                        .create()
                        .show()
                }
            }
        }
    }
}
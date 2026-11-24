package cl.virginiogomez.app_camiones.pantallas.conductores

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.CrearConductor
import cl.virginiogomez.app_camiones.clases.DatosConductor
import cl.virginiogomez.app_camiones.clases.DatosEstado
import cl.virginiogomez.app_camiones.clases.EstadoConductor
import cl.virginiogomez.app_camiones.clases.ObtenerEstados
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.databinding.FragmentConductoresBinding
import kotlinx.coroutines.launch

class ConductoresFragment : Fragment() {
    private lateinit var binding: FragmentConductoresBinding
    private var estado: ObtenerEstados? = null

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        binding = FragmentConductoresBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.btnAgregarConductor.setOnClickListener {
            if (!binding.btnAgregarConductor.isEnabled) return@setOnClickListener

            val nombre = binding.txtNombreConductor.text.toString().trim()
            val idEstado = estado?.idEstado ?: -1

            if (nombre.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_nombre_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (idEstado == -1) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_selector_estado_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            binding.btnAgregarConductor.isEnabled = false

            viewLifecycleOwner.lifecycleScope.launch {
                try {
                    val nuevoConductor = CrearConductor(nombre, idEstado)

                    val llamada = RetrofitCliente.api.registrarConductor(nuevoConductor)

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosConductor? = llamada.body()
                        val mensaje = cuerpo?.mensaje

                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_aviso))
                            .setMessage(mensaje)
                            .create()
                            .show()

                        if (cuerpo?.exito == true) {
                            binding.txtNombreConductor.text?.clear()
                            binding.cmbEstadoConductor.text?.clear()
                            estado = null

                            cargarConductores(binding.lstConductores)
                        }
                    }
                } catch (e: Exception) {
                    Log.d("[Conductores] Exception", e.toString())

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
                    binding.btnAgregarConductor.isEnabled = true
                }
            }
        }

        cargarConductores(binding.lstConductores)
        cargarEstados()
    }

    private var adaptador: AdaptadorConductores? = null

    fun cargarConductores(lista: RecyclerView) {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.cargarConductores()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosConductor? = llamada.body()

                    if (cuerpo?.exito == true) {
                        adaptador = AdaptadorConductores(cuerpo.datos.toMutableList()) { conductor, position ->
                            viewLifecycleOwner.lifecycleScope.launch {
                                val estado = EstadoConductor(conductor.idConductor)
                                val cambioEstado = RetrofitCliente.api.alternarEstadoConductor(estado)

                                if (cambioEstado.isSuccessful && cambioEstado.body()?.exito == true) {
                                    cargarConductores(lista)
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
                Log.d("[Cargar conductores] Exception", e.toString())

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

    fun cargarEstados() {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.cargarEstados()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosEstado? = llamada.body()

                    if (cuerpo?.exito == true) {
                        val adaptador = ArrayAdapter(
                            requireContext(),
                            android.R.layout.simple_dropdown_item_1line,
                            cuerpo.datos
                        )
                        adaptador.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
                        binding.cmbEstadoConductor.setAdapter(adaptador)

                        binding.cmbEstadoConductor.setOnItemClickListener { _, _, position, _ ->
                            estado = adaptador.getItem(position)
                        }
                    }
                }
            } catch (e: Exception) {
                Log.d("[Cargar estados - conductores] Exception", e.toString())

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
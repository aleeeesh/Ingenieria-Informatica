package cl.virginiogomez.app_camiones.pantallas.camiones

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
import cl.virginiogomez.app_camiones.clases.CrearCamion
import cl.virginiogomez.app_camiones.clases.DatosCamion
import cl.virginiogomez.app_camiones.clases.DatosEstado
import cl.virginiogomez.app_camiones.clases.DatosPlanta
import cl.virginiogomez.app_camiones.clases.EstadoCamion
import cl.virginiogomez.app_camiones.clases.ObtenerEstados
import cl.virginiogomez.app_camiones.clases.ObtenerPlantas
import cl.virginiogomez.app_camiones.conexion.RetrofitCliente
import cl.virginiogomez.app_camiones.databinding.FragmentCamionesBinding
import kotlinx.coroutines.launch

class CamionesFragment : Fragment() {
    private lateinit var binding: FragmentCamionesBinding
    private var planta: ObtenerPlantas? = null
    private var estado: ObtenerEstados? = null

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        binding = FragmentCamionesBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.btnAgregarCamion.setOnClickListener {
            if (!binding.btnAgregarCamion.isEnabled) return@setOnClickListener

            val codCamion = binding.txtCodCamion.text.toString().trim()
            val idPlanta = planta?.idPlanta ?: -1
            val idEstado = estado?.idEstado ?: -1

            if (codCamion.isEmpty()) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_cod_camion_vacio))
                    .create()
                    .show()
                return@setOnClickListener
            }

            if (idPlanta == -1) {
                AlertDialog.Builder(requireContext())
                    .setTitle(getString(R.string.texto_campo_vacio))
                    .setMessage(getString(R.string.error_selector_planta_vacia))
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

            binding.btnAgregarCamion.isEnabled = false

            viewLifecycleOwner.lifecycleScope.launch {
                try {
                    val nuevoCamion = CrearCamion(codCamion, idPlanta, idEstado)

                    val llamada = RetrofitCliente.api.registrarCamion(nuevoCamion)

                    if (llamada.isSuccessful) {
                        val cuerpo: DatosCamion? = llamada.body()
                        val mensaje = cuerpo?.mensaje

                        AlertDialog.Builder(requireContext())
                            .setTitle(getString(R.string.texto_aviso))
                            .setMessage(mensaje)
                            .create()
                            .show()

                        if (cuerpo?.exito == true) {
                            binding.txtCodCamion.text?.clear()
                            binding.cmbPlantaCamion.setText("", false)
                            binding.cmbEstadoCamion.setText("", false)
                            planta = null
                            estado = null

                            cargarCamiones(binding.lstCamiones)
                        }
                    }
                } catch (e: Exception) {
                    Log.d("[Camiones] Exception", e.toString())

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
                    binding.btnAgregarCamion.isEnabled = true
                }
            }
        }

        cargarCamiones(binding.lstCamiones)
        cargarPlantas()
        cargarEstados()
    }

    private var adaptador: AdaptadorCamiones? = null

    fun cargarCamiones(lista: RecyclerView) {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.cargarCamiones()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosCamion? = llamada.body()

                    if (cuerpo?.exito == true) {
                        adaptador = AdaptadorCamiones(cuerpo.datos.toMutableList()) { camion, position ->
                            viewLifecycleOwner.lifecycleScope.launch {
                                val estado = EstadoCamion(camion.codCamion)
                                val cambioEstado = RetrofitCliente.api.alternarEstadoCamion(estado)

                                if (cambioEstado.isSuccessful && cambioEstado.body()?.exito == true) {
                                    cargarCamiones(lista)
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
                Log.d("[Cargar camiones] Exception", e.toString())

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

    fun cargarPlantas() {
        viewLifecycleOwner.lifecycleScope.launch {
            try {
                val llamada = RetrofitCliente.api.cargarPlantas()

                if (llamada.isSuccessful) {
                    val cuerpo: DatosPlanta? = llamada.body()

                    if (cuerpo?.exito == true) {
                        val adaptador = ArrayAdapter(
                            requireContext(),
                            android.R.layout.simple_dropdown_item_1line,
                            cuerpo.datos
                        )
                        adaptador.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
                        binding.cmbPlantaCamion.setAdapter(adaptador)

                        binding.cmbPlantaCamion.setOnItemClickListener { _, _, position, _ ->
                            planta = adaptador.getItem(position)
                        }
                    }
                }
            } catch (e: Exception) {
                Log.d("[Cargar plantas - camiones] Exception", e.toString())

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
                        binding.cmbEstadoCamion.setAdapter(adaptador)

                        binding.cmbEstadoCamion.setOnItemClickListener { _, _, position, _ ->
                            estado = adaptador.getItem(position)
                        }
                    }
                }
            } catch (e: Exception) {
                Log.d("[Cargar estados - camiones] Exception", e.toString())

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
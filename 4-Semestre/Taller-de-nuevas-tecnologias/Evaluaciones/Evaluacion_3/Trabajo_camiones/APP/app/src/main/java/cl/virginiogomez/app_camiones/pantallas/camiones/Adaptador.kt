package cl.virginiogomez.app_camiones.pantallas.camiones

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AlertDialog
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.ObtenerCamiones

class AdaptadorCamiones(
    private val listaCamiones: MutableList<ObtenerCamiones>,
    private val onCambiarEstadoClick: (ObtenerCamiones, Int) -> Unit
) : RecyclerView.Adapter<AdaptadorCamiones.CamionViewHolder>() {
    class CamionViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val titulo: TextView = itemView.findViewById(R.id.txtTitulo)
        val subtitulo: TextView = itemView.findViewById(R.id.txtSubtitulo)
        val estado: TextView = itemView.findViewById(R.id.txtEstado)
        val btnEstado: Button = itemView.findViewById(R.id.btnEstado)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): CamionViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_lista, parent, false)
        return CamionViewHolder(view)
    }

    override fun onBindViewHolder(holder: CamionViewHolder, position: Int) {
        val item = listaCamiones[position]

        holder.titulo.text = item.codCamion
        holder.subtitulo.text = item.planta
        holder.estado.text = item.estado.lowercase().replaceFirstChar { it.uppercase() }

        holder.btnEstado.setOnClickListener {
            val contexto = holder.itemView.context
            AlertDialog.Builder(contexto)
                .setTitle(contexto.getString(R.string.texto_aviso))
                .setMessage(contexto.getString(R.string.texto_cambio_estado))
                .setPositiveButton(R.string.action_si) { _, _ ->
                    val pos = holder.bindingAdapterPosition
                    if (pos != RecyclerView.NO_POSITION) {
                        onCambiarEstadoClick(listaCamiones[pos], pos)
                    }
                }
                .setNegativeButton(R.string.action_no, null)
                .show()
        }
    }

    override fun getItemCount(): Int = listaCamiones.size
}
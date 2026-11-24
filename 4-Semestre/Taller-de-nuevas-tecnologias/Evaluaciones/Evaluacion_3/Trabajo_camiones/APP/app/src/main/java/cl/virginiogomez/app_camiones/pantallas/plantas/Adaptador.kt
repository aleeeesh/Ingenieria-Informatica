package cl.virginiogomez.app_camiones.pantallas.plantas

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import cl.virginiogomez.app_camiones.R
import cl.virginiogomez.app_camiones.clases.ObtenerPlantas


class AdaptadorPlantas(
    private val listaPlantas: MutableList<ObtenerPlantas>
) : RecyclerView.Adapter<AdaptadorPlantas.PlantaViewHolder>() {

    class PlantaViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val titulo: TextView = itemView.findViewById(R.id.txtTitulo)
        val subtitulo: TextView = itemView.findViewById(R.id.txtSubtitulo)
        val estado: TextView = itemView.findViewById(R.id.txtEstado)
        val btnEstado: Button = itemView.findViewById(R.id.btnEstado)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): PlantaViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_lista, parent, false)
        return PlantaViewHolder(view)
    }

    override fun onBindViewHolder(holder: PlantaViewHolder, position: Int) {
        val item = listaPlantas[position]
        holder.titulo.text = item.nombre
        holder.subtitulo.text = "ID #${item.idPlanta}"

        holder.estado.visibility = View.GONE
        holder.btnEstado.visibility = View.GONE
    }

    override fun getItemCount(): Int = listaPlantas.size
}

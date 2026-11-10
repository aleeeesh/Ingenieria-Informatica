package com.example.ejemplomaps

import androidx.fragment.app.Fragment

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup

import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.MarkerOptions

class MapsFragment : Fragment() {
    private val callback = OnMapReadyCallback { googleMap ->
        val marcadores = arrayOf(
            arrayOf("IPVG", LatLng(-36.833089, -73.056592)),
            arrayOf("Mi casa", LatLng(-36.89233, -73.1368441)),
            arrayOf("Casa Kevin", LatLng(-37.00378, -73.14892)),
            arrayOf("Casa Danko", LatLng(-36.94492, -73.02086)),
            arrayOf("Casa Martín", LatLng(-36.82765, -73.03959)),
            arrayOf("Lamento Boliviano", LatLng(-18.581015, -70.781370))
        )

        for ((titulo, posicion) in marcadores) {
            googleMap.addMarker(MarkerOptions()
                .position(posicion as LatLng)
                .title(titulo.toString())
            )
        }

        googleMap.moveCamera(CameraUpdateFactory.newLatLngZoom(marcadores[0][1] as LatLng, 15f))
        googleMap.mapType = arguments?.getBoolean("MODO", true) ?: GoogleMap.MAP_TYPE_NORMAL
    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_maps, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        val mapFragment = childFragmentManager.findFragmentById(R.id.map) as SupportMapFragment?
        mapFragment?.getMapAsync(callback)

    }
}
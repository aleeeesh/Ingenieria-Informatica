namespace StarOne.Core;

public class Vuelo
{
    public int IdVuelo { get; set; }  
    public string Codigo { get ; set ; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime Hora { get; set; }
    public decimal PrecioBase { get; set; }
    public List<Pasaje> Pasajes { get; set; }

    public Vuelo(string codigo, string origen, string destino, DateTime fecha,DateTime hora, decimal precioBase)
    {
        this.Codigo = codigo;
        this.Origen = origen;
        this.Destino = destino;
        this.Fecha = fecha;
        this.Hora = hora;
        this.PrecioBase = precioBase;
        this.Pasajes = new List<Pasaje>();
    }
 
}


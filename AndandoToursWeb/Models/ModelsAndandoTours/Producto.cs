using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AndandoToursWeb.Models
{
    public class Producto
    {
        public int IdServicioTipo { get; set; }
        public string ServicioTipoDescripcion { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public string ServicioDescripcion { get; set; }
        public int IdItinerario { get; set; }
        public string ItinNombre { get; set; }
        public int ItinerarioDuracion { get; set; }
        public string ItinerarioDuracionDescripcion { get; set; }
        public string URLFoto { get; set; }
        public int MinDisponibilidadCategoria { get; set; }
        public Decimal MinPriceCategoria { get; set; }
        public string FechaMes { get; set; }
        public string FechaAnio { get; set; }
        public DateTime Fecha { set; get; }
    }
}

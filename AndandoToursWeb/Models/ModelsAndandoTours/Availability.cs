using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AndandoToursWeb.Models
{
    public class Availability
    {
        public int idBarco { get; set; }
        public int idSalida { get; set; }

        public int idBarcoItinerario { get; set; }
        public string barcoNombre { set; get; }
        public DateTime salFechaSalida { set; get; }
        public DateTime salFechaRetorno { get; set; }
        public string salidaTipoEn { get; set; }
        public string totalDisponibilidad { get; set; }

        public string salDispoTotalOtrosBarcos { get; set; }
        public string anio { get; set; }
        public string itinNombre { get; set; }
        public string TipoCabina1 { get; set; }
        public int Dispo_CabinaTipo1 { get; set; }
        public string TipoCabina2 { get; set; }
        public int Dispo_CabinaTipo2 { get; set; }
        public int noches { get; set; }
        public string cabinaPrecio1 { get; set; }

        public string barcoCabinaFoto1 { get; set; }
        public string barcoCabinaFoto2 { get; set; }
        public string cabinaPrecio2 { get; set; }
        public string NombreLeads { set; get; }

        public string salDescuento { get; set; }
        public string barcoSingleSupplement { get; set; }
        public string barcoTripleDisc { get; set; }



        public string EmailLeads { set; get; }
        public string ObservacionLeads { set; get; }
        public string FromProveniente { get; set; }
    }
}
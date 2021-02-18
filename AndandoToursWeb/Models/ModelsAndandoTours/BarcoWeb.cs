using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class BarcoWeb
    {
        public int IdBarco { get; set; }
        public string BarcoNombre { get; set; }
        public string BarcoNombreCorto { get; set; }
        public int Barcocupo { get; set; }
        public string IDBarcoOperador { get; set; }
        public int IDBarcoTipo { get; set; }
        public Boolean BarcoActivo { get; set; }
        public int IDBarcoCategoriaTipo { get; set; }
        public string BarcoCategoriaTipoNombreEn { get; set; }
        public string BarcoURL { get; set; }
        public string BarcoDescripcionCortaEn { get; set; }
        public string BarcoDescripcionCortaEs { get; set; }
        public string BarcoDescripcionEn { get; set; }
        public string BarcoDescripcionEs { get; set; }
        public string BarcoIncluyeEn { get; set; }
        public string BarcoNoincluyeEn { get; set; }
        public Boolean BarcoWebEco { get; set; }
        public string BarcoEcoDescripcion { get; set; }
        public Boolean BarcoEco { get; set; }
        public string BarcoPrecioMin { get; set; }
        public int BarcoDiasItinerario { get; set; }
        public string BarcoImagen { get; set; }
        public List<BarcoWeb> GetBarcoWebs { get; set; }
    }
}

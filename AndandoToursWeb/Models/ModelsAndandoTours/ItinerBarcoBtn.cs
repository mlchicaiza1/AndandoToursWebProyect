using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class ItinerBarcoBtn
    {
        public int IDBarco { get; set; }
        public string BarcoNombre { get; set; }
        public string ItinNombre { get; set; }
        public string ItinNombreCor { get; set; }
        public int ItinDiasCor { get; set; }
        public int IDBarcoItinerario { get; set; }
        public List<ItinerBarcoBtn> GetItinerBarcoBtn { get; set; }
    }
}

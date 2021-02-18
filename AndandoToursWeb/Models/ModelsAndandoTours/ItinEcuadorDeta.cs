using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class ItinEcuadorDeta
    {
        public int IdItinerario { get; set; }
        public String ItinNombre { get; set; }
        public String ItiLinkImagenCaratula { get; set; }
        public int NumeroDeDias { get; set; }
        public int DiaNumero { get; set; }
        public String ItinTituloEn { get; set; }
        public String ItinDescripcionEn { get; set; }
        public int IdItinerarioBtn { get; set; }
    }
}

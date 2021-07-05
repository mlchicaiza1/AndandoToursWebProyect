using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class ItinEcuadorBtn
    {
        public int IdItinerarioBtn { get; set; }
        public int IdVista { get; set; }
        public string ItinNombre { get; set; }
        public string ItinNombreCor { get; set; }
        public string NombreVista { get; set; }

        public int numItiner { get; set; }

        public List<ItinEcuadorBtn> GetItinEcuadorBtn { get; set; }
    }
}

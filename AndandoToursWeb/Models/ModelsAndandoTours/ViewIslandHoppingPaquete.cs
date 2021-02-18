using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class ViewIslandHoppingPaquete
    {
        public int IDWebIslandHoppingYPaquete { get; set; }

        public String NombreIslandHoppingYPaquete { get; set; }
        public int IDItinerario { get; set; }
        public int NumeroDias { get; set; }

        public string Proveedor { get; set; }
        public string FotoPrincipal { get; set; }
        public string Categoria { get; set; }
        public string Precio { get; set; }
        public string PrecioDescuento { get; set; }

        public string Highlights { get; set; }
        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }
        public string IslandHoppingYPaqueteTipo { get; set; }

        public string NumeroDiasTexto { get; set; }


    }

}

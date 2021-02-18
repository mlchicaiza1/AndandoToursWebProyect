using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class GetFeaturesProduct
    {
        public int IdBarcoCaracteristica { get; set; }
        public int IdBarco { get; set; }
        public int IdBarcoCaracteristicaFoto { get; set; }
        public string BarcoNombreCaracteristica { get; set; }
        public string BarcoImagenCaracteristica { get; set; }
    }
}

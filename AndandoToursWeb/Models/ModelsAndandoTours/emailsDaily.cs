using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class emailsDaily
    {
        public string NombrePaypal { get;set;}
        public string EmailPaypal { get; set; }
        public int PasajeroPaypal { get; set; }
        public decimal PrecioPaypal { get; set; }
        public decimal PrecioProducto { get; set; }
        public string ProductoPaypal { get; set; }
        public string ObservacionPaypal { get; set; }
        public DateTime FechaInicioPaypal { get; set; }
        public DateTime FechaFinPaypal { get; set; }
        public string IPPaypal { get; set; }
        public string PaisPaypal { get; set; }
        public string CiudadPaypal { get; set; }
        public string WebProvenientePaypal { get; set; }
        public string IDPaypal { get; set; }
        public string IDUserPaypal { get; set; }
        public int IDStatusPaypal { get; set; }
    }
}

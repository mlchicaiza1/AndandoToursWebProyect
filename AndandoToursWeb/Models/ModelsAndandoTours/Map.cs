using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class Map
    {
        public int IdMapaHotel{get; set; }
        public string NombreHotel { get; set; }
        public string DescripcionHotel { get; set; }
        public string FotoHotel { get; set; }
        public string Region { get; set; }
        public string Foto1 { get; set; }
        public string Foto2 { get; set; }
        public string Foto3 { get; set; }
        public string Foto4 { get; set; }
        public decimal LatitudHotel { get; set; }
        public decimal LongitudHotel { get; set; }
        public int IdProveedor { get; set; }
    }
}

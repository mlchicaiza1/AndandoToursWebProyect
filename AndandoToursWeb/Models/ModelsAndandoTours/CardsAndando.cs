using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models.ModelsAndandoTours
{
    public class CardsAndando
    {
        public int IdCard { get; set; }

        public int IdVista { get; set; }

        public string CardCategoria { get; set; }


        public string CardDetalles { get; set; }

        public int CardPrecio { get; set; }

        public string CardDuracion { get; set; }


        public string CardUrl { get; set; }

        public string CardDepartures { get; set; }

        public string CardImgNombre { get; set; }
        public string CardImgUrl { get; set; }
        public string CardImgTamano { get; set; }

       public IFormFile file { get; set; }
    }
}

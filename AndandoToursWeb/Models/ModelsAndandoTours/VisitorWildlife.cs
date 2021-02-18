using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class VisitorWildlife
    {
        public int IdVisitorSite { get; set; }
        public string NombreVisitorSite { get; set; }
        public string MetaDescripcion { get; set; }
        public string UrlImagenVisitorSite { get; set; }
        public string NombreImagenVisitorSite { get; set; }
        public int IdAnimal { get; set; }
        public string NombreAnimal { get; set; }
    }
}

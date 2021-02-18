using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class Metadata
    { 
        public int idMetadata { get; set; }
        public int idVista { get; set; }
        public string MetaTitulo { get; set; }
        public string MetaDescripcion { get; set; }
        public string MetaURL { get; set; }
        public string MetaReview { get; set; }

        public string MetaKeywords { get; set; }
        


    }

}

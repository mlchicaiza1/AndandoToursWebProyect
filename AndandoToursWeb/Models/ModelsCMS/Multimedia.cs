using System;
using System.Collections.Generic;

namespace AndandoToursWeb.Models
{
    public partial class Multimedia
    {
        public int IdImagen { get; set; }
        public int IdVista { get; set; }
        public string Pagina { get; set; }
        public string NombreImagen { get; set; }
        public string UrlImagen { get; set; }
        public string TamanoImagen { get; set; }
        public VistaAndando IdVistaNavigation { get; set; }
    }
}

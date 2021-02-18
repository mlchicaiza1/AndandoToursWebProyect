using System;
using System.Collections.Generic;

namespace AndandoToursWeb.Models
{
    public partial class Titulo
    {
        public int IdTitulo { get; set; }
        public int? IdVista { get; set; }
        public string contenidoTitulo { get; set; }
        public string Subtitulo { get; set; }

        public VistaAndando IdVistaNavigation { get; set; }
    }
}

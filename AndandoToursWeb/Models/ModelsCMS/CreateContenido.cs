using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models.ModelsCMS
{
    public class CreateContenido
    {
        public string NombreVista { get; set; }

        public string UrlVista { get; set; }

        public string Categoria { get; set; }

        public string TituloMeta { get; set; }

        public string DescripcionMeta { get; set; }

        public int NumeroTitulo { get; set; }

        public int NumeroImagenes { get; set; }
    }
}

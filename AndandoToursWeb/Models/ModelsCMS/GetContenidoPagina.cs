using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class GetContenidoPagina
    {
        public int idVista { get; set; }
        public string nombreVista { get; set; }
        public int IdTitulo { get; set; }
        public int IdParrafo { get; set; }
        public string Titulo { get; set; }
        public string Parrafo { get; set; }
        public int OrdenParrafo { get; set; }
    }
}

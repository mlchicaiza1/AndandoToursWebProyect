using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AndandoToursWeb.Models
{
    public class Island
    {
        public int IdIsland { get; set; }
        public string NombreIsland { get; set; }
        public string DescripcionIsland { get; set; }
        public string ImagenIsland { get; set; }
        public string LinkIsland { get; set; }

        public Boolean MostrarIsland { get; set; }
    }
}

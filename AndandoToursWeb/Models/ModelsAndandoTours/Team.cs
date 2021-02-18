using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string NombreTeam { get; set; }
        public string ApellidoTeam { get; set; }
        public string FotoTeam { get; set; }
        public string CargoTeam { get; set; }
        public string DepartamentoTeam { get; set; }
    }
}

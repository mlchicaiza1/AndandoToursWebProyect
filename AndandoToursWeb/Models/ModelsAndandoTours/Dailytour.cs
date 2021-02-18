using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AndandoToursWeb.Models
{
    public class Dailytour
    {
        public int IdDailytour { get; set; }
        public int IdIsland { get; set; }
        public string NombreDailyTour { get; set; }
        public string DescripcionDailyTour { get; set; }
        public string ImagenDailyTour { get; set; }
        public string LinkDailytour { get; set; }
    }
}

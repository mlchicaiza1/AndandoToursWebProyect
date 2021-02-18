using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class CategoriaBarco
    {
        public int IDBarcoCategoriaTipo { get; set; }
        public string BarcoCategoriaTipoNombreEn { get; set; }
        public string BarcoCategoriaTipoNombreEs { get; set; }
        public string BarcoCategoriaTipoNombreDe { get; set; }
        public string BarcoCategoriaTipoDescripcionEn { get; set; }
        public string BarcoCategoriaTipoDescripcionEs { get; set; }
        public string BarcoCategoriaTipoDescripcionDe { get; set; }
        public Boolean BarcoCategoriaTipoActivo { get; set; }
        public int BarcoCategoriaTipoOrden { get; set; }
        public List<CategoriaBarco> GetCateforiaBarco { get; set; }
    }
}

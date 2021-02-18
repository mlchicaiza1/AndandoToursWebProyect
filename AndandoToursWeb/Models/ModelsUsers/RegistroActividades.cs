using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class RegistroActividades
    {
        //IdUsuario,,Pagina,Seccion,Titulo,ImagenNombre,Texto,Imagen
        public int IdActividad { get; set; }
        public String IdUsuario { get; set; }

        public String UrlPagina { get; set; }
        public String Pagina { get; set; }
        public String Seccion { get; set; }
        public String Titulo { get; set; }

        public String ImagenNombre { get; set; }
        public bool Texto { get; set; }
        public bool Imagen { get; set; }


    }
}

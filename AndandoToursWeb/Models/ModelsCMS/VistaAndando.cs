using System;
using System.Collections.Generic;

namespace AndandoToursWeb.Models
{
    public partial class VistaAndando
    {
        //public VistaAndando()
        //{
        //    Link = new HashSet<Link>();
        //    Multimedia = new HashSet<Multimedia>();
        //    Parrafo = new HashSet<Parrafo>();
        //    Titulo = new HashSet<Titulo>();
        //}

        public int IdVista { get; set; }
        public string NombreVista { get; set; }
        public string UrlVista { get; set; }

        public string CategoriaVista { get; set; }

        //public ICollection<Link> Link { get; set; }
        //public ICollection<Multimedia> Multimedia { get; set; }
        //public ICollection<Parrafo> Parrafo { get; set; }
        //public ICollection<Titulo> Titulo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AndandoToursWeb.Models
{
    public class ItinerarioBarco
    {
        public int IDItinerario { get; set; }
        public int IDServicioTipo { get; set; }
        public String ServServicioEn { get; set; }
        public int IDProveedorTipo { get; set; }
        public String DescripcionEn { get; set; }
        public String DescripcionEs { get; set; }
        public String DescripcionDe { get; set; }
        public Boolean ItiActivo { get; set; }
        public String ItiLinkImagenCaratula { get; set; }
        public int NumeroDeDias { get; set; }
        public int IDBarco { get; set; }
        public String ProvNombre { get; set; }
        public String ProvCiudad { get; set; }
        public int IDItinerarioDetallado { get; set; }
        public int DiaNumero { get; set; }
        public String DiaParte { get; set; }
        public int Orden { get;set;}
        public Boolean ItiDetalladoActivo { get; set; }
        public String ItiCompNombre { get; set; }
        public String ItiCompTituloEn { get; set; }
        public String ItiCompTituloEs { get; set; }
        public String ItiCompTituloDe { get; set; }
        public String ItiCompDescripcionDescriptivoEn { get; set; }
        public String ItiCompDescripcionDescriptivoEs { get; set; }
        public String ItiCompDescripcionDescriptivoDe { get; set; }
        public String ItiCompDescripcionVoucherEn { get; set; }
        public String ItiCompDescripcionVoucherEs { get; set; }
        public String ItiCompLinkImagen { get; set; }
        public String ItiCompLinkImagen2 { get; set; }
        public Boolean ItiCompLinkImagenVoucher { get; set; }
        public String ItiHighlightsEn { get; set; }
        public String ItiHighlightsEs { get; set; }
        public String ItiHighlightsDe { get; set; }
        public String ItiLinkTituloDoc { get; set; }
        public Boolean UsarEnTituloDia { get; set; }
        public int NumeroDeTituloEnDia { get; set; }
        public Boolean MostrarFotosEnDocumento { get; set; }
        public Boolean ItiHiking { get; set; }
        public Boolean ItiSnorkeling { get; set; }
        public Boolean ItiPangaRiding { get; set; }
        public Boolean ItiPaddleBoarding { get; set; }
        public Boolean ItiDiving { get; set; }
        public Boolean ItiKayaking { get; set; }
        public List<ItinerarioBarco> GetItinerBarco { get; set; }
    }
}

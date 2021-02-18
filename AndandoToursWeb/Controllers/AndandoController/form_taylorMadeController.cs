using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AndandoToursWeb.Models;
using AndandoToursWeb.Data;
using AndandoToursWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http.Features;


namespace AndandoToursWeb.Controllers
{
    public class form_taylorMadeController : Controller
    {
        private readonly AndandoRepositorio _repo;

        private IHttpContextAccessor _accessor;


      

        public form_taylorMadeController(AndandoRepositorio repositorio , IHttpContextAccessor accessor) 
        {
            this._repo = repositorio;

            _accessor = accessor;
        }
        [Route("/form_taylorMade/visitor_site_modal/{idVisitor ?}")]
        public async Task<IActionResult> visitor_site_modal(int idVisitor)
        {
            //int idVisitor = 0;
            var visitorSite = await _repo.GetVisitorSitesModal(idVisitor);
            ViewBag.infoVisitor = visitorSite;
            return View();
        }

        //[Route("/form_taylorMade/visitor_site_modal")]
        //public IActionResult visitor_site_modal()
        //{
        //    return View();
        //}
        public IActionResult sustainable_travelModal()
        {
            return View();
        }
        public IActionResult galeria_productModal()
        {
            return View();
        }
        public IActionResult galeria2_productModal()
        {
            return View();
        }
        public IActionResult galeria3_productModal()
        {
            return View();
        }
        public IActionResult galeria4_productModal()
        {
            return View();
        }
        public IActionResult availabilityModal()
        {
            return View();
        }
        public IActionResult cabinaModal()
        {
            return View();
        }
        public IActionResult formDailyTours()
        {
            return View();
        }
        public IActionResult island_hopping() {
            return View();
        }
        public IActionResult ecuador_continental() {
            return View();
        }
        public IActionResult galeriaItiner()
        {
            return View();
        }
        public IActionResult correo() {
            return View();
        }
        public IActionResult visitor_modal() {
            return View();
        }
        public IActionResult itinerary() {
            return View();
        }

        

        [HttpGet]
        public IActionResult form_taylorMade()
        {


            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;

            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());

            var ipAddress = heserver.AddressList.ToList().Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();


            ViewData["IP"] = ipAddress ; 
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Form_Package()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            string[] words = urlData[1].Split('/');
            var idVistaEc = 0;
            if (words.Count() == 3)
            {
                switch (words[2])
                {
                    case "avenue-of-volcanoes":
                        idVistaEc = 3052;
                        break;
                    case "austral-paths":
                        idVistaEc = 3053;
                        break;
                    case "magical-north":
                        idVistaEc = 3054;
                        break;
                    case "cloud-forest":
                        idVistaEc = 2051;
                        break;
                    case "amazon-tours-ecuador":
                        idVistaEc = 2050;
                        break;
                }
            }
            //itinerarios 
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVistaEc);
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;

            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());

            var ipAddress = heserver.AddressList.ToList().Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();


            ViewData["IP"] = ipAddress;
            ViewBag.TituloPrice = contendido;
            return View();
        }


        


        [HttpGet]
        public async Task<IActionResult> form_DailyToursAsync()
        {
            var urlProducto = getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 0;
            //=====ID es null
            if (words.Count() == 4)
            {
                switch (words[3])
                {
                    case "sierra-negra":
                        idVista = 2027;
                        break;
                    case "tintoreras-islet":
                        idVista = 2029;
                        break;
                    case "cabo-rosa-tuneles":
                        idVista = 2026;
                        break;
                    case "espanola-island":
                        idVista = 2030;
                        break;
                    case "kicker-rock":
                        idVista = 2031;
                        break;
                    case "pitt-point":
                        idVista = 2032;
                        break;
                    case "bartolome-island-sullivan-bay":
                        idVista = 2033;
                        break;
                    case "north-seymour":
                        idVista = 2035;
                        break;
                    case "south-plazas":
                        idVista = 2036;
                        break;
                }
            }
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            //Enviar datos a la vista Home
            ViewBag.GetContenidoVista = contendido;
            var dailyForm = new List<DailyForm>()
            {
                new DailyForm(){ EmailLeads= "detrish1@gmail.com", Day =DateTime.Parse( "Jan 1, 2009"), Passenger=3,Message="vale paypal"}
            };
            return View();
        }
        //Pagos en Paypal
        public IActionResult AuthorizePayment(string email, string name, DateTime fecha, string form, string obser, string nombreProduct,int pasajero, decimal precio)
        {
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = heserver.AddressList.ToList().Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();
            List<emailsDaily> detalleProd = new List<emailsDaily>();
            var precioTotal = precio * pasajero;
            detalleProd.Add(new emailsDaily(){
                NombrePaypal = name,
                EmailPaypal = email,
                PasajeroPaypal = pasajero,
                PrecioProducto = precio,
                ProductoPaypal = nombreProduct.ToString(),
                ObservacionPaypal = obser,
                FechaInicioPaypal = fecha,
                FechaFinPaypal = fecha,
                WebProvenientePaypal = form,
                PrecioPaypal = precioTotal,
                IDStatusPaypal = 0,
                IPPaypal = ipAddress,
            });
            var payment = PayPalPaymentService.CreatePayment(GetBaseUrl(), "authorize", detalleProd);
            _repo.SendFormDaily(detalleProd[0].EmailPaypal, "No Authorize", detalleProd[0].WebProvenientePaypal, detalleProd[0].FechaInicioPaypal, detalleProd[0].NombrePaypal,"EC", "UI", payment.id, detalleProd[0].IPPaypal, detalleProd[0].ObservacionPaypal, detalleProd[0].ProductoPaypal, detalleProd[0].PrecioPaypal, detalleProd[0].PasajeroPaypal,detalleProd[0].IDStatusPaypal);
            return Redirect(payment.GetApprovalUrl());
        }
        public string GetBaseUrl()
        {
            return Request.Scheme + "://" + Request.Host;
        }
        public IActionResult AuthorizeSuccessful(string paymentId, string token, string PayerID)
        {
            // Capture Payment
            //var capture = PayPalPaymentService.CapturePayment(paymentId);
            //Ejecutar Pago 
            var payment = PayPalPaymentService.ExecutePayment(paymentId, PayerID);
            int status = 1;
            _repo.UpdateFormDaily(PayerID, paymentId, status);
            return Redirect("/thank_you_page/thank_you_page_daily_tours");
        }
        [Route("/DispoBarco")]
        [HttpGet]
        public async Task<ActionResult<List<Availability>>> GetDisponi()
        {
            return await _repo.GetDispo();
        }
        //public TaylorFrom MapEmail(SqlDataReader reader)
        //{
        //    return new TaylorFrom()
        //    {
        //        NombreLeads = reader["NombreLeads"].ToString(),
        //        EmailLeads = reader["EmailLeads"].ToString(),
        //        ObservacionLeads = reader["ObservacionLeads"].ToString(),
        //        FromProveniente = reader["FromProveniente"].ToString()
        //    };
        //}
        public IActionResult galapagos_travel_guide() {
            return View();
        }
        public IActionResult ecuador_travel_guide()
        {
            return View();
        }
        public IActionResult haciendas_ecuador()
        {
            return View();
        }
        public List<String> getUrlPage(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var host = $"{context.Request.Scheme}://{context.Request.Host}";
            var urlCategories = context.Request.Path.Value;
            List<string> urlPagina = new List<string>();
            urlPagina.Add(host);
            urlPagina.Add(urlCategories);

            return urlPagina;
        }
    }
}
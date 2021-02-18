using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace AndandoToursWeb.Data
{
    public class AndandoRepositorio
    {
        private readonly string _connectionString;
        private readonly string _connnectionAndandoWeb, _connectionEmail;

        private readonly IHostingEnvironment _env;


        public AndandoRepositorio(IConfiguration configuration, IHostingEnvironment env)
        {
            _connectionString = configuration.GetConnectionString("AndandoContext");
            _connnectionAndandoWeb = configuration.GetConnectionString("GCMAndandoWeb");
            _connectionEmail = configuration.GetConnectionString("AndandoEmail");

            _env = env;
        }
        public async Task<List<BarcoWeb>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_GetBarcoWeb", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<BarcoWeb>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToBarcoWeb(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        //=================Mapa========================
        public async Task<List<Map>> GetMapa()
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ConsultaMapa", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<Map>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToConsultMap(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public Map MapToConsultMap(SqlDataReader reader)
        {
            return new Map()
            {
                IdMapaHotel = (int)reader["IdMapaHotel"],
                NombreHotel = reader["NombreHotel"].ToString(),
                DescripcionHotel = reader["DescripcionHotel"].ToString(),
                FotoHotel = reader["FotoHotel"].ToString(),
                Region = reader["Region"].ToString(),
                Foto1 = reader["Foto1"].ToString(),
                Foto2 = reader["Foto2"].ToString(),
                Foto3 = reader["Foto3"].ToString(),
                Foto4 = reader["Foto4"].ToString(),
                LatitudHotel = (Decimal)reader["LatitudHotel"],
                LongitudHotel = (Decimal)reader["LongitudHotel"],
                IdProveedor = ConvertInt.SafeGetInt(reader, "IdProveedor"),
            };
        }
        //=================ITINERARIO EAST WEST EAST 1EAST2========================
        public async Task<List<ItinerBarcoBtn>> GetItinerBarcoBtn(int idBarco)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_GetItinerarioBarcos", sql))
                {
                    cmd.Parameters.Add("@IDBarco", System.Data.SqlDbType.Int).Value = idBarco;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<ItinerBarcoBtn>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToItinerBarcoBtn(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        //=================Cargar MetaDatos Paginas Web========================
        public async Task<List<Metadata>> GetMetadata(int idVista)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetMetaData", sql))
                {
                    cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = idVista;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var contenidoPagina = new List<Metadata>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contenidoPagina.Add(MapGetMetadata(reader));
                        }
                    }
                    return contenidoPagina;
                }
            }
        }
        public Metadata MapGetMetadata(SqlDataReader reader)
        {
            return new Metadata()
            {
                idVista = (int)reader["IdVista"],
                idMetadata = (int)reader["IdMetadata"],
                MetaTitulo = reader["MetaTitulo"].ToString(),
                MetaDescripcion = reader["MetaDescripcion"].ToString(),
                MetaURL = reader["MetaURL"].ToString(),
                MetaReview = reader["MetaReview"].ToString(),
                MetaKeywords = reader["MetaKeywords"].ToString(),
            };
        }
        //=================Cargar Datos de las Vistas del CMS========================
        public async Task<List<GetContenidoVista>> GetContenidoPaginaWeb(int idVista)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetContenidoVista", sql))
                {
                    cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = idVista;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var contenidoPagina = new List<GetContenidoVista>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contenidoPagina.Add(MapGetContenidoPagina(reader));
                        }
                    }
                    return contenidoPagina;
                }
            }
        }
        public GetContenidoVista MapGetContenidoPagina(SqlDataReader reader)
        {
            return new GetContenidoVista()
            {
                idVista = (int)reader["IdVista"],
                nombreVista = reader["Pagina"].ToString(),
                Titulo = reader["Titulo"].ToString(),
                Parrafo = reader["Parrafo"].ToString(),
            };
        }


        //=================Cargar Imagenes al menu ========================
        public async Task<List<GetContenidoMultimedia>> GetImgMenu()
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetImagenesMenu", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var contenidoPagina = new List<GetContenidoMultimedia>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contenidoPagina.Add(MapGetImgMenu(reader));
                        }
                    }
                    return contenidoPagina;
                }
            }
        }

        public GetContenidoMultimedia MapGetImgMenu(SqlDataReader reader)
        {
            return new GetContenidoMultimedia()
            {
                idVista = (int)reader["IdVista"],
                NombreImagen = reader["NombreImagen"].ToString(),
                UrlImagen = reader["UrlImagen"].ToString(),
            };
        }

        //=================Cargar Imegens de las Vistas del CMS========================
        public async Task<List<GetContenidoMultimedia>> GetContenidoMultimedia(int idVista)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetContenidoMultimediaI", sql))
                {
                    cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = idVista;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var contenidoPagina = new List<GetContenidoMultimedia>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contenidoPagina.Add(MapGetContenidoMultimedia(reader));
                        }
                    }
                    return contenidoPagina;
                }
            }
        }
        public GetContenidoMultimedia MapGetContenidoMultimedia(SqlDataReader reader)
        {
            return new GetContenidoMultimedia()
            {
                idVista = (int)reader["IdVista"],
                nombreVista = reader["Pagina"].ToString(),
                NombreImagen = reader["NombreImagen"].ToString(),
                UrlImagen = reader["UrlImagen"].ToString(),
            };
        }
        public List<Availability> SendEmail(string email, string name, string taylor, string obser)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionEmail);
            var n = name;
            var e = email;
            var t = taylor;
            var o = obser;
            var responde1 = new List<Availability>();
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("api.sp_CreateLeadsCRM", cnn);
                cmd.Parameters.AddWithValue("@NombreLeads", n);
                cmd.Parameters.AddWithValue("@EmailLeads", e);
                cmd.Parameters.AddWithValue("@ObservacionLeads", o);
                cmd.Parameters.AddWithValue("@FromProveniente", t);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    responde1.Add(MapEmail(reader));
                }
            }
            return responde1;
        }


        //Formulario TaylorMade
        public List<Availability> SendEmailTaylorMade(string Email, string Name, string FechaDesde,
            string FechaFin, string NumeroPax, string Budget, string Observacion, string taylor,
            string IP, string CountryCode, string CityName)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionEmail);
            var EmailAdd = Email;
            var NameAdd = Name;
            var FechaDesdeAdd = FechaDesde;
            var FechaFinAdd = FechaFin;
            var NumeroPaxAdd = NumeroPax;
            var BudgetAdd = Budget;
            var ObservacionAdd = Observacion;
            var taylorAdd = taylor;
            var IPAdd = IP;
            var CountryCodeAdd = CountryCode;
            var CityNameAdd = CityName;
            var responde1 = new List<Availability>();
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("[api].[sp_CreateLeadsTaylorMade]", cnn);
                cmd.Parameters.AddWithValue("@TMEmail", EmailAdd);
                cmd.Parameters.AddWithValue("@TMNombre", NameAdd);
                cmd.Parameters.AddWithValue("@TMFechaInicio", FechaDesdeAdd);
                cmd.Parameters.AddWithValue("@TMFechaFin", FechaFinAdd);
                cmd.Parameters.AddWithValue("@TMNumeroPersonas", NumeroPaxAdd);
                cmd.Parameters.AddWithValue("@TMPresupuesto", BudgetAdd);

                if (ObservacionAdd == null)
                {
                    cmd.Parameters.AddWithValue("@TMDetalles", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TMDetalles", ObservacionAdd);

                }


                cmd.Parameters.AddWithValue("@TMIP", IPAdd);
                cmd.Parameters.AddWithValue("@TMPais", CountryCodeAdd);
                cmd.Parameters.AddWithValue("@TMCiudad", CityNameAdd);
                cmd.Parameters.AddWithValue("@TMWebProveniente", taylorAdd);
                cmd.Parameters.AddWithValue("@TMTipo", 1);
                cmd.Parameters.Add("@IDLeadsTaylorMade", System.Data.SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    responde1.Add(MapEmail(reader));
                }
            }
            return responde1;
        }


        //Formulario Galapagos Services
        public List<Availability> SendEmailPackage(string Email, string Name, string FechaDesde,
              string NumeroPax, string Category, string taylor,
            string IP, string CountryCode, string CityName, string TipoTours)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionEmail);
            var EmailAdd = Email;
            var NameAdd = Name;
            var FechaDesdeAdd = FechaDesde;

            var NumeroPaxAdd = NumeroPax;
            var CategoryAdd = Category;
            var TipoToursAdd = TipoTours;

            var taylorAdd = taylor;
            var IPAdd = IP;
            var CountryCodeAdd = CountryCode;
            var CityNameAdd = CityName;
            var responde1 = new List<Availability>();
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("[api].[sp_CreateLeadsGalapagosServices]", cnn);
                cmd.Parameters.AddWithValue("@TMEmail", EmailAdd);
                cmd.Parameters.AddWithValue("@TMNombre", NameAdd);
                cmd.Parameters.AddWithValue("@TMFechaInicio", FechaDesdeAdd);

                cmd.Parameters.AddWithValue("@TMNumeroPersonas", NumeroPaxAdd);
                cmd.Parameters.AddWithValue("@TMTipoCategoria", CategoryAdd);
                cmd.Parameters.AddWithValue("@TMTipoTours", TipoToursAdd);




                cmd.Parameters.AddWithValue("@TMIP", IPAdd);
                cmd.Parameters.AddWithValue("@TMPais", CountryCodeAdd);
                cmd.Parameters.AddWithValue("@TMCiudad", CityNameAdd);
                cmd.Parameters.AddWithValue("@TMWebProveniente", taylorAdd);


                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    responde1.Add(MapEmail(reader));
                }
            }
            return responde1;
        }

        //Metodo Guardar Datos del barco (itinerario, idSalida) con el correo y cliente 
        public void CreateLeadsBoats(string nombreBarco, string itinerario, string noches, string salCodigo, string correo, string nombre, string nummeroMax, string observacion)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("api.sp_CreateLeadsBoat", cnn);
                cmd.Parameters.AddWithValue("@Barco", nombreBarco);
                cmd.Parameters.AddWithValue("@Itinerario", itinerario);
                cmd.Parameters.AddWithValue("@Noches", noches);
                cmd.Parameters.AddWithValue("@SalCodigo", salCodigo);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@NummeroPax", nummeroMax);
                cmd.Parameters.AddWithValue("@OBservacion", observacion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();
        }
        public Availability MapEmail(SqlDataReader reader)
        {
            return new Availability()
            {
                NombreLeads = reader["NombreLeads"].ToString(),
                EmailLeads = reader["EmailLeads"].ToString(),
                ObservacionLeads = reader["ObservacionLeads"].ToString(),
                FromProveniente = reader["FromProveniente"].ToString()
            };
        }
        public void SendFormDaily(string email, string idUser, string form, DateTime fecha, string name, string pais, string ciudad, string idPaypal, string ipPaypal, string obser, string nombreProd, decimal precio, int pasajero, int status)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("api.sp_CreateLeadsPaypal", cnn);
                cmd.Parameters.AddWithValue("@NombrePaypal", name);
                cmd.Parameters.AddWithValue("@EmailPaypal", email);
                cmd.Parameters.AddWithValue("@PasajeroPaypal", pasajero);
                cmd.Parameters.AddWithValue("@PrecioPaypal", precio);
                cmd.Parameters.AddWithValue("@ProductoPaypal", nombreProd);
                cmd.Parameters.AddWithValue("@ObservacionPaypal", obser.ToString());
                cmd.Parameters.AddWithValue("@FechaInicioPaypal", fecha);
                cmd.Parameters.AddWithValue("@FechaFinPaypal", fecha);
                cmd.Parameters.AddWithValue("@IPPaypal", ipPaypal);
                cmd.Parameters.AddWithValue("@PaisPaypal", pais);
                cmd.Parameters.AddWithValue("@CiudadPaypal", ciudad);
                cmd.Parameters.AddWithValue("@WebProvenientePaypal", form);
                cmd.Parameters.AddWithValue("@IDPaypal", idPaypal);
                cmd.Parameters.AddWithValue("@IDUserPaypal", idUser);
                cmd.Parameters.AddWithValue("@IDStatusPaypal", status);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();
        }
        public void UpdateFormDaily(string idUserPayer, string idPaypal, int status)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("api.sp_UpdateLeadsPaypal", cnn);
                cmd.Parameters.AddWithValue("@IDUserPaypal", idUserPayer);
                cmd.Parameters.AddWithValue("@IDPaypal", idPaypal);
                cmd.Parameters.AddWithValue("@IDStatusPaypal", status);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();
        }
        private emailsDaily MapToUpdateDaily(SqlDataReader reader)
        {
            return new emailsDaily
            {
                IDPaypal = reader["CiudadPaypal"].ToString(),
                IDUserPaypal = reader["WebProvenientePaypal"].ToString(),
                IDStatusPaypal = ConvertInt.SafeGetInt(reader, "IDStatusPaypal"),
            };
        }
        private emailsDaily MapToEmailDaily(SqlDataReader reader)
        {
            return new emailsDaily
            {
                NombrePaypal = reader["NombrePaypal"].ToString(),
                EmailPaypal = reader["EmailPaypal"].ToString(),
                PasajeroPaypal = ConvertInt.SafeGetInt(reader, "PasajeroPaypal"),
                PrecioPaypal = (decimal)reader["PrecioPaypal"],
                ProductoPaypal = reader["ProductoPaypal"].ToString(),
                ObservacionPaypal = reader["ObservacionPaypal"].ToString(),
                FechaInicioPaypal = DateTime.Parse(reader["FechaInicioPaypal"].ToString()),
                FechaFinPaypal = DateTime.Parse(reader["FechaFinPaypal"].ToString()),
                IPPaypal = reader["IPPaypal"].ToString(),
                PaisPaypal = reader["PaisPaypal"].ToString(),
                CiudadPaypal = reader["CiudadPaypal"].ToString(),
                WebProvenientePaypal = reader["WebProvenientePaypal"].ToString(),
                IDPaypal = reader["CiudadPaypal"].ToString(),
                IDUserPaypal = reader["WebProvenientePaypal"].ToString(),
                IDStatusPaypal = ConvertInt.SafeGetInt(reader, "IDStatusPaypal"),
            };
        }
        public async Task<List<VisitorSite>> GetVisitorSite(int idVisitor)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ConsultaCarousel", sql))
                {
                    cmd.Parameters.Add("@IdVisitorSite", System.Data.SqlDbType.Int).Value = idVisitor;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<VisitorSite>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToVisitorSite(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public async Task<List<VisitorSite>> VisitorSiteFilterIsla(int idIsland)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_FiltroIslandVisitorSite", sql))
                {
                    cmd.Parameters.Add("@IdIsland", System.Data.SqlDbType.Int).Value = idIsland;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<VisitorSite>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToVisitorSite1(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public async Task<List<Wildlife>> GetFilterAnimal(int idIsla)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ListaAnimales", sql))
                {
                    cmd.Parameters.Add("@IdIsla", System.Data.SqlDbType.Int).Value = idIsla;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<Wildlife>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapWildlife(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public async Task<List<VisitorWildlife>> GetVisitorFilterAnimal(string idAnimal, int idIsla)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_FiltroWildlifeVisitorSite", sql))
                {
                    cmd.Parameters.Add("@IdAnimal", System.Data.SqlDbType.NVarChar).Value = idAnimal;
                    cmd.Parameters.Add("@IdIsland", System.Data.SqlDbType.Int).Value = idIsla;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<VisitorWildlife>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapVisitorWildlife(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public async Task<List<VisitorSite>> GetInfoVisitorSite(int idVisitor)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ConsultaVisitorSite", sql))
                {
                    cmd.Parameters.Add("@IdVisitorSite", System.Data.SqlDbType.Int).Value = idVisitor;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<VisitorSite>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToVisitorSite1(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public async Task<List<VisitorSite>> GetAllVisitor()
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ConsultaAllVisitorSite", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<VisitorSite>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToVisitorSite1(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public async Task<List<Team>> GetTeam()
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ConsultaTeam", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<Team>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToTeam(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public Wildlife MapWildlife(SqlDataReader reader)
        {
            return new Wildlife()
            {
                NombreAnimal = reader["NombreAnimal"].ToString(),
            };
        }
        public VisitorWildlife MapVisitorWildlife(SqlDataReader reader)
        {
            return new VisitorWildlife()
            {
                IdVisitorSite = (int)reader["IdVisitorSite"],
                NombreVisitorSite = reader["NombreVisitorSite"].ToString(),
                MetaDescripcion = reader["MetaDescripcion"].ToString(),
                UrlImagenVisitorSite = reader["UrlImagenVisitorSite"].ToString(),
                NombreImagenVisitorSite = reader["NombreImagenVisitorSite"].ToString(),
                IdAnimal = (int)reader["IdAnimal"],
                NombreAnimal = reader["NombreAnimal"].ToString(),
            };
        }

        public VisitorSite MapToVisitorSite(SqlDataReader reader)
        {
            return new VisitorSite()
            {
                IdVisitorSite = (int)reader["IdVisitorSite"],
                NombreImagen = reader["NombreImagen"].ToString(),
                UrlImagen = reader["UrlImagen"].ToString(),
                NombreVisitorSite = reader["NombreVisitorSite"].ToString(),
                DescripcionVisitorSite = reader["DescripcionVisitorSite"].ToString(),
                LatitudVisitorSite = reader["LatitudVisitorSite"].ToString(),
                LongitudVisitorSite = reader["LongitudVisitorSite"].ToString(),
                IdIsland = (int)reader["IdIsland"],
            };
        }
        public VisitorSite MapToVisitorSite1(SqlDataReader reader)
        {
            return new VisitorSite()
            {
                IdVisitorSite = (int)reader["IdVisitorSite"],
                NombreVisitorSite = reader["NombreVisitorSite"].ToString(),
                DescripcionVisitorSite = reader["DescripcionVisitorSite"].ToString(),
                LatitudVisitorSite = reader["LatitudVisitorSite"].ToString(),
                LongitudVisitorSite = reader["LongitudVisitorSite"].ToString(),
                WildLifeVisitorSite = reader["WildLifeVisitorSite"].ToString(),
                MetaDescripcion = reader["MetaDescripcion"].ToString(),
                MetaTitulo = reader["MetaTitulo"].ToString(),
                UrlImagenVisitorSite = reader["UrlImagenVisitorSite"].ToString(),
                NombreImagenVisitorSite = reader["NombreImagenVisitorSite"].ToString(),
                Actividad1VisitorSIte = reader["Actividad1VisitorSIte"].ToString(),
                Actividad2VisitorSIte = reader["Actividad2VisitorSIte"].ToString(),
                Actividad3VisitorSIte = reader["Actividad3VisitorSIte"].ToString(),
                Actividad4VisitorSIte = reader["Actividad4VisitorSIte"].ToString(),
                Actividad5VisitorSIte = reader["Actividad5VisitorSIte"].ToString(),
                Actividad6VisitorSIte = reader["Actividad6VisitorSIte"].ToString(),
                Animal1VisitorSIte = reader["Animal1VisitorSIte"].ToString(),
                Animal2VisitorSIte = reader["Animal2VisitorSIte"].ToString(),
                Animal3VisitorSIte = reader["Animal3VisitorSIte"].ToString(),
                Animal4VisitorSIte = reader["Animal4VisitorSIte"].ToString(),
            };
        }
        public Team MapToTeam(SqlDataReader reader)
        {
            return new Team()
            {
                IdTeam = (int)reader["IdTeam"],
                NombreTeam = reader["NombreTeam"].ToString(),
                ApellidoTeam = reader["ApellidoTeam"].ToString(),
                FotoTeam = reader["FotoTeam"].ToString(),
                CargoTeam = reader["CargoTeam"].ToString(),
                DepartamentoTeam = reader["DepartamentoTeam"].ToString(),
            };
        }
        private ItinerBarcoBtn MapToItinerBarcoBtn(SqlDataReader reader)
        {
            return new ItinerBarcoBtn()
            {
                IDBarco = (int)reader["IDBarco"],
                ItinNombre = (String)reader["ItinNombre"],
                BarcoNombre = (String)reader["BarcoNombre"],
                ItinNombreCor = (String)reader["ItinNombreCor"],
                ItinDiasCor = (int)reader["ItinDiasCor"],
                IDBarcoItinerario = (int)reader["IDBarcoItinerario"]
            };
        }
        //===========ITINERARIO DE BARCOS SLIDE ==================
        public async Task<List<ItinerarioBarco>> GetItinerBarco(int idBarco, int idItinerario)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_ViewItinerarioBarcosWeb", sql))
                {
                    cmd.Parameters.Add("@IDBarco", System.Data.SqlDbType.Int).Value = idBarco;
                    cmd.Parameters.Add("@IDItinerario", System.Data.SqlDbType.Int).Value = idItinerario;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<ItinerarioBarco>();
                    await sql.OpenAsync();
                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                responde.Add(MapToItinerarioBarco(reader));
                            }
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex) { }
                    return responde;
                }
            }
        }
        private ItinerarioBarco MapToItinerarioBarco(SqlDataReader reader)
        {
            return new ItinerarioBarco()
            {
                IDItinerario = ConvertInt.SafeGetInt(reader, "IDItinerario"),
                IDServicioTipo = ConvertInt.SafeGetInt(reader, "IDServicioTipo"),
                ServServicioEn = reader["ServServicioEn"].ToString(),
                IDProveedorTipo = ConvertInt.SafeGetInt(reader, "IDProveedorTipo"),
                DescripcionEn = (String)reader["DescripcionEn"],
                DescripcionEs = reader["DescripcionEs"].ToString(),
                DescripcionDe = reader["DescripcionDe"].ToString(),
                ItiLinkImagenCaratula = reader["ItiLinkImagenCaratula"].ToString(),
                ItiActivo = Boolean.TryParse(reader["ItiActivo"].ToString(), out bool value),
                NumeroDeDias = ConvertInt.SafeGetInt(reader, "NumeroDeDias"),
                IDBarco = ConvertInt.SafeGetInt(reader, "IDBarco"),
                ProvNombre = reader["ProvNombre"].ToString(),
                IDItinerarioDetallado = ConvertInt.SafeGetInt(reader, "IDItinerarioDetallado"),
                DiaNumero = ConvertInt.SafeGetInt(reader, "DiaNumero"),
                DiaParte = reader["DiaParte"].ToString(),
                Orden = ConvertInt.SafeGetInt(reader, "Orden"),
                ItiDetalladoActivo = Boolean.TryParse(reader["ItiDetalladoActivo"].ToString(), out bool value1),
                ItiCompNombre = reader["ItiCompNombre"].ToString(),
                ItiCompTituloEn = reader["ItiCompTituloEn"].ToString(),
                ItiCompTituloEs = reader["ItiCompTituloEs"].ToString(),
                ItiCompTituloDe = reader["ItiCompTituloDe"].ToString(),
                ItiCompDescripcionDescriptivoEn = reader["ItiCompDescripcionDescriptivoEn"].ToString(),
                ItiCompDescripcionDescriptivoEs = reader["ItiCompDescripcionDescriptivoEs"].ToString(),
                ItiCompDescripcionDescriptivoDe = reader["ItiCompDescripcionDescriptivoDe"].ToString(),
                ItiCompDescripcionVoucherEn = reader["ItiCompDescripcionVoucherEn"].ToString(),
                ItiCompDescripcionVoucherEs = reader["ItiCompDescripcionVoucherEs"].ToString(),
                ItiCompLinkImagen = reader["ItiCompLinkImagen"].ToString(),
                ItiCompLinkImagen2 = reader["ItiCompLinkImagen2"].ToString(),
                ItiCompLinkImagenVoucher = Boolean.TryParse(reader["ItiCompLinkImagenVoucher"].ToString(), out bool value2),
                ItiHighlightsEn = reader["ItiHighlightsEn"].ToString(),
                ItiHighlightsEs = reader["ItiHighlightsEs"].ToString(),
                ItiHighlightsDe = reader["ItiHighlightsDe"].ToString(),
                ItiLinkTituloDoc = reader["ItiLinkTituloDoc"].ToString(),
                UsarEnTituloDia = Boolean.TryParse(reader["UsarEnTituloDia"].ToString(), out bool value3),
                NumeroDeTituloEnDia = ConvertInt.SafeGetInt(reader, "NumeroDeTituloEnDia"),
                MostrarFotosEnDocumento = ConvertInt.SafeGetBoolean(reader, "MostrarFotosEnDocumento"),
                ItiHiking = ConvertInt.SafeGetBoolean(reader, "ItiHiking"),
                ItiSnorkeling = ConvertInt.SafeGetBoolean(reader, "ItiSnorkeling"),
                ItiPangaRiding = ConvertInt.SafeGetBoolean(reader, "ItiPangaRiding"),
                ItiPaddleBoarding = ConvertInt.SafeGetBoolean(reader, "ItiPaddleBoarding"),
                ItiDiving = ConvertInt.SafeGetBoolean(reader, "ItiDiving"),
                ItiKayaking = ConvertInt.SafeGetBoolean(reader, "ItiKayaking"),
            };
        }
        private BarcoWeb MapToBarcoWeb(SqlDataReader reader)
        {
            return new BarcoWeb()
            {
                IdBarco = (int)reader["IDBarco"],
                BarcoNombre = reader["BarcoNombre"].ToString(),
                BarcoNombreCorto = reader["BarcoNombreCorto"].ToString(),
                Barcocupo = (int)reader["BarcoCupo"],
                IDBarcoOperador = reader["IDBarcoOperador"].ToString(),
                IDBarcoTipo = (int)reader["IDBarcoTipo"],
                BarcoActivo = (Boolean)reader["BarcoActivo"],
                IDBarcoCategoriaTipo = (int)reader["IDBarcoCategoriaTipo"],
                BarcoCategoriaTipoNombreEn = reader["BarcoCategoriaTipoNombreEn"].ToString(),
                BarcoURL = reader["BarcoURL"].ToString(),
                BarcoDescripcionCortaEn = reader["BarcoDescripcionCortaEn"].ToString(),
                BarcoDescripcionCortaEs = reader["BarcoDescripcionCortaEs"].ToString(),
                BarcoDescripcionEn = reader["BarcoDescripcionEn"].ToString(),
                BarcoDescripcionEs = reader["BarcoDescripcionEs"].ToString(),
                BarcoIncluyeEn = reader["BarcoIncluyeEn"].ToString(),
                BarcoNoincluyeEn = reader["BarcoNoincluyeEn"].ToString(),
                BarcoWebEco = (Boolean)reader["BarcoWeb"],
                BarcoEcoDescripcion = reader["BarcoEcoDescripcion"].ToString(),
                BarcoEco = (Boolean)reader["BarcoEco"],
                BarcoPrecioMin = reader["PrecioMin"].ToString(),
                BarcoDiasItinerario = (int)reader["DiasItinerario"],
                BarcoImagen = reader["BarcoFoto"].ToString(),
            };
        }
        //=================Obtener Islas ========================
        public async Task<List<Island>> GetIsland()
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ConsultaIsland", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<Island>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToIsland(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        private Island MapToIsland(SqlDataReader reader)
        {
            return new Island()
            {
                IdIsland = (int)reader["IdIsland"],
                NombreIsland = reader["NombreIsland"].ToString(),
                DescripcionIsland = reader["DescripcionIsland"].ToString(),
                ImagenIsland = reader["ImagenIsland"].ToString(),
                LinkIsland = reader["LinkIsland"].ToString(),
                MostrarIsland = (Boolean)reader["MostrarIsland"],
            };
        }
        //=================Obtener  Dailytours========================
        public async Task<List<Dailytour>> GetDailytours(int id)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ConsultaDailyTour", sql))
                {
                    cmd.Parameters.AddWithValue("@IdIsland", id);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<Dailytour>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToDailyTour(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public Dailytour MapToDailyTour(SqlDataReader reader)
        {
            return new Dailytour()
            {
                IdDailytour = (int)reader["IdDailytour"],
                IdIsland = (int)reader["IdIsland"],
                NombreDailyTour = reader["NombreDailyTour"].ToString(),
                DescripcionDailyTour = reader["DescripcionDailyTour"].ToString(),
                ImagenDailyTour = reader["ImagenDailyTour"].ToString(),
                LinkDailytour = reader["LinkDailytour"].ToString(),
            };
        }
        //=================Consular TripPlanner(cruises,galapagos services) ========================
        public async Task<List<Producto>> GetProducto(string dataTripPlanner)
        {
            string[] tripFinder = dataTripPlanner.Split(',');
            string url1 = "https://www.api.galapagobookings.com/api/Availability";
            //string url = "https://www.galapagobookings.com/Disponibilidad";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Implc3VzQGFuZGFuZG90b3Vycy5jb20iLCJKTENvZGUiOiJUdUZ1dHVyb1NlRW5jdWVudHJhIEFxdWkiLCJqdGkiOiJkOTVkMGRmZS02ZWE4LTRhMGEtYTc5MS0xMjE5MGJkNDQ3MTEiLCJleHAiOjE2MDM5MjU3NTR9.qNp2FC88pjWDiMCFg4zj_PmzsvwEH0YZVaGj7kDlrsY");
            var json = await httpClient.GetStringAsync(url1);
            List<Availability> dispoList = JsonConvert.DeserializeObject<List<Availability>>(json);
            DateTime salFechaSalidaInicio = DateTime.Parse(tripFinder[4]);
            DateTime salFechaSalidaFin = DateTime.Parse(tripFinder[5]);
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_GetProducto", sql))
                {
                    cmd.Parameters.Add("@IDServicioTipo", System.Data.SqlDbType.Int).Value = int.Parse(tripFinder[0]);
                    cmd.Parameters.Add("@IDCategoriaProducto", System.Data.SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@FechaSalida", System.Data.SqlDbType.Date).Value = DateTime.Parse("2020-07-27");
                    cmd.Parameters.Add("@NumeroDeDias", System.Data.SqlDbType.Int).Value = int.Parse(tripFinder[6]);
                    cmd.Parameters.Add("@NumeroDePasajeros", System.Data.SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@PrecioMinimo", System.Data.SqlDbType.Decimal).Value = decimal.Parse(tripFinder[2]);
                    cmd.Parameters.Add("@PrecioMaximo", System.Data.SqlDbType.Decimal).Value = decimal.Parse(tripFinder[3]);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<Producto>();
                    var producto = new List<Producto>();
                    var listDisp = new List<Availability>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToProducto(reader));
                        }
                    }
                    if (int.Parse(tripFinder[0]) == 7)
                    {
                        var precio = "0";
                        foreach (var listBarco in dispoList)
                        {
                            if (DateTime.Parse(listBarco.salFechaSalida.ToString()) >= salFechaSalidaInicio && DateTime.Parse(listBarco.salFechaSalida.ToString()) <= salFechaSalidaFin)
                            {
                                if (listBarco.cabinaPrecio1 == "")
                                {
                                    precio = "0";
                                }
                                else
                                {
                                    precio = listBarco.cabinaPrecio1;
                                }
                                if (double.Parse(precio) >= double.Parse(tripFinder[2]) && double.Parse(precio) <= double.Parse(tripFinder[3]))
                                {
                                    if (listBarco.noches >= int.Parse(tripFinder[6]))
                                    {
                                        if (int.Parse(listBarco.totalDisponibilidad) >= int.Parse(tripFinder[1]))
                                        {
                                            listDisp.Add(listBarco);
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var res in responde)
                        {
                            foreach (var disp in listDisp)
                            {
                                if (res.IdServicio == disp.idBarco)
                                {
                                    if (producto.Count == 0)
                                    {
                                        producto.Add(res);
                                    }
                                    else
                                    {
                                        if (!producto.Exists(x => x.IdServicio.Equals(disp.idBarco)))
                                        {
                                            producto.Add(res);
                                        }
                                    }

                                }
                            }

                        }
                    }
                    else
                    {
                        producto = responde;
                    }
                    return producto;
                }
            }
        }
        public Producto MapToProducto(SqlDataReader reader)
        {
            return new Producto()
            {
                IdServicioTipo = (int)reader["IDServicioTipo"],
                ServicioTipoDescripcion = reader["ServicioTipoDescripcion"].ToString(),
                IdServicio = (int)reader["IDServicio"],
                Servicio = reader["Servicio"].ToString(),
                ServicioDescripcion = reader["ServicioDescripcion"].ToString(),
                IdItinerario = (int)reader["IDItinerario"],
                ItinNombre = reader["ItinNombre"].ToString(),
                ItinerarioDuracion = (int)reader["ItinerarioDuracion"],
                ItinerarioDuracionDescripcion = reader["ItinerarioDuracionDescripcion"].ToString(),
                URLFoto = reader["URLFoto"].ToString(),
                MinPriceCategoria = (decimal)reader["MinPriceCategoria"],
                Fecha = DateTime.Parse(reader["Fecha"].ToString()),
            };
        }
        public Availability MapToBarcoDispo(SqlDataReader reader)
        {
            return new Availability()
            {
                idBarco = (int)reader["IdBarco"],
                idSalida = (int)reader["IdSalida"],
                barcoNombre = reader["BarcoNombre"].ToString(),
                salFechaSalida = DateTime.Parse(reader["SalFechaSalida"].ToString()),
                salFechaRetorno = DateTime.Parse(reader["SalFechaRetorno"].ToString()),
                totalDisponibilidad = reader["TotalDisponibilidad"].ToString(),
                anio = reader["IDAnio"].ToString(),
                itinNombre = reader["ItinNombre"].ToString(),
                TipoCabina1 = reader["TipoCabina1"].ToString(),
                Dispo_CabinaTipo1 = (int)reader["Dispo_CabinaTipo1"],
                TipoCabina2 = reader["TipoCabina2"].ToString(),
                Dispo_CabinaTipo2 = (int)reader["Dispo_CabinaTipo2"],
                cabinaPrecio1 = reader["CabinaPrecio1"].ToString(),
                cabinaPrecio2 = reader["CabinaPrecio2"].ToString(),
            };
        }
        public async Task<List<Availability>> GetDispo()
        {
            string url = "https://api.galapagobookings.com/api/Availability";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlBlZHJvQGdtYWlsLmNvbSIsIkpMQ29kZSI6IlR1RnV0dXJvU2VFbmN1ZW50cmEgQXF1aSIsImp0aSI6IjM5YWQ2Y2RmLTZjMGItNDNjZC04YjAxLTc5YjZlZDM0ZjY0ZiIsImV4cCI6MTYzNjIyMTI1Nn0.EvO7k48fbZXmxAMrERHROh3HAaszHppIu4ym90TVXBk");
            var json = await httpClient.GetStringAsync(url);
            List<Availability> dispoList = JsonConvert.DeserializeObject<List<Availability>>(json);
            return dispoList;
        }
        public async Task<List<Availability>> GetDispoOtrosBarcos()
        {
            string url = "https://api.galapagobookings.com/dispo/AvailabilityOtros/AllDispoOtros";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlBlZHJvQGdtYWlsLmNvbSIsIkpMQ29kZSI6IlR1RnV0dXJvU2VFbmN1ZW50cmEgQXF1aSIsImp0aSI6IjM5YWQ2Y2RmLTZjMGItNDNjZC04YjAxLTc5YjZlZDM0ZjY0ZiIsImV4cCI6MTYzNjIyMTI1Nn0.EvO7k48fbZXmxAMrERHROh3HAaszHppIu4ym90TVXBk");
            var json = await httpClient.GetStringAsync(url);
            List<Availability> dispoList = JsonConvert.DeserializeObject<List<Availability>>(json);
            return dispoList;
        }
        public async Task<List<GetFeaturesProduct>> GetFeaturesProduct(int idBarco)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_ViewBarcoCaracteristica", sql))
                {
                    cmd.Parameters.Add("@IDBarco", System.Data.SqlDbType.Int).Value = idBarco;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var features = new List<GetFeaturesProduct>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            features.Add(MapGetFeaturesProducto(reader));
                        }
                    }
                    return features;
                }
            }
        }
        public GetFeaturesProduct MapGetFeaturesProducto(SqlDataReader reader)
        {
            return new GetFeaturesProduct()
            {
                IdBarcoCaracteristica = (int)reader["IdBarcoCaracteristica"],
                IdBarco = (int)reader["IdBarco"],
                IdBarcoCaracteristicaFoto = (int)reader["IdBarcoCaracteristicaFoto"],
                BarcoNombreCaracteristica = reader["BarcoNombreCaracteristica"].ToString(),
                BarcoImagenCaracteristica = reader["BarcoImagenCaracteristica"].ToString(),
            };
        }
        public async Task<List<VisitorSite>> GetVisitorSitesModal(int idItinerDetallado)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ViewVisitorSites", sql))
                {
                    cmd.Parameters.Add("@IDItinerarioDetallado", System.Data.SqlDbType.Int).Value = idItinerDetallado;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var contenidoPagina = new List<VisitorSite>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contenidoPagina.Add(MapToVisitorSite1(reader));
                        }
                    }
                    return contenidoPagina;
                }
            }
        }
        public async Task<List<CategoriaBarco>> GetCategoriaBarcos()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_GetBarcoCategoria", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var contenidoPagina = new List<CategoriaBarco>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contenidoPagina.Add(MapToCategoriaBarco(reader));
                        }
                    }
                    return contenidoPagina;
                }
            }
        }

        private CategoriaBarco MapToCategoriaBarco(SqlDataReader reader)
        {
            return new CategoriaBarco()
            {
                IDBarcoCategoriaTipo = (int)reader["IDBarcoCategoriaTipo"],
                BarcoCategoriaTipoNombreEn = reader["BarcoCategoriaTipoNombreEn"].ToString(),
                BarcoCategoriaTipoNombreEs = reader["BarcoCategoriaTipoNombreEs"].ToString(),
                BarcoCategoriaTipoNombreDe = reader["BarcoCategoriaTipoNombreDe"].ToString(),
                BarcoCategoriaTipoDescripcionEn = reader["BarcoCategoriaTipoDescripcionEn"].ToString(),
                BarcoCategoriaTipoDescripcionEs = reader["BarcoCategoriaTipoDescripcionEs"].ToString(),
                BarcoCategoriaTipoActivo = Boolean.TryParse(reader["BarcoCategoriaTipoActivo"].ToString(), out bool value1),
                BarcoCategoriaTipoOrden = ConvertInt.SafeGetInt(reader, "BarcoCategoriaTipoOrden"),
            };
        }
        public async Task<List<ItinEcuadorBtn>> GetItinerEcuadorBtn(int idVista)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ViewItinerarioEcuadorBtn", sql))
                {
                    cmd.Parameters.Add("@IDVista", System.Data.SqlDbType.Int).Value = idVista;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<ItinEcuadorBtn>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToItinerEcuadorBtn(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public ItinEcuadorBtn MapToItinerEcuadorBtn(SqlDataReader reader)
        {
            return new ItinEcuadorBtn()
            {
                IdItinerarioBtn = (int)reader["IdItinerarioBtn"],
                IdVista = (int)reader["IdVista"],
                ItinNombre = reader["ItinNombre"].ToString(),
                ItinNombreCor = reader["ItinNombreCor"].ToString(),
                NombreVista = reader["NombreVista"].ToString(),
            };
        }
        //ITINERARIOS ECUADOR
        public async Task<List<ItinEcuadorDeta>> GetItinerEcuadorDeta(int idItinerario)
        {
            using (SqlConnection sql = new SqlConnection(_connnectionAndandoWeb))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_ViewItinerarioEcuador", sql))
                {
                    cmd.Parameters.Add("@IDItinerarioDetallado", System.Data.SqlDbType.Int).Value = idItinerario;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var responde = new List<ItinEcuadorDeta>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            responde.Add(MapToItinEcuadorDeta(reader));
                        }
                    }
                    return responde;
                }
            }
        }
        public ItinEcuadorDeta MapToItinEcuadorDeta(SqlDataReader reader)
        {
            return new ItinEcuadorDeta()
            {
                IdItinerario = (int)reader["IdItinerario"],
                IdItinerarioBtn = (int)reader["IdItinerarioBtn"],
                ItinNombre = reader["ItinNombre"].ToString(),
                ItiLinkImagenCaratula = reader["ItinLinkImagenCaratula"].ToString(),
                ItinTituloEn = reader["ItinTituloEn"].ToString(),
                NumeroDeDias = (int)reader["NumeroDeDias"],
                DiaNumero = (int)reader["DiaNumero"],
                ItinDescripcionEn = reader["ItinDescripcionEn"].ToString(),
            };
        }

        public async Task<List<ViewIslandHoppingPaquete>> GetViewIslandHoppingPaquetes()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_ViewWebIslandHoppingYPaquete", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var IslandHoppingPaquete = new List<ViewIslandHoppingPaquete>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            IslandHoppingPaquete.Add(MapToViewIslandHoppingPaquetes(reader));
                        }
                    }

                    var IslandHopping = new List<ViewIslandHoppingPaquete>();
                    Dictionary<int, int> uniqueStore = new Dictionary<int, int>();

                    foreach (var item in IslandHoppingPaquete)
                    {

                        if (!uniqueStore.ContainsKey(item.IDItinerario))
                        {
                            uniqueStore.Add(item.IDItinerario, 0);
                            IslandHopping.Add(item);
                        }
                    }

                    return IslandHopping;

                }
            }
        }
        public async Task<List<ViewIslandHoppingPaquete>> GetIslandHoppingPaquetesFindIDItinerario(int idItinerario)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_GetwWebIslandHoppingYPaquete", sql))
                {
                    cmd.Parameters.Add("@IDItinerario", System.Data.SqlDbType.Int).Value = idItinerario;
                    cmd.Parameters.Add("@FechaDesde", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var IslandHoppingPaquete = new List<ViewIslandHoppingPaquete>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            IslandHoppingPaquete.Add(MapToGetIslandHoppPaq(reader));
                        }
                    }

                    return IslandHoppingPaquete;

                }
            }
        }
        public ViewIslandHoppingPaquete MapToViewIslandHoppingPaquetes(SqlDataReader reader)
        {
            return new ViewIslandHoppingPaquete()
            {
                IDWebIslandHoppingYPaquete = (int)reader["IDWebIslandHoppingYPaquete"],
                NombreIslandHoppingYPaquete = reader["NombreIslandHoppingYPaquete"].ToString(),
                IDItinerario = (int)reader["IDItinerario"],
                NumeroDias = ConvertInt.SafeGetInt(reader, "NumeroDias") ,
                Proveedor = reader["Proveedor"].ToString(),
                FotoPrincipal = reader["FotoPrincipal"].ToString(),
                Categoria = reader["Categoria"].ToString(),
                Precio = reader["Precio"].ToString(),
                PrecioDescuento = reader["PrecioDescuento"].ToString(),
                Highlights = reader["Highlights"].ToString(),
                DescripcionCorta = reader["DescripcionCorta"].ToString(),
                DescripcionLarga = reader["DescripcionLarga"].ToString(),
                IslandHoppingYPaqueteTipo = reader["IslandHoppingYPaqueteTipo"].ToString(),
                NumeroDiasTexto= reader["NumeroDiasTexto"].ToString(),
            };
        }
        public ViewIslandHoppingPaquete MapToGetIslandHoppPaq(SqlDataReader reader)
        {
            return new ViewIslandHoppingPaquete()
            {
                IDWebIslandHoppingYPaquete = (int)reader["IDWebIslandHoppingYPaquete"],
                NombreIslandHoppingYPaquete = reader["NombreIslandHoppingYPaquete"].ToString(),
                IDItinerario = (int)reader["IDItinerario"],
                NumeroDias = ConvertInt.SafeGetInt(reader, "NumeroDias"),
                Proveedor = reader["Proveedor"].ToString(),
                FotoPrincipal = reader["FotoPrincipal"].ToString(),
                Categoria = reader["Categoria"].ToString(),
                Precio = reader["Precio"].ToString(),
                PrecioDescuento = reader["PrecioDescuento"].ToString(),
                Highlights = reader["Highlights"].ToString(),
                DescripcionCorta = reader["DescripcionCorta"].ToString(),
                DescripcionLarga = reader["DescripcionLarga"].ToString(),
                IslandHoppingYPaqueteTipo = reader["IslandHoppingYPaqueteTipo"].ToString(),
            };
        }
        public async Task<List<ItinerarioBarco>> GetPaquetesIDItinerarioDetallado(int idItinerario)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("api.sp_ViewItinerarioDetalladoFinal", sql))
                {
                    cmd.Parameters.Add("@IDItinerario", System.Data.SqlDbType.Int).Value = idItinerario;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var IslandHoppingPaquete = new List<ItinerarioBarco>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            IslandHoppingPaquete.Add(MapToItinerarioIslas(reader));
                        }
                    }

                    return IslandHoppingPaquete;

                }
            }
        }
        private ItinerarioBarco MapToItinerarioIslas(SqlDataReader reader)
        {
            return new ItinerarioBarco()
            {
                IDItinerario = ConvertInt.SafeGetInt(reader, "IDItinerario"),
                IDServicioTipo = ConvertInt.SafeGetInt(reader, "IDServicioTipo"),
                ServServicioEn = reader["ServServicioEn"].ToString(),
                IDItinerarioDetallado = ConvertInt.SafeGetInt(reader, "IDItinerarioDetallado"),
                DiaNumero = ConvertInt.SafeGetInt(reader, "DiaNumero"),
                DiaParte = reader["DiaParte"].ToString(),
                Orden = ConvertInt.SafeGetInt(reader, "Orden"),
                ItiDetalladoActivo = Boolean.TryParse(reader["ItiDetalladoActivo"].ToString(), out bool value1),
                ItiCompNombre = reader["ItiCompNombre"].ToString(),
                ItiCompTituloEn = reader["ItiCompTituloEn"].ToString(),
                ItiCompTituloEs = reader["ItiCompTituloEs"].ToString(),
                ItiCompTituloDe = reader["ItiCompTituloDe"].ToString(),
                ItiCompDescripcionDescriptivoEn = reader["ItiCompDescripcionDescriptivoEn"].ToString(),
                ItiCompDescripcionDescriptivoEs = reader["ItiCompDescripcionDescriptivoEs"].ToString(),
                ItiCompDescripcionDescriptivoDe = reader["ItiCompDescripcionDescriptivoDe"].ToString(),
                ItiCompDescripcionVoucherEn = reader["ItiCompDescripcionVoucherEn"].ToString(),
                ItiCompDescripcionVoucherEs = reader["ItiCompDescripcionVoucherEs"].ToString(),
                ItiCompLinkImagen = reader["ItiCompLinkImagen"].ToString(),
                UsarEnTituloDia = Boolean.TryParse(reader["UsarEnTituloDia"].ToString(), out bool value3),
                MostrarFotosEnDocumento = ConvertInt.SafeGetBoolean(reader, "MostrarFotosEnDocumento"),
            };
        }

        
        public List<String> getUrlPage(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var host = $"{context.Request.Scheme}://{context.Request.Host}";
            var urlCategories = context.Request.Path.Value;
            List<string> urlPagina = new List<string>();
            urlPagina.Add(host);
            urlPagina.Add(urlCategories);
            //MicrosoftHostGetCore.hostget.getipDat(urlPagina, _env.WebRootPath);
            return urlPagina;
            // Other code
        }

    }
}
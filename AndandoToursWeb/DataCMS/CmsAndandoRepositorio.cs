using AndandoToursWeb.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using AndandoToursWeb.Models.ModelsCMS;
using AndandoToursWeb.Models.ModelsAndandoTours;
using System.Data;

namespace AndandoToursWeb.DataCMS
{
    public class CmsAndandoRepositorio
    {
        private readonly string _connectionString;

        public CmsAndandoRepositorio(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("GCMAndandoWeb");
        }

        public async Task<List<GetContenidoPagina>> GetContenidoPAginaWeb(int IdVista) {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetContenidoVista", sql))
                {
                    cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = IdVista;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var contenidoPagina = new List<GetContenidoPagina>();
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


        //=================Crear Contenido Paginas Web========================
        public String NewContenidoPaginaWeb(CreateContenido nPagina)
        {
            string id = "";

            try
            {

                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_CreaateContenido", sql))
                    {
                        cmd.Parameters.Add("@NombreVista", System.Data.SqlDbType.VarChar).Value = nPagina.NombreVista;
                        cmd.Parameters.Add("@UrlVista", System.Data.SqlDbType.VarChar).Value = nPagina.UrlVista;
                        cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.VarChar).Value = nPagina.Categoria;
                        cmd.Parameters.Add("@TituloMeta", System.Data.SqlDbType.VarChar).Value = nPagina.TituloMeta;
                        cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar).Value = nPagina.DescripcionMeta;
                        cmd.Parameters.Add("@numTitulos", System.Data.SqlDbType.Int).Value = nPagina.NumeroTitulo;
                        cmd.Parameters.Add("@numImagenes", System.Data.SqlDbType.Int).Value = nPagina.NumeroImagenes;
                        //cmd.Parameters.Add("@IdVista", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //SqlParameter RuturnValue = new SqlParameter("@IdVista", SqlDbType.Int);

                        var returnParameter = cmd.Parameters.Add("@IdVista", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                       
                        //cmd.Parameters.Add(RuturnValue);
                        
                        cmd.ExecuteNonQuery();
                        id = returnParameter.Value.ToString();
                        sql.Close();

                        return id;
                    }
                }

               
            }
            catch(Exception ex)
            {
                return "Error";
            }

           
        }


        public void AddItinearioEcu(ItinEcuadorBtn model)
        {
            

            try
            {

                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_CreateItinerarioEcuador", sql))
                    {
                        
                        cmd.Parameters.Add("@ItinNombre", System.Data.SqlDbType.VarChar).Value = model.ItinNombre;
                        cmd.Parameters.Add("@ItinNomCorto", System.Data.SqlDbType.VarChar).Value = model.ItinNombreCor;
                        //cmd.Parameters.Add("@NombreVista", System.Data.SqlDbType.VarChar).Value = model.NombreVista;
                        cmd.Parameters.Add("@numItin", System.Data.SqlDbType.Int).Value = model.numItiner;
                        cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = model.IdVista;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                       
                        sql.Close();

                        
                    }
                }


            }
            catch (Exception ex)
            {
                
            }


        }

        //=================Crear Cards========================
        public void CreateCards(CardsAndando cards)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {

                try
                {
                    sql.Open();

                    using (SqlCommand cmd = new SqlCommand("dbo.sp_CreateCards", sql))
                    {
                        cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = cards.IdVista;
                        cmd.Parameters.Add("@CardCategoria", System.Data.SqlDbType.VarChar).Value = cards.CardCategoria;
                        cmd.Parameters.Add("@CardDetalles", System.Data.SqlDbType.VarChar).Value = cards.CardDetalles;
                        cmd.Parameters.Add("@CardPrecio", System.Data.SqlDbType.VarChar).Value = cards.CardPrecio;
                        cmd.Parameters.Add("@CardDuracion", System.Data.SqlDbType.VarChar).Value = cards.CardDuracion;
                        cmd.Parameters.Add("@CardUrl", System.Data.SqlDbType.VarChar).Value = cards.CardUrl;
                        cmd.Parameters.Add("@CardDepartures", System.Data.SqlDbType.VarChar).Value = cards.CardDepartures;
                        cmd.Parameters.Add("@CardImgNombre", System.Data.SqlDbType.VarChar).Value = cards.CardImgNombre;
                        cmd.Parameters.Add("@CardImgUrl", System.Data.SqlDbType.VarChar).Value = cards.CardImgUrl;
                        cmd.Parameters.Add("@CardImgTamano", System.Data.SqlDbType.VarChar).Value = cards.CardImgTamano;
                        cmd.Parameters.Add("@IdVista", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.ExecuteReader();

                        string id = cmd.Parameters["@IdVista"].Value.ToString();

                        sql.Close();
                    }
                }
                catch
                {

                }

               
            }
        }


        //=================Actualizar Cards========================
        public void UpdateCards(CardsAndando cards)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                sql.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.sp_UpdateCards", sql))
                {
                    cmd.Parameters.AddWithValue("@IdVista", cards.IdVista);
                    cmd.Parameters.AddWithValue("@CardCategoria", cards.CardCategoria);
                    cmd.Parameters.AddWithValue("@CardDetalles", cards.CardDetalles);
                    cmd.Parameters.AddWithValue("@CardPrecio", cards.CardPrecio) ;
                    cmd.Parameters.AddWithValue("@CardDuracion", cards.CardDuracion) ;
                    cmd.Parameters.AddWithValue("@CardUrl", cards.CardUrl);
                    cmd.Parameters.AddWithValue("@CardDepartures", cards.CardDepartures) ;
                    cmd.Parameters.AddWithValue("@CardImgNombre", cards.CardImgNombre);
                    cmd.Parameters.AddWithValue("@CardImgUrl", cards.CardImgUrl) ;
                    cmd.Parameters.AddWithValue("@CardImgTamano", cards.CardImgTamano) ;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                  

                    cmd.ExecuteReader();
                    sql.Close();
                }
            }
        }

      

        //=================Cargar MetaDatos Paginas Web========================
        public async Task<List<MetadataCMS>> GetMetadata(int idVista)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetMetaData", sql))
                {
                    cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = idVista;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var contenidoPagina = new List<MetadataCMS>();
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
        public MetadataCMS MapGetMetadata(SqlDataReader reader)
        {
            return new MetadataCMS()
            {
                idVista = (int)reader["IdVista"],
                idMetadata = (int)reader["IdMetadata"],
                MetaTitulo = reader["MetaTitulo"].ToString(),
                MetaDescripcion = reader["MetaDescripcion"].ToString(),
                MetaURL = reader["MetaURL"].ToString(),
                MetaReview = reader["MetaReview"].ToString(),
            };
        }
        public async Task<List<VistaAndando>> GetVistaAndandoWeb(string categoria)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetPaginasCategorias", sql))
                {
                    cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.NChar).Value = categoria;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var vistaAndando = new List<VistaAndando>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            vistaAndando.Add(MapGetVistaAndando(reader));
                        }
                    }
                    return vistaAndando;
                }
            }
        }

        

        public VistaAndando MapGetVistaAndando(SqlDataReader reader)
        {
            return new VistaAndando()
            {
                IdVista = (int)reader["Id"],
                NombreVista = reader["NombreVista"].ToString(),
                UrlVista = reader["UrlVista"].ToString(),
                CategoriaVista= reader["CategoriaVista"].ToString(),
            };
        }

        public async Task<List<GetRegistroActividadUsuarios>> GetActividadUsuarios()
        {
            using (SqlConnection sql =new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetActividadUsuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var regUsuario = new List<GetRegistroActividadUsuarios>();
                    await sql.OpenAsync();
                    using (var reader=await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            regUsuario.Add(MapGetregistroActividades(reader));
                        }
                    }
                    return regUsuario;
                }
            }
        }

        public GetRegistroActividadUsuarios MapGetregistroActividades(SqlDataReader reader)
        {
            //us.UserName, us.FistName, us.LastName, regUs.UrlPagina,regUs.Pagina,regUs.Seccion,regUs.Titulo,regUs.update_Act
            return new GetRegistroActividadUsuarios()
            {
                UserName = reader["UserName"].ToString(),
                FistName = reader["FistName"].ToString(),
                LastName= reader["LastName"].ToString(),
                UrlPagina= reader["UrlPagina"].ToString(),
                Pagina = reader["Pagina"].ToString(),
                Seccion = reader["Seccion"].ToString(),
                Titulo =reader["Titulo"].ToString(),
                DateAct = (DateTime) reader ["update_Act"],
            };
        }

        public GetContenidoPagina MapGetContenidoPagina(SqlDataReader reader)
        {
            return new GetContenidoPagina()
            {
                idVista = (int)reader["IdVista"],
                nombreVista = reader["Pagina"].ToString(),
                IdTitulo = (int)reader["IdTitulo"],
                IdParrafo = (int)reader["IdParrafo"],
                Titulo = reader["Titulo"].ToString(),
                Parrafo = reader["Parrafo"].ToString(),
                OrdenParrafo = (int)reader["OrdenParrafo"],
            };
        }

        public void UpdateContenidoPAginaWeb(int idtitulo, int idparrafo, string parrafo)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);


            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_ActualizarParrafo", cnn);
                cmd.Parameters.AddWithValue("@IdTitulo", idtitulo);
                cmd.Parameters.AddWithValue("@IdParrafo", idparrafo);
                cmd.Parameters.AddWithValue("@parrafo", parrafo);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();

        }

            public async Task<List<Multimedia>> GetImagenWeb(int IdVista)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetContenidoMultimediaI", sql))
                {
                    cmd.Parameters.Add("@IdVista", System.Data.SqlDbType.Int).Value = IdVista;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var contenidoPagina = new List<Multimedia>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contenidoPagina.Add(MapGetContenidoImagenes(reader));
                        }
                    }
                    return contenidoPagina;
                }
            }
        }

        private Multimedia MapGetContenidoImagenes(SqlDataReader reader)
        {
            return new Multimedia()
            {
                IdVista = (int)reader["IdVista"],
                IdImagen = (int)reader["IdImagen"],
                Pagina = reader["Pagina"].ToString(),
                NombreImagen = reader["NombreImagen"].ToString(),
                UrlImagen = reader["UrlImagen"].ToString(),
                TamanoImagen = reader["TamanoImagen"].ToString(),
            };
        }

        public void UpdateImagenes(int IdImagen, string NombreImagen)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_UpdateImagenes", cnn);
                cmd.Parameters.AddWithValue("@IdImagen", IdImagen);
                cmd.Parameters.AddWithValue("@NombreImagen", NombreImagen);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();
        }

        public void UpdateImagenesMenu(int IdImagen, string NombreImagen)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_UpdateImagenesMenu", cnn);
                cmd.Parameters.AddWithValue("@IdImagen", IdImagen);
                cmd.Parameters.AddWithValue("@NombreImagen", NombreImagen);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();
        }

        //=================Cargar MetaDatos Paginas Web========================
        //public async Task<List<Usuario>> GetUsuario(string usuario, string password)
        //{
        //    using (SqlConnection sql = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("dbo.sp_GetUsuario", sql))
        //        {
        //            cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar).Value = usuario;
        //            cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = password;
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            var getUsuario = new List<Usuario>();
        //            await sql.OpenAsync();
        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    getUsuario.Add(MapGetUsuario(reader));
        //                }
        //            }
        //            return getUsuario;
        //        }
        //    }
        //}
        //public Usuario  MapGetUsuario(SqlDataReader reader)
        //{
        //    return new Usuario()
        //    {
        //        IdUsuario = (int)reader["IdUsuario"],
        //        Nombre = reader["Nombre"].ToString(),
        //        Apellido= reader["Apellido"].ToString(),
        //    };
        //}
        public void UpdateTituloPAginaWeb(int idTitulo, string titulo)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_UpdateTitulo", cnn);
                cmd.Parameters.AddWithValue("@idTitulo", idTitulo);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();
        }
        public void UpdateMetadataPaginaWeb(int idVista, string tituloMeta,string descripMeta,string urlCano)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_UpdateMetaData", cnn);
                cmd.Parameters.AddWithValue("@idVista", idVista);
                cmd.Parameters.AddWithValue("@MetaDescripcion", descripMeta);
                cmd.Parameters.AddWithValue("@MetaURL", urlCano);
                cmd.Parameters.AddWithValue("@MetaTitulo", tituloMeta);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

            }
            cnn.Close();
        }

       public void RegistroActividades(string IdUsuario, string UrlPagina, string Pagina,string Seccion,string Titulo,string ImagenNombre, bool Texto, bool Imagen)
       {
            
            SqlConnection cnn;
            cnn = new SqlConnection(_connectionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_RegistroActividades", cnn);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("@UrlPagina", UrlPagina);
                cmd.Parameters.AddWithValue("@Pagina", Pagina);
                cmd.Parameters.AddWithValue("@Seccion", Seccion);
                cmd.Parameters.AddWithValue("@Titulo", Titulo);
                cmd.Parameters.AddWithValue("@ImagenNombre", ImagenNombre);
                cmd.Parameters.AddWithValue("@Texto", Texto);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
            }
            cnn.Close();
       }
    }
}

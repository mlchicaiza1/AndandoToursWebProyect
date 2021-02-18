using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.EntityFrameworkCore;
using AndandoToursWeb.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AndandoToursWeb.DataCMS;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using AndandoToursWeb.Services;

namespace AndandoToursWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GCMAndandoWeb")));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();


            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<Services.IEmailSender, EmailSender>();
            services.AddSingleton<INodeServices>(p =>
            {
                return NodeServicesFactory.CreateNodeServices(new NodeServicesOptions(services.BuildServiceProvider())
                {
                    ProjectPath = @"\\<mypath>\vue-server-render\vue-ssr\"
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<AndandoRepositorio>();
            services.AddScoped<CmsAndandoRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "IndexCruceros",
                    template: "galapagos-cruises",
                    defaults: new { Controller = "Cruises", action = "CruisesHome" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DailyHome",
                    template: "galapagos-daily-tours",
                    defaults: new { Controller = "galapagos_daily_tours", action = "dailyHome" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "EcuadorHome",
                    template: "Ecuador-itineraries",
                    defaults: new { Controller = "ecuador_itineraries", action = "EcuadorHome" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "blogHome",
                    template: "blog",
                    defaults: new { Controller = "blog", action = "blogHome" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "thanxyp",
                    template: "thank-your-page",
                    defaults: new { Controller = "thank_your_page", action = "thanxyp" }
                    );
            });
            //===========VISITOR SITES===========
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "tortuga_bay_galapagos_islands",
                    template: "visitor-sites/tortuga-bay-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "tortuga_bay_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "arnaldo_tupiza_center_galapagos_islands",
                    template: "visitor-sites/arnaldo-tupiza-center-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "arnaldo_tupiza_center_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "asilo_de_la_paz",
                    template: "visitor-sites/asilo-de-la-paz/",
                    defaults: new { Controller = "visitor_sites", action = "asilo_de_la_paz", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "bachas_beach_galapagos_islands",
                    template: "visitor-sites/bachas-beach-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "bachas_beach_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "bainbridge_galapagos_islands",
                    template: "visitor-sites/bainbridge-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "bainbridge_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "baltra_airport_galapagos_islands",
                    template: "visitor-sites/baltra-airport-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "baltra_airport_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "baroness_lookout_galapagos_islands",
                    template: "visitor-sites/baroness-lookout-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "baroness_lookout_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "bartolome_galapagos_islands",
                    template: "visitor-sites/bartolome-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "bartolome_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "blackbeach_galapagos_islands",
                    template: "visitor-sites/black-beach-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "black_beach_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "black_turtle_cove",
                    template: "visitor-sites/black-turtle-cove/",
                    defaults: new { Controller = "visitor_sites", action = "black_turtle_cove", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "bucanero_cove_galapagos_islands",
                    template: "visitor-sites/bucanero-cove-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "bucanero_cove_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "cerro_brujo",
                    template: "visitor-sites/cerro-brujo/",
                    defaults: new { Controller = "visitor_sites", action = "cerro_brujo", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "cerro_dragon_galapagos_islands",
                    template: "visitor-sites/cerro-dragon-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "cerro_dragon_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "charles_darwin_station_galapagos_islands",
                    template: "visitor-sites/charles-darwin-station-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "charles_darwin_station_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "daphne_galapagos_islands",
                    template: "visitor-sites/daphne-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "daphne_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "devils_crown_galapagos_islands",
                    template: "visitor-sites/devils-crown-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "devils_crown_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "el_chato_galapagos_islands",
                    template: "visitor-sites/el-chato-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "el_chato_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "el_chato_galapagos_islands",
                    template: "visitor-sites/el-chato-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "el_chato_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "el_junco_lagoon",
                    template: "visitor-sites/el-junco-lagoon/",
                    defaults: new { Controller = "visitor_sites", action = "el_junco_lagoon", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "elizabeth_bay_galapagos_islands",
                    template: "visitor-sites/elizabeth-bay-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "elizabeth_bay_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "espumilla_beach_galapagos_islands",
                    template: "visitor-sites/espumilla-beach-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "espumilla_beach_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "gardner_bay_galapagos_islands",
                    template: "visitor-sites/gardner-bay-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "gardner_bay_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "genovesa_island_darwin_bay_galapagos",
                    template: "visitor-sites/genovesa-island-darwin-bay-galapagos/",
                    defaults: new { Controller = "visitor_sites", action = "genovesa_island_darwin_bay_galapagos", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "genovesa_island_el_barranco_galapagos_islands",
                    template: "visitor-sites/genovesa-island-el-barranco-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "genovesa_island_el_barranco_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "islet_champion_galapagos_islands",
                    template: "visitor-sites/islet-champion-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "islet_champion_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "islet_gardner_galapagos_islands",
                    template: "visitor-sites/islet-gardner-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "islet_gardner_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "islet_osborn_galapagos_islands",
                    template: "visitor-sites/islet-osborn-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "islet_osborn_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "jacinto_gordillo_galapagos_islands",
                    template: "visitor-sites/jacinto-gordillo-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "jacinto_gordillo_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "kicker_rock_leon_dormido_galapagos_islands",
                    template: "visitor-sites/kicker-rock-leon-dormido-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "kicker_rock_leon_dormido_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "las_grietas",
                    template: "visitor-sites/las-grietas/",
                    defaults: new { Controller = "visitor_sites", action = "las_grietas", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "lobos_island_galapagos_islands",
                    template: "visitor-sites/lobos-island-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "lobos_island_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "mangle_point_galapagos_islands",
                    template: "visitor-sites/mangle-point-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "mangle_point_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "mosquera_islet_galapagos_islands",
                    template: "visitor-sites/mosquera-islet-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "mosquera_islet_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "navigation_whale_dolphin_observation_galapagos_islands",
                    template: "visitor-sites/navigation-whale-dolphin-observation-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "navigation_whale_dolphin_observation_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "north_seymour_galapagos_islands",
                    template: "visitor-sites/north_seymour-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "north_seymour_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pinnacle_rock_galapagos_islands",
                    template: "visitor-sites/pinnacle-rock-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "pinnacle_rock_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "post_office_bay_galapagos_islands",
                    template: "visitor-sites/post-office-bay-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "post_office_bay_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "puerto_ayora_galapagos_islands",
                    template: "visitor-sites/puerto-ayora-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "puerto_ayora_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "puerto_baquerizo_moreno_galapagos_islands",
                    template: "visitor-sites/puerto-baquerizo-moreno_galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "puerto_baquerizo_moreno_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "puerto_chino",
                    template: "visitor-sites/puerto-chino/",
                    defaults: new { Controller = "visitor_sites", action = "puerto_chino", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "puerto_egas_galapagos_islands",
                    template: "visitor-sites/puerto-egas-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "puerto_egas_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "puerto_grande",
                    template: "visitor-sites/puerto-grande/",
                    defaults: new { Controller = "visitor_sites", action = "puerto_grande", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "punta_cormorant_galapagos_islands",
                    template: "visitor-sites/punta-cormorant-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "punta_cormorant_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "punta_espejo",
                    template: "visitor-sites/punta-espejo/",
                    defaults: new { Controller = "visitor_sites", action = "punta_espejo", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "punta_espinoza_galapagos_islands",
                    template: "visitor-sites/punta-espinoza-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "punta_espinoza_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "punta_moreno_galapagos_islands",
                    template: "visitor-sites/punta-moreno-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "punta_moreno_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "punta_pitt_galapagos_islands",
                    template: "visitor-sites/punta-pitt-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "punta_pitt_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "punta_suarez_galapagos_islands",
                    template: "visitor-sites/punta-suarez-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "punta_suarez_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "punta_vicente_roca_galapagos_islands",
                    template: "visitor-sites/punta-vicente-roca-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "punta_vicente_roca_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "rabida_galapagos_islands",
                    template: "visitor-sites/rabida-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "rabida_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "san_cristobal_intepretation_center_galapagos_islands",
                    template: "visitor-sites/san-cristobal-intepretation-center-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "san_cristobal_intepretation_center_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "santa_cruz_highlands_galapagos_islands",
                    template: "visitor-sites/santa-cruz-highlands-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "santa_cruz_highlands_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "santa_fe_galapagos_islands",
                    template: "visitor-sites/santa-fe-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "santa_fe_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "sierra_negra_galapagos_islands",
                    template: "visitor-sites/sierra-negra-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "sierra_negra_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "sombrero_chino_galapagos_islands",
                    template: "visitor-sites/sombrero-chino-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "sombrero_chino_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "south_plaza_station_galapagos_islands",
                    template: "visitor-sites/south-plaza-station-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "south_plaza_station_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "sullivan_bay_galapagos_islands",
                    template: "visitor-sites/sullivan-bay-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "sullivan_bay_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "tagus_cove_galapagos_islands",
                    template: "visitor-sites/tagus-cove-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "tagus_cove_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "tijeretas_hill_galapagos_islands",
                    template: "visitor-sites/tijeretas-hill-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "tijeretas_hill_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "tintoreras_islet_galapagos_islands",
                    template: "visitor-sites/tintoreras-islet-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "tintoreras_islet_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "twin_craters_galapagos_islands",
                    template: "visitor-sites/twin-craters-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "twin_craters_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "urbina_bay_galapagos_islands",
                    template: "visitor-sites/urbina-bay-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "urbina_bay_galapagos_islands", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "wall_of_tears_galapagos_islands",
                    template: "visitor-sites/wall-of-tears-galapagos-islands/",
                    defaults: new { Controller = "visitor_sites", action = "wall_of_tears_galapagos_islands", }
                    );
            });

            //===========Plan your trip===========
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "mainland_ecuador",
                    template: "plan-your-trip/mainland-ecuador",
                    defaults: new { Controller = "plan_your_trip", action = "mainland_ecuador", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "galapagos_travel_information",
                    template: "plan-your-trip/galapagos-travel-information",
                    defaults: new { Controller = "plan_your_trip", action = "galapagos_travel_information", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "galapagos_travel_recommendations",
                    template: "plan-your-trip/galapagos-travel-recommendations",
                    defaults: new { Controller = "plan_your_trip", action = "galapagos_travel_recommendations", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ecuador_travel_recomendations",
                    template: "plan-your-trip/ecuador-travel-recomendations",
                    defaults: new { Controller = "plan_your_trip", action = "ecuador_travel_recomendations", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ecuador_costs",
                    template: "plan-your-trip/mainland-ecuador/costs",
                    defaults: new { Controller = "plan_your_trip", action = "ecuador_costs", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "galapagos_costs",
                    template: "plan-your-trip/galapagos-travel-information/costs",
                    defaults: new { Controller = "plan_your_trip", action = "galapagos_costs", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "tipping_ecuador",
                    template: "plan-your-trip/mainland-ecuador/tipping",
                    defaults: new { Controller = "plan_your_trip", action = "tipping_ecuador", }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "tipping_galapagos",
                    template: "plan-your-trip/galapagos-travel-information/tipping",
                    defaults: new { Controller = "plan_your_trip", action = "tipping_galapagos", }
                    );
            });
            //===========BARCOS===========

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesProduct",
                    template: "/Cruises/CruisesProduct/{id?}/{idItinerario?}",
                    defaults: new { Controller = "Cruises", action = "CruisesProduct", }
                    );
            });
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesCategoriaCatamarans",
                    template: "galapagos-cruises/galapagos-catamarans",
                    defaults: new { Controller = "Cruises", action = "CruisesCategoria" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesCategoriaHighEnd",
                    template: "galapagos-cruises/high-end",
                    defaults: new { Controller = "Cruises", action = "CruisesCategoria" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesCategoriaMid-range-cruises",
                    template: "galapagos-cruises/mid-range-cruises",
                    defaults: new { Controller = "Cruises", action = "CruisesCategoria" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesCategoriaSailing-cruises",
                    template: "sailing-cruises",
                    defaults: new { Controller = "Cruises", action = "CruisesCategoria" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesCategoriaBudget",
                    template: "cruises/budget",
                    defaults: new { Controller = "Cruises", action = "CruisesCategoria" }
                    );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesCategoriaGalapagos-yachts",
                    template: "galapagos-cruises/galapagos-yachts",
                    defaults: new { Controller = "Cruises", action = "CruisesCategoria" }
                    );
            });

            //====================yacht-charters=================
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CruisesYacht-charters",
                    template: "/cruises/yacht-charters",
                    defaults: new { Controller = "Cruises", action = "CruisesCharter" }
                    );
            });
        }
    }
}

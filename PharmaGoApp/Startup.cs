using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PharmaGo.BLL;
using PharmaGo.BOL;
using PharmaGo.DAL;

namespace PharmaGoApp
{
    public class Startup
    {

        //Configure all the 3rd app services here

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

            #region DALDI

            services.AddTransient<IMedicinesDb, MedicinesDb>();
            services.AddTransient<IStockMedicinesDb, StockMedicinesDb>();
            services.AddTransient<IPharmacyDb, PharmacyDb>();
            services.AddTransient<IGPAUsersDb, GPAUsersDb>();
            services.AddTransient<IAppReviewDb, AppReviewDb>();
            services.AddTransient<ICustomerPrescriptionDb, CustomerPrescriptionDb>();
            services.AddTransient<IMedDemandDb, MedDemandDb>();
            services.AddTransient<ITimeSlotsDb, TimeSlotsDb>();
            services.AddTransient<IAppointmentsDb, AppointmentsDb>();
            services.AddTransient<ICustomerMedReserveDb, CustomerMedReserveDb>();
            #endregion

            #region BLLDI

            services.AddTransient<IMedicinesBS, MedicinesBS>();
            services.AddTransient<IStoreMedicineBS, StoreMedicineBS>();
            services.AddTransient<IPharmaciesBS, PharmaciesBS>();
            services.AddTransient<IGPAUsersBS, GPAUsersBS>();
            services.AddTransient<IAppReviewBS, AppReviewBS>();
            services.AddTransient<ICustomerPrescriptionBS, CustomerPrescriptionBS>();
            services.AddTransient<ITimeSlotsBS, TimeSlotsBS>();
            services.AddTransient<IAppointmentBS, AppointmentsBS>();
            services.AddTransient<ICustomerMedReserveBS, CustomerMedReserveBS>();
            #endregion

            services.AddDbContext<PGADbContext>(options =>
                                        options.UseSqlServer(Configuration.GetConnectionString("GPAConStr")));

            services.AddIdentity<GPAUser, IdentityRole>()
                .AddEntityFrameworkStores<PGADbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

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
        }
    }
}

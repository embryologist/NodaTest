using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace nodaserializeation {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddMvcCore ()
                .AddJsonFormatters (jsonSerializerSettings => {
                    jsonSerializerSettings.DateParseHandling = DateParseHandling.None;
                    jsonSerializerSettings.ConfigureForNodaTime (DateTimeZoneProviders.Tzdb);
                    jsonSerializerSettings.Culture = Thread.CurrentThread.CurrentCulture;

                })
                .AddApiExplorer ()
                .AddJsonOptions (options => {
                    options.AllowInputFormatterExceptionMessages = false;
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_1)
                .AddViewLocalization (LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.Extensions.DependencyInjection;
using FieldAgent.DAL.EF;
using FieldAgent.Core.Interfaces;
using FieldAgent.DAL;

namespace FieldAgent.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options => {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = "http://localhost:2000",
            //            ValidAudience = "http://localhost:2000",
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"))
            //        };
            //        services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            //    });

            services.AddControllers();
            ConfigProvider cp = new ConfigProvider();
            DBFactory dbFactory = new DBFactory(cp.Config);

            services.AddTransient<IAgentRepository, AgentRepository>(s => new AgentRepository(dbFactory));
            services.AddTransient<IAliasRepository, AliasRepository>(s => new AliasRepository(dbFactory));
            services.AddTransient<IMissionRepository, MissionRepository>(s => new MissionRepository(dbFactory));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

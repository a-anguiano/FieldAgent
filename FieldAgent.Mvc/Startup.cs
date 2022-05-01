using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.DAL.ADO;
using FieldAgent.DAL.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;    //Determine which version
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FieldAgent.Mvc
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
            services.AddTransient<IAgentRepository, AgentRepository>();
            services.AddTransient<IAliasRepository, AliasRepository>();
            services.AddTransient<IMissionRepository, MissionRepository>();
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

using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.DAL.EF;
using FieldAgent.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.Web
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //confirm location

        public void ConfigureServices(IServiceCollection services)  
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.WithOrigins("*", "http://localhost:3000");
                        policy.AllowAnyMethod();
                    });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "http://localhost:2000",
                        ValidAudience = "http://localhost:2000",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"))
                    };
                    services.AddMvc();
                });

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

            //what order? Authen,author,route?

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Deb_test.Data;
using Deb_test.Services.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.Employee;
using Services.WorkShift;

namespace Deb_test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DebDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DBConnection")));
            services.AddScoped<DbContext, DebDbContext>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IWorkShiftService, WorkShiftService>();
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Deb_Test", Version = "1.0"});
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "Deb_test.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger().
                UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Deb_Test");
                      c.RoutePrefix = string.Empty;

                });
           
        }
    }
}

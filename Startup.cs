using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using KonusarakOgren.Data;
using Microsoft.EntityFrameworkCore;
using KonusarakOgren.Interfaces.Services;
using KonusarakOgren.Service.Services;
using KonusarakOgren.Interfaces.UnitOfWork;
using KonusarakOgren.Data.UnitOfWork;
using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Data.Repositories;
using FluentValidation.AspNetCore;
using KonusarakOgren.Service.Maping;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace KonusarakOgren
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
            services.AddControllersWithViews().AddFluentValidation(opt=>opt.RegisterValidatorsFromAssemblyContaining<Startup>());
            var connection = Configuration.GetConnectionString("ContextKonusarakOgren");
            services.AddDbContext<ContextKonusarakOgren>(options => options.UseSqlServer(connection));


            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(5);
            });



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(x =>
              {
                  x.LoginPath = "/Error/Index";
              });


            services.AddMvc(conf =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                conf.Filters.Add(new AuthorizeFilter(policy));
            });



            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IUnitOfWork, UnitOFwork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddScoped<IVisitorService, VisitorService>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

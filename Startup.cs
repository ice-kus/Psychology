using Psychology.Data; // пространство имен контекста данных UserContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Psychology.Data.Interfaces;
using Psychology.Data.Repositories;
using Microsoft.AspNetCore.Http;

namespace Psychology
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
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<ICriteriaRepository, CriteriaRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<ILecturerRepository, LecturerRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();
            services.AddTransient<IPassageDataRepository, PassageDataRepository>();
            services.AddTransient<IPassageDataQuestionRepository, PassageDataQuestionRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestQuestionRepository, TestQuestionRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AnswerRepository>();
            services.AddScoped<CriteriaRepository>();
            services.AddScoped<LecturerRepository>();
            services.AddScoped<ResultRepository>();
            services.AddScoped<QuestionRepository>();
            services.AddScoped<PassageDataRepository>();
            services.AddScoped<PassageDataQuestionRepository>();
            services.AddScoped<TestRepository>();
            services.AddScoped<TestQuestionRepository>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseNpgsql(
                    connection));

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Authorization/Index");
                });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authorization}/{action=Index}/{id?}");
            });
        }
    }
}
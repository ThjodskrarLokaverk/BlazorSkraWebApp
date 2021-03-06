using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorSkraApp1.Areas.Identity;
using BlazorSkraApp1.Data;
using BlazorSkraApp1.Services;

namespace BlazorSkraApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.AllowedUserNameCharacters = String.Empty;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequiredLength = 6;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
            });
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddMvc();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IFormsCategoryAssignmentsService, FormsCategoryAssignmentsService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IFormsInfoService, FormsInfoService>();
            services.AddTransient<ISubmissionsInfoService, SubmissionsInfoService>();
            services.AddTransient<ISubmissionsService, SubmissionsService>();
            services.AddTransient<IQuestionsFormAssignmentService, QuestionsFormAssignmentService>();
            services.AddTransient<IOptionsQuestionAssignmnentsService, OptionsQuestionAssignmnentsService>();
            services.AddTransient<IQuestionsService, QuestionsService>();
            services.AddTransient<IOptionsService, OptionsService>();
            services.AddTransient<IQuestionTypesService, QuestionTypesService>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IFormsService, FormsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            //Create an admin user and a normal user
            SystemInitialization(serviceProvider).Wait();
        }

        //Create dummy admin and dummy user
        private async Task SystemInitialization(IServiceProvider serviceProvider)
        {
            //initializing custom roles   
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //Create Admin Role
            var roleExist = await RoleManager.RoleExistsAsync("Admin");
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 1  
                await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Create Admin User
            IdentityUser user = await UserManager.FindByEmailAsync("admin@admin.is");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "admin@admin.is",
                    Email = "admin@admin.is",
                };
                await UserManager.CreateAsync(user, "Qwerty&123");
                await UserManager.AddToRoleAsync(user, "Admin");
            }

            //Create normal user
            IdentityUser user1 = await UserManager.FindByEmailAsync("user@user.is");

            if (user1 == null)
            {
                user1 = new IdentityUser()
                {
                    UserName = "user@user.is",
                    Email = "user@user.is",
                };
                await UserManager.CreateAsync(user1, "Qwerty&123");
            }

            //Create QuestionTypes



        }
    }
}
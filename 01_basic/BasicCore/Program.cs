using BasicCore.Data;
using BasicCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BasicCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            builder.Services.AddIdentity<CustomUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // 패스워드 정책 변경
            //builder.Services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequiredUniqueChars = 3;
            //    options.Password.RequireUppercase = false;
            //});

            builder.Services.AddAuthentication()
                .AddGoogle(opts =>
                {
                    opts.ClientId = "732865836057-518obuh57h53b0s9mcg4r49ca2r7jc5r.apps.googleusercontent.com";
                    opts.ClientSecret = "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";
                    opts.SignInScheme = IdentityConstants.ExternalScheme;
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("EditRolePolicy",
                    policy => policy.RequireClaim("Edit Role"));

                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();  // Shared/Login.cshtml과 충돌발생
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
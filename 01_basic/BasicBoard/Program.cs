using BasicBoard.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicBoard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            //builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "HugoBoardSession";   // 세션이름
                options.IdleTimeout = TimeSpan.FromMinutes(20); // 세션 지속시간
            }).AddControllersWithViews();

            //builder.Services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = "851215818915-bkm8c2j7p1g3a6a4amif01heneo4p82n.apps.googleusercontent.com";
            //        options.ClientSecret = "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";
            //    });

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
            app.UseSession(); // 파이프라인에셔 세션 사용

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
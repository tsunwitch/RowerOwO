using RowerOwO.Database;
using RowerOwO.Models;

namespace RowerOwO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Database
            builder.Services.AddDbContext<BikeContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var serviceScope = app.Services.CreateScope())
            {
               var context = serviceScope.ServiceProvider.GetService<BikeContext>();

               var items = new List<VehicleItemModel>
                {
                    new VehicleItemModel(){
                        //Id=0,
                        Name="Fwaggot 12",
                        IsAvailable=true,
                        ImgPath="\\img\\bike1.png",
                        //Detail=detailsList[0]
                    },
                    new VehicleItemModel(){
                        //Id=1,
                        Name="Szybcior Mega Ultra",
                        IsAvailable=false,
                        ImgPath="\\img\\bike2.png",
                        //Detail=detailsList[1]
                    },
                    new VehicleItemModel(){
                        //Id=2,
                        Name="Scooter Board Ultra",
                        IsAvailable=false,
                        ImgPath="\\img\\bike3.png",
                        //Detail=detailsList[2]
                    }
                };

                    context.Vehicles.AddRange(items);
                    context.SaveChanges();
            }

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
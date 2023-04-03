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
            builder.Services.AddDbContext<DatabaseContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var serviceScope = app.Services.CreateScope())
            {
               var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

               var items = new List<VehicleModel>
                {
                    new VehicleModel(){
                        Id= Guid.NewGuid(),
                        Name="Fwaggot 12",
                        IsAvailable=true,
                        ImgPath="\\img\\bike1.png",
                        Color="Silver",
                        Description="Uniwersalny rower miejski bez niepotrzebnych gadżetów. Idealny dla każdego(oprócz dzieci bo troche duzy)",
                        Powered=false,
                        RentPrice=25,
                    },
                    new VehicleModel(){
                        Id= Guid.NewGuid(),
                        Name="Szybcior Mega Ultra",
                        IsAvailable=false,
                        ImgPath="\\img\\bike2.png",
                        Color="Off-White",
                        Description="Mały składany rower. Dzięki rozmiarowi możesz zabrać go łatwo ze sobą do środków transportu publicznego. Posiada napęd elektryczny",
                        Powered=true,
                        RentPrice=40.50
                    },
                    new VehicleModel(){
                        Id= Guid.NewGuid(),
                        Name="Scooter Board Ultra",
                        IsAvailable=false,
                        ImgPath="\\img\\bike3.png",
                        Color="Pink",
                        Description="Stylowy rower z wykrzywioną ramą kierowany do kobiet. Wyróżnij się na tle miasta!",
                        Powered=false,
                        RentPrice=27.30
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
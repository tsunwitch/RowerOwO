﻿using RowerOwO.Database;
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

               if(context != null)
                {
                    var vehicles = new List<VehicleModel>
                    {
                        new VehicleModel(){
                            //Id= Guid.NewGuid(),
                            Name="Fwaggot 12",
                            IsAvailable=true,
                            ImgPath="https://d2yn9m4p3q9iyv.cloudfront.net/schwinn/2022/traveler/thumbs/1000/22a27.webp",
                            Color="Silver",
                            Description="Uniwersalny rower miejski bez niepotrzebnych gadżetów. Idealny dla każdego(oprócz dzieci bo troche duzy)",
                            Powered=false,
                            RentPrice=25,
                        },
                        new VehicleModel(){
                            //Id= Guid.NewGuid(),
                            Name="Szybcior Mega Ultra",
                            IsAvailable=false,
                            ImgPath="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTU23ajdqnEIcik02UnJRY99iReEwEYRmiTcpWF-bST6Or2VAZm",
                            Color="Off-White",
                            Description="Mały składany rower. Dzięki rozmiarowi możesz zabrać go łatwo ze sobą do środków transportu publicznego. Posiada napęd elektryczny",
                            Powered=true,
                            RentPrice=40.50
                        },
                        new VehicleModel(){
                            //Id= Guid.NewGuid(),
                            Name="Scooter Board Ultra",
                            IsAvailable=false,
                            ImgPath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqSxy2tgfPmJK2ANeSsaQR5gKvuCT6zAPE3G9ZfXKuJUtxqPwF",
                            Color="Pink",
                            Description="Stylowy rower z wykrzywioną ramą kierowany do kobiet. Wyróżnij się na tle miasta!",
                            Powered=false,
                            RentPrice=27.30
                        }
                    };

                    var rentalPoints = new List<RentalPointModel>()
                    {
                        new RentalPointModel(){
                            Name="RowerOwO Bielsko-Biała",
                            City="Bielsko-Biała",
                            Street="Szczotkowa",
                            Number="5"
                        },
                        new RentalPointModel(){
                            Name="RowerOwO Polibuda",
                            City="Gliwice",
                            Street="Akademicka",
                            Number="2A"
                        },
                        new RentalPointModel(){
                            Name="RowerOwO AGH",
                            City="Kraków",
                            Street="Poległych studentów",
                            Number="rip"
                        },
                        new RentalPointModel(){
                            Name="RowerOwO z widokiem na morze",
                            City="Łeba",
                            Street="Śledzia wędzonego",
                            Number="58"
                        }
                    };

                    context.Vehicles.AddRange(vehicles);
                    context.RentalPoints.AddRange(rentalPoints);
                    context.SaveChanges();
                }
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
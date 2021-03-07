using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinavProje.Models;

namespace SinavProje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var db = new SQLiteDBContext())
            //{
            //    //Create
            //    Console.WriteLine("Add new User");
            //    db.Users.Add(new User
            //        {Username = "sinanakinci", Email = "sinanakincioglu@gmail.com", Name = "Sinan Akincioglu"});
            //    db.SaveChanges();
            //    Console.WriteLine("user has been added successfully");

            //    //read
            //    var user = db.Users.OrderBy(h => h.Id).First();
            //    Console.WriteLine("The user found : His name is {0}, his e-mail {1}", user.Name, user.Email);

            //    //update
            //    user.Name = "Sinan Süvari";
            //    db.SaveChanges();
            //    Console.WriteLine(user.Name);

            //    //delete
            //    db.Remove(user);
            //    db.SaveChanges();

            //}
           

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

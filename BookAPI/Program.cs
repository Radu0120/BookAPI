using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;

namespace BookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //for testing
            Controllers.BookController.BooksCatalog.Add("123", new Book("book1", "auth1", 15, "123"));
            Controllers.BookController.BooksCatalog.Add("124", new Book("book2", "auth2", 15, "124"));
            Controllers.BookController.BooksCatalog.Add("125", new Book("book3", "auth3", 15, "125"));
            Controllers.BookController.BooksCatalog.Add("126", new Book("book4", "auth4", 15, "126"));
            Controllers.BookController.BooksCatalog.Add("127", new Book("book5", "auth5", 15, "127"));
            //+++++++++++
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

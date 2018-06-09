using System.Data.SqlClient;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

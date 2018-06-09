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

            //var connectionString = "server=35.234.102.251;user id=root;database=cmd_database;password=123456";
            //var connection = new MySqlConnection(connectionString);
            //connection.Open();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

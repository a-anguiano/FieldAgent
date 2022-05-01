using FieldAgent.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FieldAgent.DAL
{
    public enum FactoryMode
    {
        TEST,
        PROD
    }
    public class DBFactory : IMyService
    {
        private readonly IConfigurationRoot Config;
        private readonly FactoryMode Mode;
        private static string _connectionString;

        public DBFactory(IConfigurationRoot config, FactoryMode mode = FactoryMode.PROD)
        {
            Config = config;
            Mode = mode;
        }

        public string GetConnectionString()
        {
            string environment = Mode == FactoryMode.TEST ? "Test" : "Prod";
            _connectionString = Config[$"ConnectionStrings:{environment}"];
            return _connectionString;
        }
        public AppDbContext GetDbContext()
        {
            string environment = Mode == FactoryMode.TEST ? "Test" : "Prod";

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(Config[$"ConnectionStrings:{environment}"])
                .Options;
            return new AppDbContext(options);
        }
    }

    //public class MyService : IMyService
    //{
    //    public MyService(string connString)
    //    {
    //        var cn = DBFactory.GetConnectionString();
    //    }

    //    public string GetConstructorParameter()
    //    {
    //        return connectionString;
    //    }
    //}
}

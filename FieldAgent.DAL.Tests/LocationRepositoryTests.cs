using FieldAgent.Core.Entities;
using FieldAgent.DAL.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.Tests
{
    public class LocationRepositoryTests
    {
        LocationRepository db;
        DBFactory dbf;

        Location LocationThree = new Location
        {
            LocationId = 3,
            AgencyId = 3,
            LocationName = "Phantom",
            Street1 = "Fairview",
            Street2 = "Monterey",
            City = "Luz de Tavira",
            PostalCode = "8800-114",
            CountryCode = "PT"
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new LocationRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestDelete()
        {

        }

        [Test]
        public void TestGet()
        {

        }

        [Test]
        public void TestGetByAgency()
        {

        }

        [Test]
        public void TestInsert()
        {

        }

        [Test]
        public void TestUpdate()
        {

        }
    }
}

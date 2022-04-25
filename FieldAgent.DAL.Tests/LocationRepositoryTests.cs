using FieldAgent.Core.Entities;
using FieldAgent.DAL.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

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
            bool actual = db.Delete(1).Success;
            Assert.IsTrue(actual);
            Assert.Null(db.Get(1).Data);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(LocationThree.ToString(), db.Get(3).Data.ToString());
        }

        [Test]
        public void TestGetByAgency()
        {
            List<Location> locationList = new List<Location>();
            locationList.Add(LocationThree);
            Assert.AreEqual(locationList.ToString(), db.GetByAgency(3).Data.ToString());
        }

        [Test]
        public void TestInsert()
        {
            Location expected = new Location
            {
                AgencyId = 4,
                LocationName = "Kingdom",
                Street1 = "Fairy Lane",
                Street2 = "Ogre Court",
                City = "La La",
                PostalCode = "867",
                CountryCode = "NL"
            };

            db.Insert(expected);
            expected.LocationId = 16;

            Assert.AreEqual(expected.ToString(), db.Get(16).Data.ToString());
        }

        [Test]
        public void TestUpdate()
        {
            LocationThree.AgencyId = 6;
            LocationThree.LocationName = "Ghost";
            LocationThree.Street1 = "Spooky Ave";
            LocationThree.Street2 = "Haunted Drive";
            LocationThree.City = "LA";
            LocationThree.PostalCode = "8800-114";
            LocationThree.CountryCode = "NZ";

            db.Update(LocationThree);
            Location actual = db.Get(3).Data;

            Assert.AreEqual(LocationThree.ToString(), actual.ToString());
        }
    }
}

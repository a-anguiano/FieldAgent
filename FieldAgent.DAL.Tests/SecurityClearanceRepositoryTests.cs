using FieldAgent.Core.Entities;
using FieldAgent.DAL.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace FieldAgent.DAL.Tests
{
    public class SecurityClearanceRepositoryTests
    {
        SecurityClearanceRepository db;
        DBFactory dbf;

        SecurityClearance SC1 = new SecurityClearance
        {
            SecurityClearanceId = 1,
            SecurityClearanceName = "None"
        };

        SecurityClearance SC2 = new SecurityClearance
        {
            SecurityClearanceId = 2,
            SecurityClearanceName = "Retired"
        };

        SecurityClearance SC3 = new SecurityClearance
        {
            SecurityClearanceId = 3,
            SecurityClearanceName = "Secret"
        };

        SecurityClearance SC4 = new SecurityClearance
        {
            SecurityClearanceId = 4,
            SecurityClearanceName = "TopSecret"
        };

        SecurityClearance SC5 = new SecurityClearance
        {
            SecurityClearanceId = 5,
            SecurityClearanceName = "Black Ops"
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new SecurityClearanceRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(SC1.ToString(), db.Get(1).Data.ToString());
            Assert.AreEqual(SC2.ToString(), db.Get(2).Data.ToString());
            Assert.AreEqual(SC3.ToString(), db.Get(3).Data.ToString());
            Assert.AreEqual(SC4.ToString(), db.Get(4).Data.ToString());
            Assert.AreEqual(SC5.ToString(), db.Get(5).Data.ToString());
        }

        [Test]
        public void TestGetAll()
        {
            List<SecurityClearance> list = new List<SecurityClearance>();
            list.Add(SC1);
            list.Add(SC2);
            list.Add(SC3);
            list.Add(SC4);
            list.Add(SC5);

            Assert.AreEqual(list.ToString(), db.GetAll().Data.ToString());
        }
    }
}

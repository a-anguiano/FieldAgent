using FieldAgent.Core.Entities;
using FieldAgent.DAL.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FieldAgent.DAL.Tests
{
    public class AgencyRepositoryTests
    {
        AgencyRepository db;
        DBFactory dbf;

        Agency WI = new Agency
        {
            AgencyId = 1,
            ShortName = "W",
            LongName = "White Inc"
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new AgencyRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(WI, db.Get(1).Data);
        }

        [Test]
        public void TestInsert()
        {
            Agency expected = new Agency
            {
                ShortName = "Sky",
                LongName = "SkyNet"
            };

            db.Insert(expected);
            expected.AgencyId = 16;

            Assert.AreEqual(expected, db.Get(16).Data);
        }

        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(15, db.GetAll().Data.Count);
        }

        [Test]
        public void TestDelete()
        {
            Assert.IsTrue(db.Delete(1).Success);
            Assert.Null(db.Get(1).Data);
        }

        [Test]
        public void TestUpdate()
        {
            WI.ShortName = "Shorty";
            WI.LongName = "Longy";

            db.Update(WI);
            Agency actual = db.Get(1).Data;

            Assert.AreEqual(WI.ToString(), actual.ToString());
        }
    }
}

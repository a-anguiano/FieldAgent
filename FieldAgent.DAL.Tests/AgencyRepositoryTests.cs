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

        //Response<Agency> Insert(Agency agency);
        //Response Update(Agency agency);
        //Response Delete(int agencyId);
        //Response<Agency> Get(int agencyId);
        //Response<List<Agency>> GetAll();
    }
}

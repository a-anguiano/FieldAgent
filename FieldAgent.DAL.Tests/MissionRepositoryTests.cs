using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldAgent.Core.Entities;
using FieldAgent.DAL.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FieldAgent.DAL.Tests
{
    public class MissionRepositoryTests
    {
        MissionRepository db;
        DBFactory dbf;

        Mission MissionSeven = new Mission
        {
            MissionId = 7,
            AgencyId = 7,
            CodeName = "Catfish",
            StartDate = DateTime.Parse("3/19/2001"),
            ProjectedEndDate = DateTime.Parse("4/18/2018"),
            ActualEndDate = DateTime.Parse("4/25/2018"),
            OperationalCost = decimal.Parse("83304317.53"),
            Notes = "Chief Design Engineer"
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new MissionRepository(dbf);
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
        public void TestGetByAgent()
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

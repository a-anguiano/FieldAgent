using System;
using System.Collections.Generic;
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
            bool actual = db.Delete(1).Success;
            Assert.IsTrue(actual);
            Assert.Null(db.Get(1).Data);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(MissionSeven.ToString(), db.Get(7).Data.ToString());
        }

        [Test]
        public void TestGetByAgency()
        {
            List<Mission> missionList = new List<Mission>();
            missionList.Add(MissionSeven);
            Assert.AreEqual(missionList.ToString(), db.GetByAgency(7).Data.ToString());
        }

        [Test]
        public void TestGetByAgent()
        {
            List<Mission> missionList = new List<Mission>();
            missionList.Add(MissionSeven);
            Assert.AreEqual(missionList.ToString(), db.GetByAgent(7).Data.ToString());
            Assert.AreEqual(missionList[0].MissionId.ToString(), db.GetByAgent(7).Data[0].MissionId.ToString());
        }

        [Test]
        public void TestInsert()
        {
            Mission expected = new Mission
            {
                AgencyId = 15,
                CodeName = "Cat And Mouse",
                StartDate = DateTime.Parse("3/1/2011"),
                ProjectedEndDate = DateTime.Parse("4/1/2019"),
                ActualEndDate = DateTime.Parse("4/5/2020"),
                OperationalCost = decimal.Parse("10000.50"),
                Notes = "Tom and Jerry"
            };

            db.Insert(expected);
            expected.MissionId = 16;

            Assert.AreEqual(expected.ToString(), db.Get(16).Data.ToString());
        }

        [Test]
        public void TestUpdate()
        {
            MissionSeven.MissionId = 7;
            MissionSeven.AgencyId = 8;
            MissionSeven.CodeName = "Burger";
            MissionSeven.StartDate = DateTime.Parse("1/1/2002");
            MissionSeven.ProjectedEndDate = DateTime.Parse("2/14/2017");
            MissionSeven.ActualEndDate = DateTime.Parse("2/15/2013");
            MissionSeven.OperationalCost = decimal.Parse("11111.22");
            MissionSeven.Notes = "Dont get caught";

            db.Update(MissionSeven);
            Mission actual = db.Get(7).Data;
            Assert.AreEqual(MissionSeven.MissionId, actual.MissionId);
            Assert.AreEqual(MissionSeven.AgencyId, actual.AgencyId);
            Assert.AreEqual(MissionSeven.CodeName, actual.CodeName);
            Assert.AreEqual(MissionSeven.StartDate, actual.StartDate);
            Assert.AreEqual(MissionSeven.ProjectedEndDate, actual.ProjectedEndDate);
            Assert.AreEqual(MissionSeven.ActualEndDate, actual.ActualEndDate);
            Assert.AreEqual(MissionSeven.OperationalCost, actual.OperationalCost);
            Assert.AreEqual(MissionSeven.Notes, actual.Notes);
        }
    }
}

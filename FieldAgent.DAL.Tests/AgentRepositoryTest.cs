using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using FieldAgent.Core.Entities;
using System;
using FieldAgent.DAL.EF;
using System.Collections.Generic;

namespace FieldAgent.DAL.Tests
{
    public class AgentRepositoryTest
    {
        AgentRepository db;
        DBFactory dbf;

        Agent James = new Agent
        {
            AgentId = 5,
            FirstName = "James",
            LastName = "Bond",
            DateOfBirth = DateTime.Parse("1/1/1980"),
            Height = decimal.Parse("183.13")
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new AgentRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(James, db.Get(5).Data);
        }

        [Test]
        public void TestInsert()
        {
            Agent expected = new Agent
            {
                FirstName = "Jason",
                LastName = "Borne",
                DateOfBirth = DateTime.Parse("1/1/1985"),
                Height = decimal.Parse("185.60")
            };

            db.Insert(expected);
            expected.AgentId = 16;

            Assert.AreEqual(expected, db.Get(16).Data);
        }
        
        [Test]
        public void TestGetMissions()
        {
            List<Mission> missionsExpected = new List<Mission>();
            Mission expected = new Mission
            {
                CodeName = "Ring-tailed lemur",
                Notes = "Engineer IV",
                StartDate = DateTime.Parse("06/11/1987"),
                ProjectedEndDate = DateTime.Parse("4/3/2008"),
                ActualEndDate = DateTime.Parse("11/30/2008"),
                OperationalCost = decimal.Parse("49301805.93")
            };
            missionsExpected.Add(expected);

            Assert.IsTrue(db.GetMissions(1).Success);
            Assert.AreEqual(missionsExpected, db.GetMissions(1).Data);
        }

        [Test]
        public void TestDelete()
        {
            bool actual = db.Delete(1).Success;
            Assert.IsTrue(actual);
            Assert.Null(db.Get(1).Data);
        }

        [Test]
        public void TestUpdate()
        {
            James.FirstName = "Jimmy";
            James.LastName = "Johns";
            James.DateOfBirth = DateTime.Parse("1/20/1976");
            
            db.Update(James);
            Agent actual = db.Get(5).Data;
            Assert.AreEqual(James.FirstName, actual.FirstName);
            Assert.AreEqual(James.LastName, actual.LastName);
            Assert.AreEqual(James.DateOfBirth, actual.DateOfBirth);
            Assert.AreEqual(James.Height, actual.Height);
        }
    }
}

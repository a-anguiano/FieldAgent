using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using FieldAgent.Core.Entities;
using System;
using System.Collections.Generic;
using FieldAgent.DAL.EF;

namespace FieldAgent.DAL.Tests
{
    public class AgencyAgentRepositoryTests
    {
        AgencyAgentRepository db;
        DBFactory dbf;
        static DateTime date = new DateTime(2/13/2001);

        AgencyAgent AA = new AgencyAgent
        {
            AgencyId = 1,
            AgentId = 1,
            BadgeId = Guid.Parse("c4c0537d-6b12-4d0d-92dd-d71bb6e03f04"),
            ActivationDate = date,
            DeactivationDate = date.AddYears(10),
            IsActive = true
            ,SecurityClearanceId = 1
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new AgencyAgentRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestInsert()
        {
            AgencyAgent expected = new AgencyAgent
            {
                AgencyId = 3,
                AgentId = 2,
                BadgeId = Guid.Parse("db04727a-f808-4552-a452-9124d33b320a"),
                ActivationDate = DateTime.Parse("1-10-2022"), 
                DeactivationDate = DateTime.Parse("1-11-2023"),
                IsActive = true ,
                SecurityClearanceId = 1
            };

            db.Insert(expected);
            expected.AgencyId = 3;
            expected.AgentId = 2;

            Assert.AreEqual(expected, db.Get(3,2).Data);
        }

        [Test]
        public void TestUpdate()
        {
            AA.ActivationDate = DateTime.Parse("1/1/1920");
            AA.DeactivationDate = DateTime.Parse("1/1/1922");
            AA.IsActive = true;
            //AA.SecurityClearanceId = 0;
            db.Update(AA);
            AgencyAgent actual = db.Get(1,1).Data;
            Assert.AreEqual(AA.AgencyId, actual.AgencyId);
            Assert.AreEqual(AA.AgentId, actual.AgentId);
            Assert.AreEqual(AA.ActivationDate, actual.ActivationDate);
            Assert.AreEqual(AA.DeactivationDate, actual.DeactivationDate);
            Assert.AreEqual(AA.IsActive, actual.IsActive);
        }

        [Test]
        public void TestDelete()
        {
            bool actual = db.Delete(1, 1).Success;
            Assert.IsTrue(actual);
            Assert.Null(db.Get(1,1).Data);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(AA.ToString(), db.Get(1,1).Data.ToString());  //visually equivalent
            Assert.AreEqual(AA.AgentId, db.Get(1,1).Data.AgentId);
        }
        
        [Test]
        public void TestGetByAgency()
        {
            List<AgencyAgent> aa = new List<AgencyAgent>();
            aa.Add(AA);
            Assert.AreEqual(aa.ToString(), db.GetByAgency(1).Data.ToString());
        }

        [Test]
        public void TestGetByAgent()
        {
            List<AgencyAgent> aa = new List<AgencyAgent>();
            aa.Add(AA);
            Assert.AreEqual(aa.ToString(), db.GetByAgent(1).Data.ToString());
        }
    }
}
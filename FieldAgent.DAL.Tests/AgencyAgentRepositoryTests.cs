using Microsoft.EntityFrameworkCore;
using FieldAgent.DAL;
using NUnit.Framework;
using FieldAgent.Core.Entities;
using System;

namespace FieldAgent.DAL.Tests
{
    public class AgencyAgentRepositoryTests
    {
        AgencyAgentRepository db;
        DBFactory dbf;
        static DateTime date = new DateTime(1/1/2020);

        AgencyAgent AAupdate = new AgencyAgent
        {
            AgencyId = 1,
            AgentId = 1,
            ActivationDate = date,
            DeactivationDate = date.AddYears(2),
            IsActive = false,
            SecurityClearanceId = 2
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
            Assert.Pass();
            AgencyAgent expected = new AgencyAgent
            {
                //BadgeId = "db04727a-f808-4552-a452-9124d33b320a",
                ActivationDate = DateTime.Parse("1-10-2022"),   //in future may have to change these
                DeactivationDate = DateTime.Parse("1-11-2023"),
                IsActive = true,
                SecurityClearanceId = 0

            };

            db.Insert(expected);
            expected.AgencyId = 16;
            expected.AgentId = 16;

            Assert.AreEqual(expected, db.Get(16,16).Data);
        }

        [Test]
        public void TestUpdate()
        {
            AAupdate.ActivationDate = DateTime.Parse("1/1/1920");
            AAupdate.DeactivationDate = DateTime.Parse("1/1/1922");
            AAupdate.IsActive = true;
            //AAupdate.SecurityClearanceId = 0;
            db.Update(AAupdate);
            AgencyAgent actual = db.Get(1,1).Data;
            Assert.AreEqual(AAupdate.AgencyId, actual.AgencyId);
            Assert.AreEqual(AAupdate.AgentId, actual.AgentId);
            Assert.AreEqual(AAupdate.ActivationDate, actual.ActivationDate);
            Assert.AreEqual(AAupdate.DeactivationDate, actual.DeactivationDate);
            Assert.AreEqual(AAupdate.IsActive, actual.IsActive);
        }

        [Test]
        public void TestDelete()
        {
            //Response Delete(int agencyid, int agentid);
        }

        [Test]
        public void TestGet()
        {
            
            //Response<AgencyAgent> Get(int agencyid, int agentid);
        }
        
        [Test]
        public void TestGetByAgency()
        {
            //Response<List<AgencyAgent>> GetByAgency(int agencyId);
        }

        [Test]
        public void TestGetByAgent()
        {
            //Response<List<AgencyAgent>> GetByAgent(int agentId);
        }
    }
}
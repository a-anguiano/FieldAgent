using Microsoft.EntityFrameworkCore;
using FieldAgent.DAL;
using NUnit.Framework;
using FieldAgent.Core.Entities;
using System;
using FieldAgent.DAL.EF;
using FieldAgent.Core.DTOs;

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


    }
}

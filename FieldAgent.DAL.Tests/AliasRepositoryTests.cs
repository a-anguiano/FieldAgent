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
    public class AliasRepositoryTests
    {
        AliasRepository db;
        DBFactory dbf;

        Alias AliasEight = new Alias
        {
            AgentId = 8,
            AliasId = 8,
            AliasName = "Adansonia",
            InterpolId = Guid.Parse("5beb4617-0f0b-4355-842b-cabad1b771af"),
            Persona = "Future-proofed responsive matrix"
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new AliasRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(AliasEight.ToString(), db.Get(8).Data.ToString());
        }

        [Test]
        public void TestGetByAgent()
        {
            List<Alias> aliasList = new List<Alias>();
            aliasList.Add(AliasEight);
            Assert.AreEqual(aliasList.ToString(), db.GetByAgent(8).Data.ToString());
        }

        [Test]
        public void TestInsert()
        {
            Alias expected = new Alias
            {
                AgentId = 8,
                AliasName = "Black Widow",
                InterpolId = Guid.Parse("5beb4617-0f0b-4355-842b-cabad1b771af"),
                Persona = "Cool and awesome"
            };

            db.Insert(expected);
            expected.AliasId = 16;

            Assert.AreEqual(expected.ToString(), db.Get(16).Data.ToString());
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
            AliasEight.AgentId = 9;
            AliasEight.AliasName = "Capricorn";
            AliasEight.Persona = "Wolf in sheep-skin";

            db.Update(AliasEight);
            Alias actual = db.Get(8).Data;
            Assert.AreEqual(AliasEight.AgentId, actual.AgentId);
            Assert.AreEqual(AliasEight.AliasName, actual.AliasName);
            Assert.AreEqual(AliasEight.Persona, actual.Persona);
        }
    }
}

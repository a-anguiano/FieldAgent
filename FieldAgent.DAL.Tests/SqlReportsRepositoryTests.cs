using FieldAgent.DAL.ADO;
using FieldAgent.Core.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldAgent.Core.Entities;

namespace FieldAgent.DAL.Tests
{
    public class SqlReportsRepositoryTests
    {
        SqlReportsRepository db;
        DBFactory dbf;

        TopAgentListItem topAgentListItem1 = new TopAgentListItem
        {
            NameLastFirst = "Calliss, Felix",
            DateOfBirth = DateTime.Parse("4/4/1993"),
            CompletedMissionCount = 1
        };

        TopAgentListItem topAgentListItem2 = new TopAgentListItem 
        { 
            NameLastFirst = "Bond, James",
            DateOfBirth = DateTime.Parse("1/1/1980"),
            CompletedMissionCount = 1
        };

        TopAgentListItem topAgentListItem3 = new TopAgentListItem
        {
            NameLastFirst = "Alexsandrovich, Odelinda",
            DateOfBirth = DateTime.Parse("12/3/1980"),
            CompletedMissionCount = 1
        };



        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new SqlReportsRepository(dbf);
            dbf.GetConnectionString();
        }

        [Test]
        public void TestGetTopAgents()
        {
            List<TopAgentListItem> topAgents = new List<TopAgentListItem>();
            topAgents.Add(topAgentListItem1);
            topAgents.Add(topAgentListItem2);
            topAgents.Add(topAgentListItem3);
            var actual = db.GetTopAgents().Data;

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(topAgents[0].ToString(), actual[0].ToString());
            Assert.AreEqual(topAgents[1].ToString(), actual[1].ToString());
            Assert.AreEqual(topAgents[2].ToString(), actual[2].ToString());
        }

        [Test]
        public void TestGetPensionList()
        {

        }

        [Test]
        public void TestAuditClearance()
        {

        }
    }
}

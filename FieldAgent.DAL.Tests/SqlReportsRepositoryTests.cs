using FieldAgent.DAL.ADO;
using FieldAgent.Core.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

        PensionListItem pensionListItem1 = new PensionListItem
        {
            AgencyName = "Murazik Group, Mur",
            BadgeId = Guid.Parse("c4c0537d-6b12-4d0d-92dd-d71bb6e03f04"),
            NameLastFirst = "Alderson, Jon",
            DateOfBirth = DateTime.Parse("3/4/1990"),
            DeactivationDate = DateTime.Parse("3/4/2010")
        };

        ClearanceAuditListItem audit1 = new ClearanceAuditListItem()
        {
            BadgeId = Guid.Parse("c4c0537d-6b12-4d0d-92dd-d71bb6e03f04"),
            NameLastFirst = "Coleby, Truda", 
            DateOfBirth = DateTime.Parse("12/6/1980"),
            ActivationDate = DateTime.Parse("12/6/1990"),
            DeactivationDate = DateTime.Parse("12/6/2000")
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
            List<PensionListItem> pensions = new List<PensionListItem>();
            pensions.Add(pensionListItem1);
            var actual = db.GetPensionList(6);

            Assert.AreEqual(1, actual.Data.Count);
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(pensions[0].ToString(), actual.Data[0].ToString());
        }

        [Test]
        public void TestAuditClearance()
        {
            List<ClearanceAuditListItem> audits = new List<ClearanceAuditListItem>();
            audits.Add(audit1);
            var actual = db.AuditClearance(1, 2);

            Assert.AreEqual(1, actual.Data.Count);
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(audits[0].ToString(), actual.Data[0].ToString());
        }
    }
}

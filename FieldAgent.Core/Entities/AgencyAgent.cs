﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Entities
{
    [Table("AgencyAgent")]
    public class AgencyAgent
    {
        public int AgencyId { get; set; }
        public int AgentId { get; set; }

        public Guid BadgeId { get; set; }
        
        public DateTime ActivationDate { get; set; }
        public DateTime DeactivationDate { get; set; }
        public bool IsActive { get; set; }   

        public int SecurityClearanceId { get; set; }
        public SecurityClearance SecurityClearance { get; set; }

        public Agency Agency { get; set; }
        public Agent Agent { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AgencyAgent aa &&
                   AgencyId == aa.AgencyId &&
                   AgentId == aa.AgentId &&
                   BadgeId == aa.BadgeId &&
                   ActivationDate == aa.ActivationDate &&
                   DeactivationDate == aa.DeactivationDate &&
                   IsActive == aa.IsActive &&
                   SecurityClearanceId == aa.SecurityClearanceId;

                   //Type == transaction.Type &&
                   //Timestamp == transaction.Timestamp &&
                   //Amount == transaction.Amount &&
                   //Note == transaction.Note &&
                   //BankAccountId == transaction.BankAccountId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AgencyId, AgentId, BadgeId, ActivationDate, DeactivationDate, IsActive, SecurityClearanceId);
        }
    }
}

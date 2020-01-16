using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class Event {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Victims { get; set; }
        public int Deaths { get; set; }
        public int Injuries { get; set; }
        public string Notes { get; set; }
        public bool Mediator { get; set; }
        public bool FFSpecial { get; set; }
        public bool Police { get; set; }
        public string Firefighters { get; set; }
        public int OutcomeId { get; set; }
        public int VictimTypeId { get; set; }
        public int EventTypeId { get; set; }
        public int SeverityId { get; set; }
        public int InstigatorId { get; set; }
        public int GroupId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

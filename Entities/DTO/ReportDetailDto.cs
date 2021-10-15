using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ReportDetailDto:IDto
    {
        public string FullName { get; set; }
        public string DegreeName { get; set; }
        public DateTime? ReportTime { get; set; }
        public int SerialNumber { get; set; }
        public int ImportanceLevel { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string WorksPerformed { get; set; }
        public string Requester { get; set; }
        public DateTime? EstimatedEndTime { get; set; }
        public bool TimeOut { get; set; }
        public int Hours { get; set; }
        public bool Status { get; set; }
        public string Suggestions { get; set; }
    }
}

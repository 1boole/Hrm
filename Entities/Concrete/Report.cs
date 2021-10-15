using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class Report:IEntity
    {
        [Key]
        public int SerialNumber { get; set; }
        [Required]
        public string ReportCreatorId { get; set; }
        [Required]
        public int ImportanceLevel { get; set; }
        [Required]
        public DateTime? ReportDateTime { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? FinishTime { get; set; }
        [Required]
        public string WorksPerformed { get; set; }
        [Required]
        public string Requester { get; set; }
        [Required]
        public DateTime? EstimatedEndTime { get; set; }
        [Required]
        public bool TimeOut { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Suggestions { get; set; }
    }
}

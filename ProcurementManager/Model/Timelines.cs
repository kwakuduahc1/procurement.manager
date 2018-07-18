using System;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManager.Model
{
    public class Timelines
    {
        public int TimelinesID { get; set; }

        [Required]
        public short ContractParametersID { get; set; }

        [Required]
        public DateTime DateDone { get; set; }

        [StringLength(50, MinimumLength = 10)]
        public string Comments { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IUBAT_Bus_Management_System.Models
{
    public class BusDetails
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Bus")]
        public string BusName { set; get; }

        [Required]
        [Display(Name = "Diver")]
        public string DriverName { get; set; }

        [Required]
        [Display(Name = "Diver Contact")]
        public string DriverPhone { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:T}")]
        public DateTime DeparterTime { get; set; }
    }
}

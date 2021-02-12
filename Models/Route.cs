using System;
using System.ComponentModel.DataAnnotations;

namespace IUBAT_Bus_Management_System.Models
{
    public class Route
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Bus")]
        public string BusName { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string RouteName { get; set; }

        [Required]
        [Display(Name = "Depart at")]
        [DisplayFormat(DataFormatString = "{0:T}")]
        public DateTime ArrivalTime { get; set; }
    }
}

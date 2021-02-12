using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IUBAT_Bus_Management_System.ViewModel
{
    public class EBus
    {
        public int Id { get; set; }

        [Display(Name = "Bus")]
        public string BusName { set; get; }

        public string BusNameB { set; get; }

        [Display(Name = "Diver")]
        public string DriverName { get; set; }

       
        [Display(Name = "Diver Contact")]
        public string DriverPhone { get; set; }

        [Display(Name = "Depart at")]
        [DisplayFormat(DataFormatString = "{0:T}")]
        public DateTime DeparterTime { get; set; }
    }
}

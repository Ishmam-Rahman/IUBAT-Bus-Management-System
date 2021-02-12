using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IUBAT_Bus_Management_System.Models
{
    public class FeedBack
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Time")]
        public DateTime time { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Feedback { get; set; }
    }
}

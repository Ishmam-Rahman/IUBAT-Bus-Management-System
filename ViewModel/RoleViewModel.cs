using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IUBAT_Bus_Management_System.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Rolaname")]
        public string RoleName { get; set; }
    }
}

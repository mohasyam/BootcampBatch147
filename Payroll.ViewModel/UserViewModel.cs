using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name ="User Name"), Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Roles { get; set; }
    }
}

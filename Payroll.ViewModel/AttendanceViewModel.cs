using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class AttendanceViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string BadgeId { get; set; }

        [Display(Name ="Check In"), DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? CheckIn { get; set; }

        [Display(Name = "Check Out"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? CheckOut { get; set; }

        public bool IsActivated { get; set; }
    }
}

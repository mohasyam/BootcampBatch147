using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
   public class SellingHeaderViewModel
    {
        public int Id { get; set; }

        public string Reference { get; set; }

        [Display(Name ="Date of Selling"), Required]
        public DateTime DateOfSelling { get; set; }

        [Display(Name ="Selling Total"), Required]
        public decimal SellingTotal { get; set; }

        public decimal Payment { get; set; }

        public bool IsActivated { get; set; }
    }
}

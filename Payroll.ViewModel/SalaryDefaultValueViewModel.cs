using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class SalaryDefaultValueViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Job Position"), Required]
        public int JobPositionId { get; set; }

        [Display(Name = "Job Position"), Required]
        public string JobPositionName { get; set; }

        [Display(Name ="Salary Component"), Required]
        public int SalaryComponentId { get; set; }

        [Display(Name = "Salary Component"), Required]
        public string SalaryComponentName { get; set; }

        public decimal Value { get; set; }

        public bool IsActivated { get; set; }
    }
}

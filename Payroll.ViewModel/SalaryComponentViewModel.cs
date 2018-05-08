using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class SalaryComponentViewModel
    {
        public SalaryComponentViewModel()
        {
            IsActivated = true;
        }
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }

        [Display(Name ="Period"), Required]
        public string Period { get; set; }

        [Display(Name = "Period")]
        public string PeriodName
        {
            get
            {
                if (Period == "D")
                {
                    return "Daily";
                }

                else if (Period == "M")
                {
                    return "Monthly";
                }

                else
                {
                    return "Uknown";
                }
            }

        }

        [Display(Name ="Type"), Required]
        public string Type { get; set; }

        [Display(Name = "Type")]
        public string TypeName
        {
            get
            {
                if (Type == "D")
                {
                    return "Deduction";
                }

                else if (Type == "I")
                {
                    return "Income";
                }

                else
                {
                    return "Uknown";
                }
            }

        }

        public bool IsActivated { get; set; }
    }
}

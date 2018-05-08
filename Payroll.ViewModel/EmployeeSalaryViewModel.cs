using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class EmployeeSalaryViewModel
    {
        public int Id { get; set; }

        [Display(Name ="NIP"),Required]
        public string BadgeId { get; set; }

        [Display(Name ="Payroll Period")]
        public int PayrollPeriodId { get; set; }
        
        public int PeriodYear { get; set; }
        public int PeriodMonth { get; set; }
        [Display(Name = "Payroll Period")]
        public string Description
        {
            get
            {
                if (PeriodMonth > 0)
                {
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(PeriodMonth) + " " + PeriodYear.ToString();
                }
                else
                {
                    return "No selected period";
                }
            }
        }

        [Display(Name = "Period")]
        public string PayrollPeriod {
                get
                {
                return PeriodMonth + " " + PeriodYear;
                }
                
                }

        [Display(Name ="Salary Component")]
        public int SalaryComponentId { get; set; }

        [Display(Name = "Code")]
        public string SalaryComponentCode { get; set; }

        [Display(Name = "Salary Component")]
        public string SalaryComponentName { get; set; }

        [Display(Name = "Basic Value")]
        public decimal BasicValue { get; set; }

        [Display(Name = "Final Value")]
        public decimal FinalValue { get; set; }

        public bool IsActivated { get; set; }
    }
}

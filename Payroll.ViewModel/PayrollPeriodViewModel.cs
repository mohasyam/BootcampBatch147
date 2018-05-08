﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class PayrollPeriodViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Period Year"), Required]
        public int PeriodYear { get; set; }

        [Display(Name = "Period Month"), Required]
        public int PeriodMonth { get; set; }

        public string Description {
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

        [Display(Name = "Begin Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime BeginDate { get; set; }

        [Display(Name ="End Date"), DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime EndDate { get; set; }

        public bool IsCurentPeriod { get; set; }

        public bool IsActivated { get; set; }
    }
}

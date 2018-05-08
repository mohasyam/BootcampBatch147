using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
   public class SalaryDefaultValuesViewModel
    {
        public int Id { get; set; }
        public int JobPositionId { get; set; }
        public int SalaryComponentId { get; set; }
        public decimal Value { get; set; }
        public bool IsActivated { get; set; }
    }
}

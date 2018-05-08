using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
   public class JobPositionViewModel
    {
        public int Id { get; set; }

        [MaxLength(10), Required]
        public string Code { get; set; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Display(Name = "Department")] //tampil di List
        public string DepartmentCode { get; set; }

        [Display(Name = "Department")] //tampil di List
        public string DepartmentName { get; set; }

        public string DepartmentCodeName {
            get
            {
                return "[" + DepartmentCode + "]" + DepartmentName;
            }
                }

        [MaxLength(50), Required]
        public string Description { get; set; }


        public bool IsActivated { get; set; }
    }
}

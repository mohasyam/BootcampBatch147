using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class WRPrivilegeFormsViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string AccessControlId { get; set; }

        public string[] Right { get; set; }
    }
}

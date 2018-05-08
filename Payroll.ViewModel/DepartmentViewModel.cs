using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class DepartmentViewModel
    {
        
		public int Id { get; set; }

        [MaxLength(10),Required] //Validasi jumlah harus sesuai
        public string Code { get; set; }


        [Display(Name = "Division")] // tampil di list  modal form create dan edit
        public int DivisionId { get; set; }

        [Display(Name = "Division")] //tampil di List
        public string DivisionCode { get; set; }


        [Display(Name = "Division")] //tampil di List
        public string DivisionName{ get; set; }


        [Display(Name = "Division")]
        public string DivisionCodeName
        {
            get
            {             //Kode ada yg ada list digabung devision name
                return "[" +  DivisionCode  + "]" + DivisionName;
            }
        }


        [MaxLength(50), Required] // Validasi Jumlah harus sesuai
        public string Description { get; set; }

        public bool IsActivated { get; set; }

    
    }
}

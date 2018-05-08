using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SellingHeaderRepo
    {
        public static List<SellingHeaderViewModel> Get()
        {
            List<SellingHeaderViewModel> result = new List<SellingHeaderViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingHeader
                          select new SellingHeaderViewModel
                          {
                              Id = d.Id,
                              Reference = d.Reference,
                              DateOfSelling = d.DateOfSelling,
                              SellingTotal = d.SellingTotal,
                              Payment = d.Payment,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static SellingHeaderViewModel GetById(int id)
        {
            SellingHeaderViewModel result = new SellingHeaderViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingHeader
                          where d.Id == id
                          select new SellingHeaderViewModel
                          {
                              Id = d.Id,
                              Reference = d.Reference,
                              DateOfSelling = d.DateOfSelling,
                              SellingTotal = d.SellingTotal,
                              Payment = d.Payment,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(SellingHeaderViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SellingHeader head = db.SellingHeader.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (head != null)
                        {
                            head.Reference = entity.Reference;
                            head.DateOfSelling = entity.DateOfSelling;
                            head.SellingTotal = entity.SellingTotal;
                            head.Payment = entity.Payment;
                            head.IsActivated = entity.IsActivated;
                            head.ModifyBy = "Asyam";
                            head.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SellingHeader head = new SellingHeader();
                        head.Reference = entity.Reference;
                        head.DateOfSelling = entity.DateOfSelling;
                        head.SellingTotal = entity.SellingTotal;
                        head.Payment = entity.Payment;
                        head.IsActivated = entity.IsActivated;
                        head.CreateBy = "Asyam";
                        head.CreateDate = DateTime.Now;
                        db.SellingHeader.Add(head);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }

        public static Responses Delete(int Id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    SellingHeader head = db.SellingHeader.Where(o => o.Id == Id).FirstOrDefault();
                    if (head != null)
                    {
                        db.SellingHeader.Remove(head);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }

    }
}

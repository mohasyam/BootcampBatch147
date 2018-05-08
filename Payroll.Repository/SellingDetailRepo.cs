using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SellingDetailRepo
    {
        public static List<SellingDetailViewModel> Get()
        {
            List<SellingDetailViewModel> result = new List<SellingDetailViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingDetail
                          select new SellingDetailViewModel
                          {
                              Id = d.Id,
                              SellingHeaderId = d.SellingHeaderId,
                              ItemId = d.ItemId,
                              Quantity = d.Quantity,
                              Price = d.Price,
                              Amount = d.Amount,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static SellingDetailViewModel GetById(int id)
        {
            SellingDetailViewModel result = new SellingDetailViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingDetail
                          where d.Id == id
                          select new SellingDetailViewModel
                          {
                              Id = d.Id,
                              SellingHeaderId = d.SellingHeaderId,
                              ItemId = d.ItemId,
                              Quantity = d.Quantity,
                              Price = d.Price,
                              Amount = d.Amount,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(SellingDetailViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SellingDetail head = db.SellingDetail.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (head != null)
                        {
                            head.SellingHeaderId = entity.SellingHeaderId;
                            head.ItemId = entity.ItemId;
                            head.Quantity= entity.Quantity;
                            head.Price = entity.Price;
                            head.Amount = entity.Amount;
                            head.IsActivated = entity.IsActivated;
                            head.ModifyBy = "Asyam";
                            head.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SellingDetail head = new SellingDetail();
                        head.SellingHeaderId = entity.SellingHeaderId;
                        head.ItemId = entity.ItemId;
                        head.Quantity = entity.Quantity;
                        head.Price = entity.Price;
                        head.Amount = entity.Amount;
                        head.IsActivated = entity.IsActivated;
                        head.CreateBy = "Asyam";
                        head.CreateDate = DateTime.Now;
                        db.SellingDetail.Add(head);
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
                    SellingDetail head = db.SellingDetail.Where(o => o.Id == Id).FirstOrDefault();
                    if (head != null)
                    {
                        db.SellingDetail.Remove(head);
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

using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class PayrollPeriodRepo
    {
        public static PayrollPeriodViewModel SelectedPeriod = new PayrollPeriodViewModel();

        public static List<PayrollPeriodViewModel> Get()
        {
            List<PayrollPeriodViewModel> result = new List<PayrollPeriodViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.PayrollPeriod
                          select new PayrollPeriodViewModel
                          {
                              Id = d.Id,
                              PeriodYear = d.PeriodYear,
                              PeriodMonth = d.PeriodMonth,
                              BeginDate = d.BeginDate,
                              EndDate = d.EndDate,
                              IsCurentPeriod = d.IsCurrentPeriod,
                              IsActivated = d.IsActivated,
                          }).ToList();
            }
            return result;
        }

        public static bool SelectPeriod(int id)
        {
            bool result = true;
            try
            {
                using (var db = new PayrollContext())
                {
                    PayrollPeriodViewModel period = new PayrollPeriodViewModel();
                    period = (from d in db.PayrollPeriod
                              where d.Id == id
                              select new PayrollPeriodViewModel
                              {
                                  Id = d.Id,
                                  PeriodYear = d.PeriodYear,
                                  PeriodMonth = d.PeriodMonth,
                                  BeginDate = d.BeginDate,
                                  EndDate = d.EndDate,
                                  IsCurentPeriod = d.IsCurrentPeriod,
                                  IsActivated = d.IsActivated,
                              }).FirstOrDefault();
                    if (result != null)
                    {
                        SelectedPeriod = period;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
            
        }

        public static PayrollPeriodViewModel GetById(int id)
        {
            PayrollPeriodViewModel result = new PayrollPeriodViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.PayrollPeriod
                          where d.Id == id
                          select new PayrollPeriodViewModel
                          {
                              Id = d.Id,
                              PeriodYear = d.PeriodYear,
                              PeriodMonth = d.PeriodMonth,
                              BeginDate = d.BeginDate,
                              EndDate = d.EndDate,
                              IsCurentPeriod = d.IsCurrentPeriod,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(PayrollPeriodViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        PayrollPeriod period = db.PayrollPeriod.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (period != null)
                        {
                            period.PeriodYear = entity.PeriodYear;
                            period.PeriodMonth = entity.PeriodMonth;
                            period.BeginDate = entity.BeginDate;
                            period.EndDate = entity.EndDate;
                            period.IsCurrentPeriod = entity.IsCurentPeriod;
                            period.IsActivated = entity.IsActivated;
                            period.ModifyBy = "Asyam";
                            period.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        PayrollPeriod period = new PayrollPeriod();
                        period.PeriodYear = entity.PeriodYear;
                        period.PeriodMonth = entity.PeriodMonth;
                        period.BeginDate = entity.BeginDate;
                        period.EndDate = entity.EndDate;
                        period.IsCurrentPeriod = entity.IsCurentPeriod;
                        period.IsActivated = entity.IsActivated;
                        period.CreateBy = "Asyam";
                        period.CreateDate = DateTime.Now;
                        db.PayrollPeriod.Add(period);
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
                    PayrollPeriod period = db.PayrollPeriod.Where(o => o.Id == Id).FirstOrDefault();
                    if (period != null)
                    {
                        db.PayrollPeriod.Remove(period);
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

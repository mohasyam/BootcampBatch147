using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class EmployeeSalaryRepo
    {
        public static List<EmployeeSalaryViewModel> Get()
        {
            List<EmployeeSalaryViewModel> result = new List<EmployeeSalaryViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from e in db.EmployeeSalary
                          join p in db.PayrollPeriod on
                          e.PayrollPeriodId equals p.Id
                          join s in db.SalaryComponent on
                          e.SalaryComponentId equals s.Id
                          select new EmployeeSalaryViewModel
                          {
                              Id = e.Id,
                              BadgeId = e.BadgeId,
                              PayrollPeriodId = e.PayrollPeriodId,
                              PeriodMonth = p.PeriodMonth,
                              PeriodYear = p.PeriodYear,
                              SalaryComponentId = e.SalaryComponentId,
                              SalaryComponentName = s.Description,
                              IsActivated = e.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static EmployeeSalaryViewModel GetById(int id)
        {
            EmployeeSalaryViewModel result = new EmployeeSalaryViewModel();
            using (var db = new PayrollContext())
            {
                result = (from e in db.EmployeeSalary
                          join p in db.PayrollPeriod on
                          e.PayrollPeriodId equals p.Id
                          join s in db.SalaryComponent on
                          e.SalaryComponentId equals s.Id
                          select new EmployeeSalaryViewModel
                          {
                              Id = e.Id,
                              BadgeId = e.BadgeId,
                              PayrollPeriodId = e.PayrollPeriodId,
                              PeriodMonth = p.PeriodMonth,
                              PeriodYear = p.PeriodYear,
                              SalaryComponentId = e.SalaryComponentId,
                              SalaryComponentName = s.Description,
                              BasicValue = e.BasicValue,
                              FinalValue = e.FinalValue,
                              IsActivated = e.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static EmployeeSalaryViewModel GetByComponentId(int id)
        {
            EmployeeSalaryViewModel result = new EmployeeSalaryViewModel();
            using (var db = new PayrollContext())
            {
                result = (from s in db.SalaryComponent
                          where s.Id == id 
                          select new EmployeeSalaryViewModel
                          {
                              Id = s.Id,
                              SalaryComponentId = s.Id,
                              SalaryComponentCode = s.Code,
                              SalaryComponentName = s.Description
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static Responses SaveSalary(List<EmployeeSalaryViewModel> entities)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    foreach (var item in entities)
                    {
                        EmployeeSalary es = db.EmployeeSalary
                            .Where(o => o.PayrollPeriodId == item.PayrollPeriodId
                            && o.BadgeId == item.BadgeId
                            && o.SalaryComponentId == item.SalaryComponentId)
                            .FirstOrDefault();
                        if (es == null)
                        {
                            EmployeeSalary newEs = new EmployeeSalary();
                            newEs.PayrollPeriodId = item.PayrollPeriodId;
                            newEs.SalaryComponentId = item.SalaryComponentId;
                            newEs.BadgeId = item.BadgeId;
                            newEs.BasicValue = item.BasicValue;

                            newEs.CreateBy = "Asyam";
                            newEs.CreateDate = DateTime.Now;

                            db.EmployeeSalary.Add(newEs);
                            db.SaveChanges();
                        }
                        else
                        {
                            es.BasicValue = item.BasicValue;
                            es.ModifyBy = "Asyam";
                            es.ModifyDate = DateTime.Now;

                            db.SaveChanges();
                        }
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

        public static List<EmployeeSalaryViewModel> GetByBadgeId(string badgeId)
        {
            return GetByBadgeId(badgeId, 0);
        }

        //untuk delete by salarycomponent
        public static List<EmployeeSalaryViewModel> GetByBadgeId(string badgeId, int salaryComponentId)
        {
            List<EmployeeSalaryViewModel> result = new List<EmployeeSalaryViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.EmployeeSalary
                          join e in db.Employee on
                          d.BadgeId equals e.BadgeId
                          join p in db.PayrollPeriod on
                          d.PayrollPeriodId equals p.Id
                          join sc in db.SalaryComponent on
                          d.SalaryComponentId equals sc.Id
                          where e.BadgeId == badgeId && p.Id == PayrollPeriodRepo.SelectedPeriod.Id && d.SalaryComponentId == (salaryComponentId !=0? salaryComponentId: d.SalaryComponentId)
                          select new EmployeeSalaryViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              PayrollPeriodId = p.Id,
                              PeriodMonth = p.PeriodMonth,
                              PeriodYear = p.PeriodYear,
                              SalaryComponentId = d.SalaryComponentId,
                              SalaryComponentCode = sc.Code,
                              SalaryComponentName = sc.Description,
                              BasicValue = d.BasicValue,
                              FinalValue = d.FinalValue,
                              IsActivated = e.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static Responses Update(EmployeeSalaryViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        EmployeeSalary division = db.EmployeeSalary.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (division != null)
                        {
                            division.BadgeId = entity.BadgeId;
                            division.PayrollPeriodId = entity.PayrollPeriodId;
                            division.SalaryComponentId = entity.SalaryComponentId;
                            division.BasicValue = entity.BasicValue;
                            division.FinalValue = entity.FinalValue;
                            division.IsActivated = entity.IsActivated;
                            division.ModifyBy = "Asyam";
                            division.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        EmployeeSalary division = new EmployeeSalary();
                        division.BadgeId = entity.BadgeId;
                        division.PayrollPeriodId = entity.PayrollPeriodId;
                        division.SalaryComponentId = entity.SalaryComponentId;
                        division.BasicValue = entity.BasicValue;
                        division.FinalValue = entity.FinalValue;
                        division.IsActivated = entity.IsActivated;
                        division.CreateBy = "Asyam";
                        division.CreateDate = DateTime.Now;
                        db.EmployeeSalary.Add(division);
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
                    EmployeeSalary division = db.EmployeeSalary.Where(o => o.Id == Id).FirstOrDefault();
                    if (division != null)
                    {
                        db.EmployeeSalary.Remove(division);
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


        public static Responses RemoveByComponentId(int id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    EmployeeSalary es = db.EmployeeSalary.Where(o => o.Id == id).FirstOrDefault();
                    db.EmployeeSalary.Remove(es);
                    db.SaveChanges();
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

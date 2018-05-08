using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SalaryDefaultValueRepo
    {
        public static List<SalaryDefaultValueViewModel> Get()
        {
            List<SalaryDefaultValueViewModel> result = new List<SalaryDefaultValueViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryDefaultValue
                          join div in db.JobPosition on
                          d.JobPositionId equals div.Id
                          join com in db.SalaryComponent on
                          d.SalaryComponentId equals com.Id
                          select new SalaryDefaultValueViewModel
                          {
                              Id = d.Id,
                              JobPositionId = d.JobPositionId,
                              JobPositionName = div.Description,
                              SalaryComponentId = d.SalaryComponentId,
                              SalaryComponentName = com.Description,
                              Value = d.Value,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static SalaryDefaultValueViewModel GetById(int id)
        {
            SalaryDefaultValueViewModel result = new SalaryDefaultValueViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryDefaultValue
                          join div in db.JobPosition on
                          d.JobPositionId equals div.Id
                          join com in db.SalaryComponent on
                          d.SalaryComponentId equals com.Id
                          select new SalaryDefaultValueViewModel
                          {
                              Id = d.Id,
                              JobPositionId = d.JobPositionId,
                              JobPositionName = div.Description,
                              SalaryComponentId = d.SalaryComponentId,
                              SalaryComponentName = com.Description,
                              Value = d.Value,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static SalaryDefaultValueViewModel GetByJobPosition(int jobPositionId, int salaryComponentId)
        {
            SalaryDefaultValueViewModel result = new SalaryDefaultValueViewModel();
            using (var db = new PayrollContext())
            {
                result = db.SalaryDefaultValue.Where(o => o.JobPositionId == jobPositionId && o.SalaryComponentId == salaryComponentId).Select(o => new SalaryDefaultValueViewModel {
                    Id=o.Id,
                    JobPositionId=o.JobPositionId,
                    SalaryComponentId=o.SalaryComponentId,
                    Value=o.Value
                }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(SalaryDefaultValueViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SalaryDefaultValue division = db.SalaryDefaultValue.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (division != null)
                        {
                            division.JobPositionId = entity.JobPositionId;
                            division.SalaryComponentId= entity.SalaryComponentId;
                            division.Value = entity.Value;
                            division.IsActivated = entity.IsActivated;
                            division.ModifyBy = "Asyam";
                            division.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SalaryDefaultValue division = new SalaryDefaultValue();
                        
                        division.JobPositionId = entity.JobPositionId;
                        division.SalaryComponentId = entity.SalaryComponentId;
                        division.Value = entity.Value;
                        division.IsActivated = entity.IsActivated;
                        division.CreateBy = "Asyam";
                        division.CreateDate = DateTime.Now;
                        db.SalaryDefaultValue.Add(division);
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
                    SalaryDefaultValue division = db.SalaryDefaultValue.Where(o => o.Id == Id).FirstOrDefault();
                    if (division != null)
                    {
                        db.SalaryDefaultValue.Remove(division);
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

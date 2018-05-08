using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SalaryComponentRepo
    {
        public static List<SalaryComponentViewModel> Get()
        {
            List<SalaryComponentViewModel> result = new List<SalaryComponentViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryComponent
                          select new SalaryComponentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Period = d.Period,
                              Type = d.Type,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static SalaryComponentViewModel GetById(int id)
        {
            SalaryComponentViewModel result = new SalaryComponentViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryComponent
                          where d.Id == id
                          select new SalaryComponentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Period = d.Period,
                              Type = d.Type,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(SalaryComponentViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SalaryComponent division = db.SalaryComponent.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (division != null)
                        {
                            division.Code = entity.Code;
                            division.Description = entity.Description;
                            division.Period = entity.Period;
                            division.Type = entity.Type;
                            division.IsActivated = entity.IsActivated;
                            division.ModifyBy = "Asyam";
                            division.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SalaryComponent division = new SalaryComponent();
                        division.Code = entity.Code;
                        division.Description = entity.Description;
                        division.Period = entity.Period;
                        division.Type = entity.Type;
                        division.IsActivated = entity.IsActivated;
                        division.CreateBy = "Asyam";
                        division.CreateDate = DateTime.Now;
                        db.SalaryComponent.Add(division);
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
                    SalaryComponent division = db.SalaryComponent.Where(o => o.Id == Id).FirstOrDefault();
                    if (division != null)
                    {
                        db.SalaryComponent.Remove(division);
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

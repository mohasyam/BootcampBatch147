using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class JobPositionRepo
    {
        public static List<JobPositionViewModel> Get()
        {
            List<JobPositionViewModel> result = new List<JobPositionViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.JobPosition
                          join div in db.Department on
                          d.DepartmentID equals div.Id
                          select new JobPositionViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DepartmentID = d.DepartmentID,
                              DepartmentCode = div.Code,
                              DepartmentName = div.Description,
                              Description= d.Description,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static JobPositionViewModel GetById(int id)
        {
            JobPositionViewModel result = new JobPositionViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.JobPosition
                          where d.Id == id
                          select new JobPositionViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DepartmentID = d.DepartmentID,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(JobPositionViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        JobPosition division = db.JobPosition.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (division != null)
                        {
                            division.Code = entity.Code;
                            division.DepartmentID = entity.DepartmentID;
                            division.Description = entity.Description;
                            division.IsActivated = entity.IsActivated;
                            division.ModifyBy = "Asyam";
                            division.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        JobPosition division = new JobPosition();
                        division.Code = entity.Code;
                        division.DepartmentID = entity.DepartmentID;
                        division.Description = entity.Description;
                        division.IsActivated = entity.IsActivated;
                        division.CreateBy = "Asyam";
                        division.CreateDate = DateTime.Now;
                        db.JobPosition.Add(division);
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
                    JobPosition division = db.JobPosition.Where(o => o.Id == Id).FirstOrDefault();
                    if (division != null)
                    {
                        db.JobPosition.Remove(division);
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

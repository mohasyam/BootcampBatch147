using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class EmployeeRepo
    {
        public static List<EmployeeViewModel> Get()
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join div in db.JobPosition on
                          d.JobPositionId equals div.Id
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobPositionId = d.JobPositionId,
                              JobCode = div.Code,
                              JobName = div.Description,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static EmployeeViewModel GetById(int id)
        {
            EmployeeViewModel result = new EmployeeViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join div in db.JobPosition on
                          d.JobPositionId equals div.Id
                          where d.Id == id
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobPositionId = d.JobPositionId,
                              JobName = div.Description,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static EmployeeViewModel GetByBadgeId(string BadgeId)
        {
            EmployeeViewModel result = new EmployeeViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join div in db.JobPosition on
                          d.JobPositionId equals div.Id
                          where d.BadgeId == BadgeId
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobPositionId = d.JobPositionId,
                              JobName = div.Description,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();
            }
            return result;
        }

        public static List<EmployeeViewModel> GetBySearching(string search)
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join div in db.JobPosition on
                          d.JobPositionId equals div.Id
                          where d.Id.ToString().Contains(search) || d.BadgeId.Contains(search) || d.FirstName.Contains(search) |d.MiddleName.Contains(search) || d.LastName.Contains(search) || div.Description.Contains(search)
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobPositionId = d.JobPositionId,
                              JobName = div.Description,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }
                          ).ToList();
            }
            return result;
        }

        public static Responses Update(EmployeeViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        Employee division = db.Employee.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (division != null)
                        {
                            division.BadgeId = entity.BadgeId;
                            division.JobPositionId = entity.JobPositionId;
                            division.FirstName = entity.FirstName;
                            division.MiddleName = entity.MiddleName;
                            division.LastName = entity.LastName;
                            division.Address = entity.Address;
                            division.DateOfHire = entity.DateOfHire;
                            division.DateOfResign = entity.DateOfResign;
                            division.PlaceOfBirth = entity.PlaceOfBirth;
                            division.DateOfBirth = entity.DateOfBirth;
                            division.Gender = entity.Gender;
                            division.IsActivated = entity.IsActivated;
                            division.ModifyBy = "Asyam";
                            division.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Employee division = new Employee();
                        division.BadgeId = entity.BadgeId;
                        division.JobPositionId = entity.JobPositionId;
                        division.FirstName = entity.FirstName;
                        division.MiddleName = entity.MiddleName;
                        division.LastName = entity.LastName;
                        division.Address = entity.Address;
                        division.DateOfHire = entity.DateOfHire;
                        division.DateOfResign = entity.DateOfResign;
                        division.PlaceOfBirth = entity.PlaceOfBirth;
                        division.DateOfBirth = entity.DateOfBirth;
                        division.Gender = entity.Gender;
                        division.IsActivated = entity.IsActivated;
                        division.CreateBy = "Asyam";
                        division.CreateDate = DateTime.Now;
                        db.Employee.Add(division);
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
                    Employee division = db.Employee.Where(o => o.Id == Id).FirstOrDefault();
                    if (division != null)
                    {
                        db.Employee.Remove(division);
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

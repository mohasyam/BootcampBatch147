﻿using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class AttendanceRepo
    {
        public static List<AttendanceViewModel> Get()
        {
            List<AttendanceViewModel> result = new List<AttendanceViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Attendance
                          select new AttendanceViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              CheckIn = d.CheckIn,
                              CheckOut = d.CheckOut,
                              IsActivated = d.IsActivated,
                          }).ToList();
            }
            return result;
        }

        public static AttendanceViewModel GetById(int id)
        {
            AttendanceViewModel result = new AttendanceViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Attendance
                          where d.Id == id
                          select new AttendanceViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              CheckIn = d.CheckIn,
                              CheckOut = d.CheckOut,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static AttendanceViewModel GetByBadgeId(string badgeId)
        {
            AttendanceViewModel result = new AttendanceViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Attendance
                          where d.BadgeId == badgeId
                          select new AttendanceViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              CheckIn = d.CheckIn,
                              CheckOut = d.CheckOut,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(AttendanceViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        Attendance attendance = db.Attendance.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (attendance != null)
                        {
                            attendance.BadgeId = entity.BadgeId;
                            attendance.CheckIn = entity.CheckIn;
                            attendance.CheckOut = entity.CheckOut;
                            attendance.IsActivated = entity.IsActivated;
                            attendance.ModifyBy = "Asyam";
                            attendance.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Attendance attendance = new Attendance();
                        attendance.BadgeId = entity.BadgeId;
                        attendance.CheckIn = entity.CheckIn;
                        attendance.CheckOut = entity.CheckOut;
                        attendance.IsActivated = entity.IsActivated;
                        attendance.CreateBy = "Asyam";
                        attendance.CreateDate = DateTime.Now;
                        db.Attendance.Add(attendance);
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
                    Attendance attendance = db.Attendance.Where(o => o.Id == Id).FirstOrDefault();
                    if (attendance != null)
                    {
                        db.Attendance.Remove(attendance);
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

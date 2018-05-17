﻿using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class ItemRepo
    {
        public static List<ItemViewModel> GetTen(string filter)
        {
            List<ItemViewModel> result = new List<ItemViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Item
                          where d.Code.Contains(filter) || d.Description.Contains(filter) || filter == null
                          select new ItemViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Price = d.Price,
                              Stock = d.Stock,
                              IsActivated = d.IsActivated
                          }).Take(10).ToList();
            }
            return result;
        }

        public static List<ItemViewModel> Get()
        {
            List<ItemViewModel> result = new List<ItemViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Item
                          select new ItemViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Price = d.Price,
                              Stock = d.Stock,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static ItemViewModel GetById(int id)
        {
            ItemViewModel result = new ItemViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Item
                          where d.Id == id
                          select new ItemViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Price = d.Price,
                              Stock = d.Stock,
                              IsActivated = d.IsActivated
                          }
                          ).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(ItemViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        Item item = db.Item.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (item != null)
                        {
                            item.Code = entity.Code;
                            item.Description = entity.Description;
                            item.Price = entity.Price;
                            item.Stock = entity.Stock;
                            item.IsActivated = entity.IsActivated;
                            item.ModifyBy = "Asyam";
                            item.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Item item = new Item();
                        item.Code = entity.Code;
                        item.Description = entity.Description;
                        item.Price = entity.Price;
                        item.Stock = entity.Stock;
                        item.IsActivated = entity.IsActivated;
                        item.CreateBy = "Asyam";
                        item.CreateDate = DateTime.Now;
                        db.Item.Add(item);
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
                    Item item = db.Item.Where(o => o.Id == Id).FirstOrDefault();
                    if (item != null)
                    {
                        db.Item.Remove(item);
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

using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Payroll.Repository
{
    public class UserRepo
    {
        public static bool UserExist(string user)
        {
            bool result=true;
            using (var db = new PayrollContext())
            {
                Users us = db.Users.Where(o => o.Username == user).FirstOrDefault();
                if (us == null)
                {
                    return result = false;
                }
                else
                {
                    return result = true;
                }
            }
        }

        public static Responses Update(UserViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                        Users usr = new Users();
                        usr.Username = entity.Username;
                        usr.Password = entity.Password;
                        usr.Roles = entity.Roles;
                        db.Users.Add(usr);
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

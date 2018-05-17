using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Payroll.MVC.Address
{
    public class WebAddress
    {
        public static string APIAddress()
        {
            string apiAddress = ConfigurationManager.AppSettings["APIAddress"];
            if (string.IsNullOrEmpty(apiAddress))
            {
                return "";
            }
            return apiAddress;
        }
    }
}
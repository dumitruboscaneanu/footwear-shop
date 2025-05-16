using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShoeShop.Models;

namespace ShoeShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CheckAndCreateDefaultUser();
        }

        private void CheckAndCreateDefaultUser()
        {
            using (var context = new ShoeShopDbContext())
            {
                var user = context.Users.FirstOrDefault(r => r.Name == "main");

                if (user == null)
                {
                    user = new Person
                    {
                        Id = Guid.NewGuid(),
                        Name = "main",
                        Password = "15072",
                        Email = "main@utm.md",
                        IsAdmin = true,
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    
                }
            }
        }
        
        
    }
}
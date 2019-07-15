using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Help_desk
{

    
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Users.Any() == false)
                {
                    Group admin = new Group { Name = "Admin", Slug = Helpers.SlugGenerator.GenerateSlug("Exelent") };
                    db.Groups.AddRange(new List<Group> { admin });

                    User superadmin = new User { Login = "SuperLogin", Email = "taniademyoust@gmail.com", Fname = "Ivan", Lname = "Petrov", Phone = "0631091340" };
                    db.Users.AddRange(new List<User> { superadmin });


                    db.SaveChanges();

                    superadmin.UserGroups.Add(new UserGroup { GroupId = admin.Id, UserId = superadmin.Id });
                    db.SaveChanges();
                }
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task_1.Models
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.Users.Add(new User { Name = "Valeriy", Birthdate = DateTime.Parse("18.05.1996") });
            context.Users.Add(new User { Name = "Aleksey", Birthdate = DateTime.Parse("11.03.2000") });
            context.Users.Add(new User { Name = "Sergey", Birthdate = DateTime.Parse("16.01.1993") });
            context.Users.Add(new User { Name = "Irina", Birthdate = DateTime.Parse("20.11.1977") });



            context.Awards.Add(new Award { Title = "1st place", Description = "Won the first place" });
            context.Awards.Add(new Award { Title = "2nd place", Description = "Won the second place" });
            context.Awards.Add(new Award { Title = "3rd place", Description = "Won the third place" });

            base.Seed(context);
        }

    }
}
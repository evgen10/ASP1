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
            context.Students.Add(new Student { Name = "Valeriy", Birthdate = DateTime.Parse("18.05.1996") });
            context.Students.Add(new Student { Name = "Aleksey", Birthdate = DateTime.Parse("11.03.2000") });
            context.Students.Add(new Student { Name = "Sergey", Birthdate = DateTime.Parse("16.01.1993") });
            context.Students.Add(new Student { Name = "Irina", Birthdate = DateTime.Parse("20.11.1977") });



            base.Seed(context);
        }

    }
}
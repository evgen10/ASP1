using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace Task_1.Models
{
    public class UserList
    {

        static string absolutePathToFile;

        public static string DownloadUserList(out string fileName)
        {
            string appDataPath = HttpContext.Current.Server.MapPath(@"~/Files");
            fileName = "UserList.txt";
             absolutePathToFile = Path.Combine(appDataPath, fileName);


            using (StreamWriter sr = new StreamWriter(absolutePathToFile, false, System.Text.Encoding.Default))
            {
                Context db = new Context();


                foreach (var item in db.Users.ToList())
                {
                    sr.Write(item.Id + " ");
                    sr.Write(item.Name + " ");
                    sr.Write(item.Birthdate.ToLongDateString() + " ");
                    sr.WriteLine(item.Age);

                }

                db.Dispose();
            }


            return absolutePathToFile;
        }

        
    }
}